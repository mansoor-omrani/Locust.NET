using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Dynamic;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Transactions;
using CircuitBreaker.Net;
using CircuitBreaker.Net.Exceptions;
using TypeHelper = Locust.Base.TypeHelper;
using Locust.ConnectionString;
using Locust.CircuitBreaker;
using Locust.Logging;
using Locust.Extensions;
using Locust.Data;
using Locust.Conversion;
using Locust.ModelField;

namespace Locust.Db.SqlServer
{
    internal class GetConnectionResult : IDisposable
    {
        public Exception Exception { get; set; }
        public SqlConnection Connection { get; set; }

        public bool IsOk
        {
            get { return Exception == null; }
        }
        protected void Dispose(Boolean itIsSafeToAlsoFreeManagedObjects)
        {
            //Free unmanaged resources
            //e.g. : Win32.DestroyHandle(this.CursorFileBitmapIconServiceHandle);

            // Free managed resources too, but only if I'm being called from Dispose
            // (If I'm being called from Finalize then the objects might not exist
            // anymore
            if (itIsSafeToAlsoFreeManagedObjects)
            {
                if (Connection != null)
                {
                    if (Connection.State == ConnectionState.Open)
                    {
                        try
                        {
                            Connection.Close();
                        }
                        finally
                        {
                        }
                    }

                    Connection.Dispose();
                    Connection = null;
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
        }

        ~GetConnectionResult()
        {
            Dispose(false);
        }
    }
    public class SqlServerDbHelper : IDbHelper, IDisposable
    {
        #region Fields
        protected IConnectionStringProvider _cnnProvider;
        protected Action<IDbConnection> initConn;
        protected TransactionScope tran;
        protected IDbContextInfoProvider _contextInfoProvider;
        protected ICircuitBreakerStore _circuitBreakerStore;
        protected ICircuitBreakerFactory _circuitBreakerFactory;
        protected ICircuitBreaker circuitBreaker;
        protected IExceptionLogger _logger;
        #endregion
        #region Statics
        public static SqlDbType GetSqlDbType(int x)
        {
            SqlDbType result;

            switch (x)
            {
                case 34: result = SqlDbType.Image; break;
                case 35: result = SqlDbType.Text; break;
                case 36: result = SqlDbType.UniqueIdentifier; break;
                case 40: result = SqlDbType.Date; break;
                case 41: result = SqlDbType.Time; break;
                case 42: result = SqlDbType.DateTime2; break;
                case 43: result = SqlDbType.DateTimeOffset; break;
                case 48: result = SqlDbType.TinyInt; break;
                case 52: result = SqlDbType.SmallInt; break;
                case 56: result = SqlDbType.Int; break;
                case 58: result = SqlDbType.SmallDateTime; break;
                case 59: result = SqlDbType.Real; break;
                case 60: result = SqlDbType.Money; break;
                case 61: result = SqlDbType.DateTime; break;
                case 62: result = SqlDbType.Float; break;
                case 99: result = SqlDbType.NText; break;
                case 104: result = SqlDbType.Bit; break;
                case 106: result = SqlDbType.Decimal; break;
                case 122: result = SqlDbType.SmallMoney; break;
                case 127: result = SqlDbType.BigInt; break;             // Also: User-Defined Data Type
                case 165: result = SqlDbType.VarBinary; break;
                case 167: result = SqlDbType.VarChar; break;
                case 173: result = SqlDbType.Binary; break;
                case 175: result = SqlDbType.Char; break;
                case 189: result = SqlDbType.Timestamp; break;
                case 231: result = SqlDbType.NVarChar; break;           // Also: sysname: length will be 128 bytes
                case 239: result = SqlDbType.NChar; break;
                case 241: result = SqlDbType.Xml; break;

                case 98: result = SqlDbType.Variant; break;             // sql_variant
                case 108: result = SqlDbType.Variant; break;            // numeric
                case 240: result = SqlDbType.Udt; break;                // hierarchyid (128), geometry (129), geography (130)
                case 243: result = SqlDbType.Structured; break;        // User-Defined Table Type

                default: throw new ArgumentException("Invalid Sql Server data type");
            }

            return result;
        }
        public static SqlServerDbHelper GetDefault()
        {
            var _cnn = new AppConfigConnectionStringProvider();
            var cbf = new AppConfigCircuitBreakerFactory();
            var cbs = new AppDomainCircuitBreakerStore();
            var cip = new NoContextInfoProvider();
            var memLogger = new DefaultMemoryLogger();
            var logger = new DebugExceptionLogger();

            return new SqlServerDbHelper(_cnn, cip, cbs, cbf, logger);
        }
        public static void ConfigureDA()
        {
            try
            {
                DA.DefaultDb = GetDefault();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        #endregion
        #region Properties
        public virtual IDbContextInfoProvider ContextInfoProvider
        {
            get { return _contextInfoProvider; }
            set { _contextInfoProvider = value; }
        }
        public virtual ICircuitBreakerStore CircuitBreakerStore
        {
            get { return _circuitBreakerStore; }
            set { _circuitBreakerStore = value; }
        }
        public virtual ICircuitBreakerFactory CircuitBreakerFactory
        {
            get { return _circuitBreakerFactory; }
            set { _circuitBreakerFactory = value; }
        }
        public virtual ICircuitBreaker CircuitBreaker
        {
            get { return circuitBreaker; }
            set { circuitBreaker = value; }
        }
        public virtual IConnectionStringProvider ConnectionStringProvider
        {
            get { return _cnnProvider; }
            set { _cnnProvider = value; }
        }
        public virtual IExceptionLogger ExceptionLogger
        {
            get { return _logger; }
            set { _logger = value; }
        }
        #endregion
        public SqlServerDbHelper(IConnectionStringProvider cnnProvider, IDbContextInfoProvider contextInfoProvider, ICircuitBreakerStore circuitBreakerStore, ICircuitBreakerFactory circuitBreakerFactory, IExceptionLogger logger)
        {
            this._cnnProvider = cnnProvider;
            this._contextInfoProvider = contextInfoProvider;
            this._circuitBreakerStore = circuitBreakerStore;
            this._circuitBreakerFactory = circuitBreakerFactory;
            this._logger = logger;

            cnnProvider.ConnectionStringChanged += OnConnectionStringChanged;
            var cnnstr = cnnProvider.GetConnectionString();
            cnnProvider.SetConnectionString(cnnstr);
            //OnConnectionStringChanged(cnnstr);
        }
        protected void Log(Exception ex, string info = "", object args = null)
        {
            var _args = new StringBuilder();

            if (args != null)
            {
                foreach (var prop in args.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
                {
                    if (prop.CanRead)
                    {
                        var proptype = prop.PropertyType;
                        if (proptype.IsNullableOrBasicType() || proptype.IsModelField() || proptype.IsCommandParameterType())
                        {
                            var value = prop.GetValue(args);
                            var _value = "";
                            var cmdIO = value as CommandInputOutputParameter;
                            if (cmdIO != null)
                            {
                                _value = SafeClrConvert.ToString(cmdIO.Value);
                                _args.AppendFormatWithCommaIfNotEmpty("{0}: {1}", prop.Name, _value);
                                continue;
                            }

                            var cmdGUId = value as GuidCommandParameter;
                            if (cmdGUId != null)
                            {
                                _value = SafeClrConvert.ToString(cmdGUId.Value);
                                _args.AppendFormatWithCommaIfNotEmpty("{0}: {1}", prop.Name, _value);
                                continue;
                            }

                            var cmdParam = value as CommandParameter;
                            if (cmdParam != null)
                            {
                                _value = SafeClrConvert.ToString(cmdParam.Value);
                                _args.AppendFormatWithCommaIfNotEmpty("{0}: {1}", prop.Name, _value);
                                continue;
                            }

                            _value = SafeClrConvert.ToString(value);
                            _args.AppendFormatWithCommaIfNotEmpty("{0}: {1}", prop.Name, _value);
                        }
                    }
                }
            }
            var cnnstr = new Locust.ConnectionString.ConnectionString(ConnectionStringProvider.Current);

            var _info = string.Format("CnnStr: {{datasource: '{0}', db:'{1}', user: {2}}}",
                    cnnstr.DataSource,
                    cnnstr.InitialCatalog,
                    cnnstr.UserId);

            if (!string.IsNullOrEmpty(info))
            {
                _info += ", " + info;
            }

            _info += ", args: " + _args;

            if (
                !(ex is CircuitBreakerExecutionException || ex is CircuitBreakerOpenException ||
                  ex is CircuitBreakerTimeoutException))
            {
                _logger.LogException(ex, _info);
            }
        }
        private void OnConnectionStringChanged(object cnnStrProvider, ConnectionStringChangedEventArgs args)
        {
            if (!string.IsNullOrEmpty(args.NewValue))
            {
                circuitBreaker = _circuitBreakerStore.Get(args.NewValue);

                if (circuitBreaker == null)
                {
                    circuitBreaker = _circuitBreakerFactory.CreateBreaker(args.NewValue);

                    _circuitBreakerStore.Set(circuitBreaker, args.NewValue);
                }
            }
        }
        /*
        private void OnConnectionStringChanged1(string cnnstr)
        {
			if (!string.IsNullOrEmpty(cnnstr))
			{
				circuitBreaker = _circuitBreakerStore.Get(cnnstr);

				if (circuitBreaker == null)
				{
					circuitBreaker = _circuitBreakerFactory.CreateBreaker(cnnstr);

					_circuitBreakerStore.Set(circuitBreaker, cnnstr);
				}
			}
        }
        */
        public virtual IDbCommand GetCommand(string text, bool sproc = true)
        {
            var cmd = new SqlCommand(text);

            if (sproc)
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }
            else
            {
                cmd.CommandType = CommandType.Text;
            }

            return cmd;
        }
        private void populateParameters(IDbCommand cmd, object args)
        {
            var _cmd = cmd as SqlCommand;

            if (args != null)
            {
                Type type = args.GetType();
                var xArgs = args as IDictionary<string, Object>;

                if (xArgs != null)
                {
                    foreach (var item in xArgs)
                    {
                        var value = item.Value;
                        var cmdparam = value as SqlParameter;

                        if (cmdparam != null)
                        {
                            _cmd.Parameters.Add(cmdparam);
                            continue;
                        }

                        var cmdOut = value as CommandOutputParameter;
                        if (cmdOut != null)
                        {
                            var op = cmdOut;
                            var p = new SqlParameter("@" + item.Key, op.DbType);
                            p.Direction = ParameterDirection.Output;
                            if (op.Size > 0 || op.Size == -1)
                            {
                                p.Size = op.Size;
                            }
                            _cmd.Parameters.Add(p);

                            continue;
                        }

                        var cmdIn = value as CommandInputOutputParameter;
                        if (cmdIn != null)
                        {
                            var op = cmdIn;
                            var p = new SqlParameter("@" + item.Key, op.DbType);
                            p.Direction = ParameterDirection.InputOutput;
                            if (op.Size > 0 || op.Size == -1)
                            {
                                p.Size = op.Size;
                            }
                            if (op.Value == null)
                            {
                                p.Value = DBNull.Value;
                            }
                            else
                            {
                                p.Value = op.Value;
                            }
                            _cmd.Parameters.Add(p);

                            continue;
                        }

                        var cmdGuid = value as GuidCommandParameter;
                        if (cmdGuid != null)
                        {
                            var op = cmdGuid;
                            var p = new SqlParameter("@" + item.Key, op.DbType);
                            p.Direction = op.Direction;
                            if (p.Direction == ParameterDirection.Input ||
                                p.Direction == ParameterDirection.InputOutput)
                            {
                                if (op.Value != null)
                                {
                                    p.Value = op.Value;
                                }
                                else
                                {
                                    p.Value = DBNull.Value;
                                }
                            }
                            _cmd.Parameters.Add(p);

                            continue;
                        }

                        var cmdListParam = value as CommandListParameter;

                        if (cmdListParam != null)
                        {
                            var op = cmdListParam;
                            var p = new SqlParameter("@" + item.Key, op.StrongValue);

                            p.SqlDbType = SqlDbType.Structured;
                            p.Direction = op.Direction;
                            p.TypeName = op.Name;

                            if (op.Value == null)
                            {
                                p.Value = DBNull.Value;
                            }

                            _cmd.Parameters.Add(p);

                            continue;
                        }

                        var cmdParam = value as CommandParameter;
                        if (cmdParam != null)
                        {
                            var op = cmdParam;
                            var p = new SqlParameter("@" + item.Key, op.DbType);
                            p.Direction = op.Direction;
                            if (p.Direction == ParameterDirection.Input ||
                                p.Direction == ParameterDirection.InputOutput)
                            {
                                if (op.Value != null)
                                {
                                    p.Value = op.Value;
                                }
                                else
                                {
                                    p.Value = DBNull.Value;
                                }
                            }
                            _cmd.Parameters.Add(p);

                            continue;
                        }

                        {
                            if (value == null)
                            {
                                _cmd.Parameters.AddWithValue("@" + item.Key, DBNull.Value);
                            }
                            else
                            {
                                var p = _cmd.Parameters.AddWithValue("@" + item.Key, value);

                                if (value is DataTable)
                                {
                                    p.SqlDbType = SqlDbType.Structured;
                                }
                            }
                        }
                    }

                    return;
                }

                var properties = type.GetProperties();

                foreach (var property in properties)
                {
                    var value = property.GetValue(args, null);
                    var cmdparam = value as SqlParameter;

                    if (cmdparam != null)
                    {
                        _cmd.Parameters.Add(cmdparam);
                        continue;
                    }

                    var cmdOut = value as CommandOutputParameter;
                    if (cmdOut != null)
                    {
                        var op = cmdOut;
                        var p = new SqlParameter("@" + property.Name, op.DbType);
                        p.Direction = ParameterDirection.Output;
                        if (op.Size > 0 || op.Size == -1)
                        {
                            p.Size = op.Size;
                        }
                        _cmd.Parameters.Add(p);

                        continue;
                    }

                    var cmdIn = value as CommandInputOutputParameter;
                    if (cmdIn != null)
                    {
                        var op = cmdIn;
                        var p = new SqlParameter("@" + property.Name, op.DbType);
                        p.Direction = ParameterDirection.InputOutput;
                        if (op.Size > 0 || op.Size == -1)
                        {
                            p.Size = op.Size;
                        }
                        if (op.Value == null)
                        {
                            p.Value = DBNull.Value;
                        }
                        else
                        {
                            p.Value = op.Value;
                        }

                        _cmd.Parameters.Add(p);

                        continue;
                    }

                    var cmdGuid = value as GuidCommandParameter;
                    if (cmdGuid != null)
                    {
                        var op = cmdGuid;
                        var p = new SqlParameter("@" + property.Name, op.DbType);
                        p.Direction = op.Direction;
                        if (p.Direction == ParameterDirection.Input ||
                            p.Direction == ParameterDirection.InputOutput)
                        {
                            if (op.Value != null)
                            {
                                p.Value = op.Value;
                            }
                            else
                            {
                                p.Value = DBNull.Value;
                            }
                        }
                        _cmd.Parameters.Add(p);

                        continue;
                    }

                    var cmdListParam = value as CommandListParameter;

                    if (cmdListParam != null)
                    {
                        var op = cmdListParam;
                        var p = new SqlParameter("@" + property.Name, op.StrongValue);

                        p.SqlDbType = SqlDbType.Structured;
                        p.Direction = op.Direction;
                        p.TypeName = op.Name;

                        if (op.Value == null)
                        {
                            p.Value = DBNull.Value;
                        }

                        _cmd.Parameters.Add(p);

                        continue;
                    }

                    var cmdParam = value as CommandParameter;
                    if (cmdParam != null)
                    {
                        var op = cmdParam;
                        var p = new SqlParameter("@" + property.Name, op.DbType);
                        p.Direction = op.Direction;
                        if (p.Direction == ParameterDirection.Input ||
                            p.Direction == ParameterDirection.InputOutput)
                        {
                            if (op.Value != null)
                            {
                                p.Value = op.Value;
                            }
                            else
                            {
                                p.Value = DBNull.Value;
                            }
                        }
                        _cmd.Parameters.Add(p);

                        continue;
                    }

                    {
                        if (value == null)
                        {
                            _cmd.Parameters.AddWithValue("@" + property.Name, DBNull.Value);
                        }
                        else
                        {
                            var p = _cmd.Parameters.AddWithValue("@" + property.Name, value);

                            if (value is DataTable)
                            {
                                p.SqlDbType = SqlDbType.Structured;
                            }
                        }
                    }
                }
            }
        }
        private void updateOutputParams(IDbCommand cmd, object args)
        {
            if (args != null)
            {
                var type = args.GetType();
                var xArgs = args as IDictionary<string, Object>;
                if (xArgs != null)
                {
                    foreach (SqlParameter p in cmd.Parameters)
                    {
                        if (p.Direction == ParameterDirection.Output || p.Direction == ParameterDirection.InputOutput)
                        {
                            var key = p.ParameterName.Replace("@", "");
                            if (xArgs.ContainsKey(key))
                            {
                                var arg = xArgs[key];

                                if (p.DbType == DbType.Guid)
                                {
                                    if (!DBNull.Value.Equals(p.Value))
                                    {
                                        var cmdOut = arg as CommandOutputParameter;
                                        if (cmdOut != null)
                                        {
                                            cmdOut.Value = System.Convert.ChangeType(p.Value, TypeHelper.TypeOfGuid);
                                        }
                                        else
                                        {
                                            var cmdIO = arg as CommandInputOutputParameter;
                                            if (cmdIO != null)
                                            {
                                                cmdIO.Value = System.Convert.ChangeType(p.Value, TypeHelper.TypeOfGuid);
                                            }
                                            else
                                            {
                                                var cmdGUID = arg as GuidCommandParameter;

                                                if (cmdGUID != null)
                                                {
                                                    cmdGUID.Value = System.Convert.ChangeType(p.Value, TypeHelper.TypeOfGuid);
                                                }
                                                else
                                                {
                                                    var cmdParam = arg as CommandParameter;

                                                    if (cmdParam != null)
                                                    {
                                                        cmdParam.Value = System.Convert.ChangeType(p.Value, TypeHelper.TypeOfGuid);
                                                    }
                                                    else
                                                    {
                                                        xArgs[key] = System.Convert.ChangeType(p.Value, TypeHelper.TypeOfGuid);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (!DBNull.Value.Equals(p.Value))
                                    {
                                        var cmdOut = arg as CommandOutputParameter;
                                        if (cmdOut != null)
                                        {
                                            cmdOut.Value = p.Value;
                                        }
                                        else
                                        {
                                            var cmdIO = arg as CommandInputOutputParameter;
                                            if (cmdIO != null)
                                            {
                                                cmdIO.Value = p.Value;
                                            }
                                            else
                                            {
                                                var cmdGUID = arg as GuidCommandParameter;

                                                if (cmdGUID != null)
                                                {
                                                    cmdGUID.Value = p.Value;
                                                }
                                                else
                                                {
                                                    var cmdParam = arg as CommandParameter;

                                                    if (cmdParam != null)
                                                    {
                                                        cmdParam.Value = p.Value;
                                                    }
                                                    else
                                                    {
                                                        xArgs[key] = p.Value;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    return;
                }

                foreach (SqlParameter p in cmd.Parameters)
                {
                    if (p.Direction == ParameterDirection.Output || p.Direction == ParameterDirection.InputOutput)
                    {
                        var property = type.GetProperty(p.ParameterName.Replace("@", ""));

                        if (property != null)
                        {
                            var outputProperty = property.GetValue(args);
                            var propValueProperty = outputProperty.GetType().GetProperty("Value");

                            if (p.DbType == DbType.Guid)
                            {
                                if (!DBNull.Value.Equals(p.Value))
                                {
                                    propValueProperty.SetValue(outputProperty,
                                        System.Convert.ChangeType(p.Value, TypeHelper.TypeOfGuid), null);
                                }
                            }
                            else
                            {
                                propValueProperty.SetValue(outputProperty,
                                    System.Convert.ChangeType(p.Value, propValueProperty.PropertyType), null);
                            }
                        }
                    }
                }
            }
        }

        public virtual DbResult<List<T>> ExecuteTable<T>(IDbCommand cmd, Func<DataRow, T> transform, object args = null, string tableName = "table")
        {
            var data = new List<T>();
            var result = new DbResult<List<T>>();

            var dbr = ExecuteTable(cmd, args, tableName);

            if (dbr.Success)
            {
                foreach (DataRow row in dbr.Data.Rows)
                {
                    var x = transform(row);

                    data.Add(x);
                }
            }

            result.ExecArgs = args;
            result.Exception = dbr.Exception;
            result.Count = dbr.Count;
            result.Info = dbr.Info;
            result.Success = dbr.Success;
            result.MessageType = dbr.MessageType;
            result.Data = data;

            return result;
        }
        public virtual DbResult<List<T>> ExecuteTable<T>(IDbCommand cmd, Func<DataColumnCollection, DataRow, T> transform, object args = null, string tableName = "table")
        {
            var data = new List<T>();
            var result = new DbResult<List<T>>();
            var dbr = ExecuteTable(cmd, args, tableName);

            if (dbr.Success)
            {
                foreach (DataRow row in dbr.Data.Rows)
                {
                    var x = transform(dbr.Data.Columns, row);

                    data.Add(x);
                }
            }

            result.ExecArgs = args;
            result.Exception = dbr.Exception;
            result.Count = dbr.Count;
            result.Info = dbr.Info;
            result.Success = dbr.Success;
            result.MessageType = dbr.MessageType;
            result.Data = data;

            return result;
        }
        public virtual DbResult<List<object>> ExecuteTableDynamic(IDbCommand cmd, object args = null, string tableName = "table")
        {
            Func<DataColumnCollection, DataRow, object> transform = (cols, row) =>
            {
                var x = (new ExpandoObject()) as IDictionary<string, object>;
                foreach (DataColumn col in cols)
                {
                    x.Add(col.ColumnName, row[col.ColumnName]);
                }
                return x;
            };

            return ExecuteTable(cmd, transform, args, tableName);
        }
        public virtual DbResult<List<object>> ExecuteReaderDynamic(IDbCommand cmd, object args = null)
        {
            Func<IDataReader, object> transform = (reader) =>
            {
                var x = (new ExpandoObject()) as IDictionary<string, object>;
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    x.Add(reader.GetName(i), reader.GetValue(i));
                }
                return x;
            };

            return ExecuteReader(cmd, transform, args);
        }
        public virtual DbResult<SchemaBasedList> ExecuteReaderSchemaDynamic(IDbCommand cmd, object args = null)
        {
            var cols = new List<string>();
            var schemaExtracted = false;

            Func<IDataReader, object[]> transform = (reader) =>
            {
                //var x = (new ExpandoObject()) as IDictionary<string, object>;
                var x = new List<object>();

                for (var i = 0; i < reader.FieldCount; i++)
                {
                    var colName = reader.GetName(i);

                    if (!schemaExtracted)
                    {
                        cols.Add(colName);
                    }

                    //x.Add(colName, reader.GetValue(i));
                    x.Add(reader.GetValue(i));
                }

                schemaExtracted = true;

                return x.ToArray();
            };

            var dbr = ExecuteReader(cmd, transform, args);

            return DbResult.From(dbr, new SchemaBasedList { Schema = cols, Items = dbr.Data });
        }
        public virtual Task<DbResult<SchemaBasedList>> ExecuteReaderSchemaDynamicAsync(IDbCommand cmd, object args = null)
        {
            return ExecuteReaderSchemaDynamicAsync(cmd, args, CancellationToken.None);
        }
        public virtual async Task<DbResult<SchemaBasedList>> ExecuteReaderSchemaDynamicAsync(IDbCommand cmd, object args, CancellationToken cancellation)
        {
            var cols = new List<string>();
            var schemaExtracted = false;

            Func<IDataReader, object[]> transform = (reader) =>
            {
                //var x = (new ExpandoObject()) as IDictionary<string, object>;
                var x = new List<object>();

                for (var i = 0; i < reader.FieldCount; i++)
                {
                    var colName = reader.GetName(i);

                    if (!schemaExtracted)
                    {
                        cols.Add(colName);
                    }

                    //x.Add(colName, reader.GetValue(i));
                    x.Add(reader.GetValue(i));
                }

                schemaExtracted = true;

                return x.ToArray();
            };

            var dbr = await ExecuteReaderAsync(cmd, transform, args);

            return DbResult.From(dbr, new SchemaBasedList { Schema = cols, Items = dbr.Data });
        }
        public virtual Task<DbResult<List<object>>> ExecuteReaderDynamicAsync(IDbCommand cmd, object args = null)
        {
            return ExecuteReaderDynamicAsync(cmd, args, CancellationToken.None);
        }
        public virtual Task<DbResult<List<object>>> ExecuteReaderDynamicAsync(IDbCommand cmd, object args, CancellationToken cancellation)
        {
            Func<IDataReader, object> transform = (reader) =>
            {
                var x = (new ExpandoObject()) as IDictionary<string, object>;
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    x.Add(reader.GetName(i), reader.GetValue(i));
                }
                return x;
            };

            return ExecuteReaderAsync(cmd, transform, args, cancellation);
        }
        public virtual Task<DbResult<List<object>>> ExecuteReaderAsync(string cmd, Func<IDataReader, object, object> transform, object args, CancellationToken cancellation)
        {
            var _cmd = GetCommand(cmd);

            return ExecuteReaderAsync(_cmd, transform, args, cancellation);
        }
        public virtual DbResult<DataTable> ExecuteTable(IDbCommand cmd, object args = null, string tableName = "table")
        {
            IDbConnection conn;

            var result = GetConnection<DataTable>(out conn);

            result.ExecArgs = args;

            if (result.Success)
            {
                using (conn)
                {
                    try
                    {
                        populateParameters(cmd, args);

                        cmd.Connection = conn as SqlConnection;

                        using (var dap = new SqlDataAdapter(cmd as SqlCommand))
                        {
                            result.Data = new DataTable(tableName);
                            dap.Fill(result.Data);
                        }

                        updateOutputParams(cmd, args);

                        result.Success = true;

                        if (result.Data != null && result.Data.Rows.Count > 0)
                        {
                            result.MessageType = DbMessageType.MultipleSuccess;
                        }
                        else
                        {
                            result.MessageType = DbMessageType.MultipleNotFound;
                        }
                    }
                    catch (Exception ex)
                    {
                        result.Success = false;
                        result.Exception = ex;
                        result.MessageType = DbMessageType.Error;

                        Log(ex, cmd.CommandText, args);
                    }
                }
            }

            return result;
        }
        public virtual DbResult<List<T>> ExecuteReader<T>(IDbCommand cmd, Func<IDataReader, T> transform, object args = null)
        {
            IDbConnection conn;

            var result = GetConnection<List<T>>(out conn);

            result.ExecArgs = args;
            result.Data = new List<T>();

            if (result.Success)
            {
                using (conn)
                {
                    try
                    {
                        populateParameters(cmd, args);

                        cmd.Connection = conn as SqlConnection;

                        var reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            if (transform != null)
                            {
                                result.Data.Add(transform(reader));
                            }
                        }

                        reader.Close();

                        updateOutputParams(cmd, args);

                        result.Success = true;

                        if (result.Data != null && result.Data.Count > 0)
                        {
                            result.MessageType = DbMessageType.MultipleSuccess;
                        }
                        else
                        {
                            result.MessageType = DbMessageType.MultipleNotFound;
                        }
                    }
                    catch (Exception ex)
                    {
                        result.Success = false;
                        result.Exception = ex;
                        result.MessageType = DbMessageType.Error;

                        Log(ex, cmd.CommandText, args);
                    }
                }
            }

            return result;
        }
        public virtual DbResult<List<T>> ExecuteReader<T>(IDbCommand cmd, Func<IDataReader, T, T> transform, object args = null)
        {
            IDbConnection conn;

            var result = GetConnection<List<T>>(out conn);

            result.ExecArgs = args;
            result.Data = new List<T>();

            if (result.Success)
            {
                using (conn)
                {
                    try
                    {
                        populateParameters(cmd, args);

                        cmd.Connection = conn as SqlConnection;

                        var reader = cmd.ExecuteReader();
                        var prev = default(T);
                        var next = default(T);

                        while (reader.Read())
                        {
                            if (transform != null)
                            {
                                next = transform(reader, prev);

                                if ((object)next != null)
                                {
                                    result.Data.Add(next);
                                    prev = next;
                                }
                            }
                        }

                        reader.Close();

                        updateOutputParams(cmd, args);

                        result.Success = true;

                        if (result.Data != null && result.Data.Count > 0)
                        {
                            result.MessageType = DbMessageType.MultipleSuccess;
                        }
                        else
                        {
                            result.MessageType = DbMessageType.MultipleNotFound;
                        }
                    }
                    catch (Exception ex)
                    {
                        result.Success = false;
                        result.Exception = ex;
                        result.MessageType = DbMessageType.Error;

                        Log(ex, cmd.CommandText, args);
                    }
                }
            }

            return result;
        }
        public virtual DbResult<List<T>> ExecuteReader<T>(string cmd, Func<IDataReader, T, T> transform, object args = null)
        {
            var _cmd = GetCommand(cmd);

            return ExecuteReader(_cmd, transform, args);
        }
        public virtual Task<DbResult<List<T>>> ExecuteReaderAsync<T>(IDbCommand cmd, Func<IDataReader, T> transform, object args = null)
        {
            return ExecuteReaderAsync(cmd, transform, args, CancellationToken.None);
        }
        public virtual async Task<DbResult<List<T>>> ExecuteReaderAsync<T>(IDbCommand cmd, Func<IDataReader, T> transform, object args, CancellationToken cancellation)
        {
            IDbConnection conn;

            var result = GetConnection<List<T>>(out conn);

            result.ExecArgs = args;
            result.Data = new List<T>();

            if (result.Success)
            {
                using (conn)
                {
                    try
                    {
                        populateParameters(cmd, args);

                        cmd.Connection = conn as SqlConnection;

                        var reader = await (cmd as SqlCommand).ExecuteReaderAsync(cancellation);

                        while (reader.Read())
                        {
                            if (transform != null)
                            {
                                result.Data.Add(transform(reader));
                            }
                        }

                        reader.Close();

                        updateOutputParams(cmd, args);

                        result.Success = true;

                        if (result.Data != null && result.Data.Count > 0)
                        {
                            result.MessageType = DbMessageType.MultipleSuccess;
                        }
                        else
                        {
                            result.MessageType = DbMessageType.MultipleNotFound;
                        }
                    }
                    catch (Exception ex)
                    {
                        result.Success = false;
                        result.Exception = ex;
                        result.MessageType = DbMessageType.Error;

                        Log(ex, cmd.CommandText, args);
                    }
                }
            }

            return result;
        }
        public virtual Task<DbResult<List<T>>> ExecuteReaderAsync<T>(IDbCommand cmd, Func<IDataReader, T, T> transform, object args = null)
        {
            return ExecuteReaderAsync(cmd, transform, args, CancellationToken.None);
        }
        public virtual async Task<DbResult<List<T>>> ExecuteReaderAsync<T>(IDbCommand cmd, Func<IDataReader, T, T> transform, object args, CancellationToken cancellation)
        {
            IDbConnection conn;

            var result = GetConnection<List<T>>(out conn);

            result.ExecArgs = args;
            result.Data = new List<T>();

            if (result.Success)
            {
                using (conn)
                {
                    try
                    {
                        populateParameters(cmd, args);

                        cmd.Connection = conn as SqlConnection;

                        var reader = await (cmd as SqlCommand).ExecuteReaderAsync();
                        var prev = default(T);
                        var next = default(T);

                        while (reader.Read())
                        {
                            if (transform != null)
                            {
                                next = transform(reader, prev);

                                if ((object)next != null)
                                {
                                    result.Data.Add(next);
                                    prev = next;
                                }
                            }
                        }

                        reader.Close();

                        updateOutputParams(cmd, args);

                        result.Success = true;

                        if (result.Data != null && result.Data.Count > 0)
                        {
                            result.MessageType = DbMessageType.MultipleSuccess;
                        }
                        else
                        {
                            result.MessageType = DbMessageType.MultipleNotFound;
                        }
                    }
                    catch (Exception ex)
                    {
                        result.Success = false;
                        result.Exception = ex;
                        result.MessageType = DbMessageType.Error;

                        Log(ex, cmd.CommandText, args);
                    }
                }
            }

            return result;
        }
        public virtual DbResult<object> ExecuteScaler(IDbCommand cmd, object args = null)
        {
            IDbConnection conn;

            var result = GetConnection<object>(out conn);

            result.ExecArgs = args;

            if (result.Success)
            {
                using (conn)
                {
                    try
                    {
                        populateParameters(cmd, args);

                        cmd.Connection = conn as SqlConnection;

                        result.Data = cmd.ExecuteScalar();

                        updateOutputParams(cmd, args);

                        result.Success = true;
                    }
                    catch (Exception ex)
                    {
                        result.Success = false;
                        result.Exception = ex;
                        result.MessageType = DbMessageType.Error;

                        Log(ex, cmd.CommandText, args);
                    }
                }
            }

            return result;
        }
        public virtual Task<DbResult<object>> ExecuteScalerAsync(IDbCommand cmd, object args = null)
        {
            return ExecuteScalerAsync(cmd, args, CancellationToken.None);
        }
        public virtual async Task<DbResult<object>> ExecuteScalerAsync(IDbCommand cmd, object args, CancellationToken cancellation)
        {
            IDbConnection conn;

            var result = GetConnection<object>(out conn);

            result.ExecArgs = args;

            if (result.Success)
            {
                using (conn)
                {
                    try
                    {
                        populateParameters(cmd, args);

                        cmd.Connection = conn as SqlConnection;

                        result.Data = await (cmd as SqlCommand).ExecuteScalarAsync(cancellation);

                        updateOutputParams(cmd, args);

                        result.Success = true;
                    }
                    catch (Exception ex)
                    {
                        result.Success = false;
                        result.Exception = ex;
                        result.MessageType = DbMessageType.Error;

                        Log(ex, cmd.CommandText, args);
                    }
                }
            }

            return result;
        }
        public virtual DbResult<int> ExecuteNonQuery(IDbCommand cmd, object args = null)
        {
            IDbConnection conn;

            var result = GetConnection<int>(out conn);

            result.ExecArgs = args;

            if (result.Success)
            {
                using (conn)
                {
                    try
                    {
                        populateParameters(cmd, args);

                        cmd.Connection = conn as SqlConnection;
                        result.Data = cmd.ExecuteNonQuery();

                        updateOutputParams(cmd, args);

                        result.MessageType = DbMessageType.Success;
                        result.Success = true;
                    }
                    catch (Exception ex)
                    {
                        result.Success = false;
                        result.Exception = ex;
                        result.MessageType = DbMessageType.Error;

                        Log(ex, cmd.CommandText, args);
                    }
                }
            }

            return result;
        }
        public virtual Task<DbResult<int>> ExecuteNonQueryAsync(IDbCommand cmd, object args = null)
        {
            return ExecuteNonQueryAsync(cmd, args, CancellationToken.None);
        }
        public virtual async Task<DbResult<int>> ExecuteNonQueryAsync(IDbCommand cmd, object args, CancellationToken cancellation)
        {
            IDbConnection conn;

            var result = GetConnection<int>(out conn);

            result.ExecArgs = args;

            if (result.Success)
            {
                using (conn)
                {
                    try
                    {
                        populateParameters(cmd, args);

                        cmd.Connection = conn as SqlConnection;

                        result.Data = await (cmd as SqlCommand).ExecuteNonQueryAsync(cancellation);

                        updateOutputParams(cmd, args);

                        result.MessageType = DbMessageType.Success;
                        result.Success = true;
                    }
                    catch (Exception ex)
                    {
                        result.Success = false;
                        result.Exception = ex;
                        result.MessageType = DbMessageType.Error;

                        Log(ex, cmd.CommandText, args);
                    }
                }
            }

            return result;
        }
        public virtual DbResult<List<T>> ExecuteReader<T>(string cmd, Func<IDataReader, T> transform, object args = null)
        {
            var _cmd = GetCommand(cmd);

            return ExecuteReader(_cmd, transform, args);
        }
        public virtual Task<DbResult<List<T>>> ExecuteReaderAsync<T>(string cmd, Func<IDataReader, T> transform, object args = null)
        {
            var _cmd = GetCommand(cmd);

            return ExecuteReaderAsync(_cmd, transform, args);
        }
        public virtual Task<DbResult<List<T>>> ExecuteReaderAsync<T>(string cmd, Func<IDataReader, T> transform, object args, CancellationToken cancellation)
        {
            var _cmd = GetCommand(cmd);

            return ExecuteReaderAsync(_cmd, transform, args, cancellation);
        }
        public virtual DbResult<DataTable> ExecuteTable(string cmd, object args = null, string tableName = "table")
        {
            var _cmd = GetCommand(cmd);

            return ExecuteTable(_cmd, args, tableName);
        }
        public virtual DbResult<object> ExecuteScaler(string cmd, object args = null)
        {
            var _cmd = GetCommand(cmd);

            return ExecuteScaler(_cmd, args);
        }
        public virtual Task<DbResult<object>> ExecuteScalerAsync(string cmd, object args = null)
        {
            var _cmd = GetCommand(cmd);

            return ExecuteScalerAsync(_cmd, args);
        }
        public virtual Task<DbResult<object>> ExecuteScalerAsync(string cmd, object args, CancellationToken cancellation)
        {
            var _cmd = GetCommand(cmd);

            return ExecuteScalerAsync(_cmd, args, cancellation);
        }
        public virtual DbResult<int> ExecuteNonQuery(string cmd, object args = null)
        {
            var _cmd = GetCommand(cmd);

            return ExecuteNonQuery(_cmd, args);
        }
        public virtual Task<DbResult<int>> ExecuteNonQueryAsync(string cmd, object args = null)
        {
            var _cmd = GetCommand(cmd);

            return ExecuteNonQueryAsync(_cmd, args);
        }
        public virtual Task<DbResult<int>> ExecuteNonQueryAsync(string cmd, object args, CancellationToken cancellation)
        {
            var _cmd = GetCommand(cmd);

            return ExecuteNonQueryAsync(_cmd, args, cancellation);
        }

        public virtual void SetConnectionInitializer(Action<IDbConnection> initConn)
        {
            this.initConn = initConn;
        }
        protected IDbConnection GetConnection()
        {
            var cnn = _cnnProvider.GetConnectionString();
            var con = new SqlConnection(cnn);

            con.Open();

            var contextInfo = _contextInfoProvider.GetContextInfo();

            if (!string.IsNullOrEmpty(contextInfo))
            {
                string CONTEXT_SQL = "declare @ctx varbinary(128)\n" +
                                            "set @ctx = cast(@ctxinfo as varbinary(128))\n" +
                                            "set context_info @ctx";
                CONTEXT_SQL = "declare @ctx varbinary(128)\n" +
                                            "set @ctx = cast('" + contextInfo + "' as varbinary(128))\n" +
                                            "set context_info @ctx";
                var cmd = con.CreateCommand();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = CONTEXT_SQL;

                cmd.ExecuteNonQuery();

                Debug.WriteLine(contextInfo);
            }

            if (initConn != null)
            {
                initConn(con);
            }

            return con;
        }
        public virtual DbResult GetConnection(out IDbConnection conn)
        {
            var result = new DbResult();

            if (circuitBreaker != null)
            {
                try
                {
                    conn = circuitBreaker.Execute<IDbConnection>(GetConnection);

                    result.Success = true;
                }
                catch (Exception e)
                {
                    conn = null;

                    result.Exception = e;
                }
            }
            else
            {
                conn = GetConnection();

                result.Success = true;
            }

            return result;
        }
        public virtual DbResult<T> GetConnection<T>(out IDbConnection conn)
        {
            var result = new DbResult<T>();

            if (circuitBreaker != null)
            {
                try
                {
                    conn = circuitBreaker.Execute<IDbConnection>(GetConnection);

                    result.Success = true;
                }
                catch (Exception e)
                {
                    conn = null;

                    result.Exception = e;
                }
            }
            else
            {
                conn = GetConnection();

                result.Success = true;
            }

            return result;
        }
        public virtual void BeginTran(bool distributed)
        {
            lock (AppDomain.CurrentDomain)
            {
                if (tran == null)
                {
                    tran = new TransactionScope();
                }
            }
        }
        public virtual void Commit()
        {
            lock (AppDomain.CurrentDomain)
            {
                if (tran != null)
                {
                    tran.Complete();
                }

                tran = null;
            }
        }
        public virtual void Rollback()
        {
            lock (AppDomain.CurrentDomain)
            {
                if (tran != null)
                {
                    try
                    {
                        tran.Dispose();
                        tran = null;
                    }
                    finally
                    {
                    }
                }
            }
        }
        public virtual void Dispose()
        {
            lock (AppDomain.CurrentDomain)
            {
                if (tran != null)
                {
                    try
                    {
                        tran.Dispose();
                        tran = null;
                    }
                    finally
                    {
                    }
                }
            }
        }

        public virtual DbResult<T> ExecuteSingle<T>(string sp, Func<DataRow, T> transform, object args = null) where T : class
        {
            var cmd = GetCommand(sp);

            return ExecuteSingle<T>(cmd, transform, args);
        }
        public virtual DbResult<T> ExecuteSingle<T>(string sp, Func<IDataReader, T> transform, object args = null) where T : class
        {
            var cmd = GetCommand(sp);

            return ExecuteSingle<T>(cmd, transform, args);
        }
        public virtual Task<DbResult<T>> ExecuteSingleAsync<T>(string sp, Func<IDataReader, T> transform, object args = null) where T : class
        {
            var cmd = GetCommand(sp);

            return ExecuteSingleAsync<T>(cmd, transform, args, CancellationToken.None);
        }
        public virtual Task<DbResult<T>> ExecuteSingleAsync<T>(string sp, Func<IDataReader, T> transform, object args, CancellationToken cancellation) where T : class
        {
            var cmd = GetCommand(sp);

            return ExecuteSingleAsync<T>(cmd, transform, args);
        }
        public virtual DbResult<T> ExecuteSingle<T>(IDbCommand cmd, Func<DataRow, T> transform, object args = null) where T : class
        {
            T data = null;

            DbResult<List<T>> dbr = ExecuteTable(cmd, transform, args, "table");

            if (dbr.Success)
            {
                dbr.MessageType = (dbr.Data.Count > 0) ? DbMessageType.SingleSuccess : DbMessageType.SingleNotFound;

                if (dbr.Data != null && dbr.Data.Count > 0)
                {
                    data = dbr.Data[0];
                }
            }
            else
            {
                dbr.MessageType = DbMessageType.SingleError;
            }

            var result = dbr.Copy<T>(data);

            return result;
        }
        public virtual DbResult<T> ExecuteSingle<T>(IDbCommand cmd, Func<IDataReader, T> transform, object args = null)
        {
            IDbConnection conn;

            var result = GetConnection<T>(out conn);

            result.ExecArgs = args;

            if (result.Success)
            {
                using (conn)
                {
                    try
                    {
                        populateParameters(cmd, args);

                        cmd.Connection = conn as SqlConnection;
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (transform != null)
                            {
                                result.Data = transform(reader);
                            }

                            break;
                        }
                        reader.Close();

                        updateOutputParams(cmd, args);

                        result.Success = true;

                        if (result.Data != null)
                        {
                            result.MessageType = DbMessageType.SingleSuccess;
                        }
                        else
                        {
                            result.MessageType = DbMessageType.SingleNotFound;
                        }
                    }
                    catch (Exception ex)
                    {
                        result.Success = false;
                        result.Exception = ex;
                        result.MessageType = DbMessageType.SingleError;

                        Log(ex, cmd.CommandText, args);
                    }
                }
            }

            return result;
        }
        public virtual DbResult<T> ExecuteSingle<T>(IDbCommand cmd, Func<IDataReader, T, T> transform, object args = null)
        {
            IDbConnection conn;

            var result = GetConnection<T>(out conn);

            result.ExecArgs = args;

            if (result.Success)
            {
                using (conn)
                {
                    try
                    {
                        populateParameters(cmd, args);

                        cmd.Connection = conn as SqlConnection;

                        var reader = cmd.ExecuteReader();
                        var prev = default(T);
                        var next = default(T);

                        while (reader.Read())
                        {
                            if (transform != null)
                            {
                                next = transform(reader, prev);

                                if ((object)next != null)
                                {
                                    result.Data = next;
                                    prev = next;
                                }
                            }
                        }

                        reader.Close();

                        updateOutputParams(cmd, args);

                        result.Success = true;

                        if (result.Data != null)
                        {
                            result.MessageType = DbMessageType.SingleSuccess;
                        }
                        else
                        {
                            result.MessageType = DbMessageType.SingleNotFound;
                        }
                    }
                    catch (Exception ex)
                    {
                        result.Success = false;
                        result.Exception = ex;
                        result.MessageType = DbMessageType.SingleError;

                        Log(ex, cmd.CommandText, args);
                    }
                }
            }

            return result;
        }
        public virtual Task<DbResult<T>> ExecuteSingleAsync<T>(IDbCommand cmd, Func<IDataReader, T> transform, object args = null)
        {
            return ExecuteSingleAsync(cmd, transform, args, CancellationToken.None);
        }
        public virtual async Task<DbResult<T>> ExecuteSingleAsync<T>(IDbCommand cmd, Func<IDataReader, T> transform, object args, CancellationToken cancellation)
        {
            IDbConnection conn;

            var result = GetConnection<T>(out conn);

            result.ExecArgs = args;

            if (result.Success)
            {
                using (conn)
                {
                    try
                    {
                        populateParameters(cmd, args);

                        cmd.Connection = conn as SqlConnection;

                        var reader = await (cmd as SqlCommand).ExecuteReaderAsync(cancellation);

                        while (reader.Read())
                        {
                            if (transform != null)
                            {
                                result.Data = transform(reader);
                            }

                            break;
                        }

                        reader.Close();

                        updateOutputParams(cmd, args);

                        result.Success = true;

                        if (result.Data != null)
                        {
                            result.MessageType = DbMessageType.SingleSuccess;
                        }
                        else
                        {
                            result.MessageType = DbMessageType.SingleNotFound;
                        }
                    }
                    catch (Exception ex)
                    {
                        result.Success = false;
                        result.Exception = ex;
                        result.MessageType = DbMessageType.SingleError;

                        Log(ex, cmd.CommandText, args);
                    }
                }
            }

            return result;
        }
        public virtual Task<DbResult<T>> ExecuteSingleAsync<T>(IDbCommand cmd, Func<IDataReader, T, T> transform, object args = null)
        {
            return ExecuteSingleAsync(cmd, transform, args, CancellationToken.None);
        }
        public virtual async Task<DbResult<T>> ExecuteSingleAsync<T>(IDbCommand cmd, Func<IDataReader, T, T> transform, object args, CancellationToken cancellation)
        {
            IDbConnection conn;

            var result = GetConnection<T>(out conn);

            result.ExecArgs = args;

            if (result.Success)
            {
                using (conn)
                {
                    try
                    {
                        populateParameters(cmd, args);

                        cmd.Connection = conn as SqlConnection;

                        var reader = await (cmd as SqlCommand).ExecuteReaderAsync(cancellation);
                        var prev = default(T);
                        var next = default(T);

                        while (reader.Read())
                        {
                            if (transform != null)
                            {
                                next = transform(reader, prev);

                                if ((object)next != null)
                                {
                                    result.Data = next;
                                    prev = next;
                                }
                            }
                        }

                        reader.Close();

                        updateOutputParams(cmd, args);

                        result.Success = true;

                        if (result.Data != null)
                        {
                            result.MessageType = DbMessageType.SingleSuccess;
                        }
                        else
                        {
                            result.MessageType = DbMessageType.SingleNotFound;
                        }
                    }
                    catch (Exception ex)
                    {
                        result.Success = false;
                        result.Exception = ex;
                        result.MessageType = DbMessageType.SingleError;

                        Log(ex, cmd.CommandText, args);
                    }
                }
            }

            return result;
        }
        public virtual DbResult<List<object>> ExecuteReader(IDbCommand cmd, Func<IDataReader, object> transform, object args = null)
        {
            IDbConnection conn;

            var result = GetConnection<List<object>>(out conn);

            result.ExecArgs = args;
            result.Data = new List<object>();

            if (result.Success)
            {
                using (conn)
                {
                    try
                    {
                        populateParameters(cmd, args);

                        cmd.Connection = conn as SqlConnection;
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (transform != null)
                            {
                                result.Data.Add(transform(reader));
                            }
                        }
                        reader.Close();

                        updateOutputParams(cmd, args);

                        result.Success = true;

                        if (result.Data != null && result.Data.Count > 0)
                        {
                            result.MessageType = DbMessageType.MultipleSuccess;
                        }
                        else
                        {
                            result.MessageType = DbMessageType.MultipleNotFound;
                        }
                    }
                    catch (Exception ex)
                    {
                        result.Success = false;
                        result.Exception = ex;
                        result.MessageType = DbMessageType.Error;

                        Log(ex, cmd.CommandText, args);
                    }
                }
            }

            return result;
        }
        public virtual DbResult<List<object>> ExecuteReader(string cmd, Func<IDataReader, object, object> transform, object args = null)
        {
            var _cmd = GetCommand(cmd);

            return ExecuteReader(_cmd, transform, args);
        }
        public virtual Task<DbResult<List<object>>> ExecuteReaderAsync(IDbCommand cmd, Func<IDataReader, object> transform, object args = null)
        {
            return ExecuteReaderAsync(cmd, transform, args, CancellationToken.None);
        }
        public virtual async Task<DbResult<List<object>>> ExecuteReaderAsync(IDbCommand cmd, Func<IDataReader, object> transform, object args, CancellationToken cancellation)
        {
            IDbConnection conn;

            var result = GetConnection<List<object>>(out conn);

            result.ExecArgs = args;
            result.Data = new List<object>();

            if (result.Success)
            {
                using (conn)
                {
                    try
                    {
                        populateParameters(cmd, args);

                        cmd.Connection = conn as SqlConnection;
                        var reader = await (cmd as SqlCommand).ExecuteReaderAsync(cancellation);

                        while (reader.Read())
                        {
                            if (transform != null)
                            {
                                result.Data.Add(transform(reader));
                            }
                        }

                        reader.Close();

                        updateOutputParams(cmd, args);

                        result.Success = true;

                        if (result.Data != null && result.Data.Count > 0)
                        {
                            result.MessageType = DbMessageType.MultipleSuccess;
                        }
                        else
                        {
                            result.MessageType = DbMessageType.MultipleNotFound;
                        }
                    }
                    catch (Exception ex)
                    {
                        result.Success = false;
                        result.Exception = ex;
                        result.MessageType = DbMessageType.Error;

                        Log(ex, cmd.CommandText, args);
                    }
                }
            }

            return result;
        }
        public virtual Task<DbResult<List<object>>> ExecuteReaderAsync(IDbCommand cmd, Func<IDataReader, object, object> transform, object args = null)
        {
            return ExecuteReaderAsync(cmd, transform, args, CancellationToken.None);
        }
        public virtual async Task<DbResult<List<object>>> ExecuteReaderAsync(IDbCommand cmd, Func<IDataReader, object, object> transform, object args, CancellationToken cancellation)
        {
            IDbConnection conn;

            var result = GetConnection<List<object>>(out conn);

            result.ExecArgs = args;
            result.Data = new List<object>();

            if (result.Success)
            {
                using (conn)
                {
                    try
                    {
                        populateParameters(cmd, args);

                        cmd.Connection = conn as SqlConnection;
                        var reader = await (cmd as SqlCommand).ExecuteReaderAsync();
                        var prev = default(object);
                        var next = default(object);

                        while (reader.Read())
                        {
                            if (transform != null)
                            {
                                next = transform(reader, prev);

                                if (next != null)
                                {
                                    result.Data.Add(next);
                                    prev = next;
                                }
                            }
                        }

                        reader.Close();

                        updateOutputParams(cmd, args);

                        result.Success = true;

                        if (result.Data != null && result.Data.Count > 0)
                        {
                            result.MessageType = DbMessageType.MultipleSuccess;
                        }
                        else
                        {
                            result.MessageType = DbMessageType.MultipleNotFound;
                        }
                    }
                    catch (Exception ex)
                    {
                        result.Success = false;
                        result.Exception = ex;
                        result.MessageType = DbMessageType.Error;

                        Log(ex, cmd.CommandText, args);
                    }
                }
            }

            return result;
        }
        public virtual DbResult<List<object>> ExecuteReader(string cmd, Func<IDataReader, object> transform, object args = null)
        {
            var _cmd = GetCommand(cmd);

            return ExecuteReader(_cmd, transform, args);
        }
        public virtual DbResult<List<object>> ExecuteReader(IDbCommand cmd, Func<IDataReader, object, object> transform, object args = null)
        {
            IDbConnection conn;

            var result = GetConnection<List<object>>(out conn);

            result.ExecArgs = args;
            result.Data = new List<object>();

            if (result.Success)
            {
                using (conn)
                {
                    try
                    {
                        populateParameters(cmd, args);

                        cmd.Connection = conn as SqlConnection;
                        var reader = cmd.ExecuteReader();
                        var prev = default(object);
                        var next = default(object);

                        while (reader.Read())
                        {
                            if (transform != null)
                            {
                                next = transform(reader, prev);

                                if (next != null)
                                {
                                    result.Data.Add(next);
                                    prev = next;
                                }
                            }
                        }

                        reader.Close();

                        updateOutputParams(cmd, args);

                        result.Success = true;

                        if (result.Data != null && result.Data.Count > 0)
                        {
                            result.MessageType = DbMessageType.MultipleSuccess;
                        }
                        else
                        {
                            result.MessageType = DbMessageType.MultipleNotFound;
                        }
                    }
                    catch (Exception ex)
                    {
                        result.Success = false;
                        result.Exception = ex;
                        result.MessageType = DbMessageType.Error;

                        Log(ex, cmd.CommandText, args);
                    }
                }
            }

            return result;
        }
        public virtual Task<DbResult<List<object>>> ExecuteReaderAsync(string cmd, Func<IDataReader, object> transform, object args = null)
        {
            var _cmd = GetCommand(cmd);

            return ExecuteReaderAsync(_cmd, transform, args);
        }
        public virtual Task<DbResult<List<object>>> ExecuteReaderAsync(string cmd, Func<IDataReader, object> transform, object args, CancellationToken cancellation)
        {
            var _cmd = GetCommand(cmd);

            return ExecuteReaderAsync(_cmd, transform, args);
        }
        public virtual Task<DbResult<List<object>>> ExecuteReaderAsync(string cmd, Func<IDataReader, object, object> transform, object args = null)
        {
            return ExecuteReaderAsync(cmd, transform, args, CancellationToken.None);
        }
        public virtual DbResult<int> ExecuteBatch(string batch)
        {
            return new DbResult<int> { MessageType = DbMessageType.Error, Exception = new NotImplementedException() };
        }
        public virtual List<object> TestDB(string cnnStr, string sqlTest = "")
        {
            var result = new List<object>();
            var con = new SqlConnection(cnnStr);

            try
            {
                con.Open();

                result.Add("connection ok");

                if (!string.IsNullOrEmpty(sqlTest))
                {
                    var cmd = new SqlCommand(sqlTest, con);
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        result.Add(reader[0]);
                    }

                    reader.Close();
                }

                con.Close();
            }
            catch (Exception e)
            {
                result.Add("connection error: " + e.Message);
            }

            return result;
        }
    }
}
