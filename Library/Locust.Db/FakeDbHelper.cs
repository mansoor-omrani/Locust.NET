using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Locust.ConnectionString;

namespace Locust.Db
{
    public class FakeDbHelper : IDbHelper
    {
        public bool ThrowNotImplementedException { get; set; }
        public FakeDbHelper()
        { }
        public FakeDbHelper(bool throwNotImplementedException)
        {
            ThrowNotImplementedException = throwNotImplementedException;
        }
        public IConnectionStringProvider ConnectionStringProvider
        {
            get; set;
        }

        public IDbContextInfoProvider ContextInfoProvider
        {
            get; set;
        }

        public void BeginTran(bool distributed)
        {
            if (ThrowNotImplementedException)
                throw new NotImplementedException();
        }

        public void Commit()
        {
            if (ThrowNotImplementedException)
                throw new NotImplementedException();
        }

        public DbResult<int> ExecuteBatch(string batch)
        {
            return new DbResult<int> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error };
        }

        public DbResult<int> ExecuteNonQuery(IDbCommand cmd, object args = null)
        {
            return new DbResult<int> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args };
        }

        public DbResult<int> ExecuteNonQuery(string cmd, object args = null)
        {
            return new DbResult<int> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args };
        }

        public Task<DbResult<int>> ExecuteNonQueryAsync(IDbCommand cmd, object args = null)
        {
            return Task.FromResult(new DbResult<int> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args });
        }

        public Task<DbResult<int>> ExecuteNonQueryAsync(IDbCommand cmd, object args, CancellationToken cancellation)
        {
            return Task.FromResult(new DbResult<int> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args });
        }

        public Task<DbResult<int>> ExecuteNonQueryAsync(string cmd, object args = null)
        {
            return Task.FromResult(new DbResult<int> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args });
        }

        public Task<DbResult<int>> ExecuteNonQueryAsync(string cmd, object args, CancellationToken cancellation)
        {
            return Task.FromResult(new DbResult<int> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args });
        }

        public DbResult<List<T>> ExecuteReader<T>(IDbCommand cmd, Func<IDataReader, T> transform, object args = null)
        {
            return new DbResult<List<T>> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args };
        }

        public DbResult<List<T>> ExecuteReader<T>(IDbCommand cmd, Func<IDataReader, T, T> transform, object args = null)
        {
            return new DbResult<List<T>> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args };
        }

        public DbResult<List<T>> ExecuteReader<T>(string cmd, Func<IDataReader, T> transform, object args = null)
        {
            return new DbResult<List<T>> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args };
        }

        public DbResult<List<T>> ExecuteReader<T>(string cmd, Func<IDataReader, T, T> transform, object args = null)
        {
            return new DbResult<List<T>> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args };
        }

        public DbResult<List<object>> ExecuteReader(IDbCommand cmd, Func<IDataReader, object> transform, object args = null)
        {
            return new DbResult<List<object>> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args };
        }

        public DbResult<List<object>> ExecuteReader(IDbCommand cmd, Func<IDataReader, object, object> transform, object args = null)
        {
            return new DbResult<List<object>> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args };
        }

        public DbResult<List<object>> ExecuteReader(string cmd, Func<IDataReader, object> transform, object args = null)
        {
            return new DbResult<List<object>> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args };
        }

        public DbResult<List<object>> ExecuteReader(string cmd, Func<IDataReader, object, object> transform, object args = null)
        {
            return new DbResult<List<object>> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args };
        }

        public Task<DbResult<List<T>>> ExecuteReaderAsync<T>(IDbCommand cmd, Func<IDataReader, T> transform, object args = null)
        {
            return Task.FromResult(new DbResult<List<T>> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args });
        }

        public Task<DbResult<List<T>>> ExecuteReaderAsync<T>(IDbCommand cmd, Func<IDataReader, T> transform, object args, CancellationToken cancellation)
        {
            return Task.FromResult(new DbResult<List<T>> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args });
        }

        public Task<DbResult<List<T>>> ExecuteReaderAsync<T>(IDbCommand cmd, Func<IDataReader, T, T> transform, object args = null)
        {
            return Task.FromResult(new DbResult<List<T>> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args });
        }

        public Task<DbResult<List<T>>> ExecuteReaderAsync<T>(IDbCommand cmd, Func<IDataReader, T, T> transform, object args, CancellationToken cancellation)
        {
            return Task.FromResult(new DbResult<List<T>> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args });
        }

        public Task<DbResult<List<T>>> ExecuteReaderAsync<T>(string cmd, Func<IDataReader, T> transform, object args = null)
        {
            return Task.FromResult(new DbResult<List<T>> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args });
        }

        public Task<DbResult<List<T>>> ExecuteReaderAsync<T>(string cmd, Func<IDataReader, T> transform, object args, CancellationToken cancellation)
        {
            return Task.FromResult(new DbResult<List<T>> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args });
        }

        public Task<DbResult<List<object>>> ExecuteReaderAsync(IDbCommand cmd, Func<IDataReader, object> transform, object args = null)
        {
            return Task.FromResult(new DbResult<List<object>> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args });
        }

        public Task<DbResult<List<object>>> ExecuteReaderAsync(IDbCommand cmd, Func<IDataReader, object> transform, object args, CancellationToken cancellation)
        {
            return Task.FromResult(new DbResult<List<object>> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args });
        }

        public Task<DbResult<List<object>>> ExecuteReaderAsync(IDbCommand cmd, Func<IDataReader, object, object> transform, object args = null)
        {
            return Task.FromResult(new DbResult<List<object>> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args });
        }

        public Task<DbResult<List<object>>> ExecuteReaderAsync(IDbCommand cmd, Func<IDataReader, object, object> transform, object args, CancellationToken cancellation)
        {
            return Task.FromResult(new DbResult<List<object>> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args });
        }

        public Task<DbResult<List<object>>> ExecuteReaderAsync(string cmd, Func<IDataReader, object> transform, object args = null)
        {
            return Task.FromResult(new DbResult<List<object>> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args });
        }

        public Task<DbResult<List<object>>> ExecuteReaderAsync(string cmd, Func<IDataReader, object> transform, object args, CancellationToken cancellation)
        {
            return Task.FromResult(new DbResult<List<object>> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args });
        }

        public Task<DbResult<List<object>>> ExecuteReaderAsync(string cmd, Func<IDataReader, object, object> transform, object args = null)
        {
            return Task.FromResult(new DbResult<List<object>> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args });
        }

        public Task<DbResult<List<object>>> ExecuteReaderAsync(string cmd, Func<IDataReader, object, object> transform, object args, CancellationToken cancellation)
        {
            return Task.FromResult(new DbResult<List<object>> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args });
        }

        public DbResult<List<object>> ExecuteReaderDynamic(IDbCommand cmd, object args = null)
        {
            return new DbResult<List<object>> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args };
        }

        public Task<DbResult<List<object>>> ExecuteReaderDynamicAsync(IDbCommand cmd, object args = null)
        {
            return Task.FromResult(new DbResult<List<object>> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args });
        }

        public Task<DbResult<List<object>>> ExecuteReaderDynamicAsync(IDbCommand cmd, object args, CancellationToken cancellation)
        {
            return Task.FromResult(new DbResult<List<object>> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args });
        }

        public DbResult<SchemaBasedList> ExecuteReaderSchemaDynamic(IDbCommand cmd, object args = null)
        {
            return new DbResult<SchemaBasedList> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args };
        }

        public Task<DbResult<SchemaBasedList>> ExecuteReaderSchemaDynamicAsync(IDbCommand cmd, object args = null)
        {
            return Task.FromResult(new DbResult<SchemaBasedList> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args });
        }

        public Task<DbResult<SchemaBasedList>> ExecuteReaderSchemaDynamicAsync(IDbCommand cmd, object args, CancellationToken cancellation)
        {
            return Task.FromResult(new DbResult<SchemaBasedList> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args });
        }

        public DbResult<object> ExecuteScaler(IDbCommand cmd, object args = null)
        {
            return new DbResult<object> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args };
        }

        public DbResult<object> ExecuteScaler(string cmd, object args = null)
        {
            return new DbResult<object> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args };
        }

        public Task<DbResult<object>> ExecuteScalerAsync(IDbCommand cmd, object args = null)
        {
            return Task.FromResult(new DbResult<object> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args });
        }

        public Task<DbResult<object>> ExecuteScalerAsync(IDbCommand cmd, object args, CancellationToken cancellation)
        {
            return Task.FromResult(new DbResult<object> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args });
        }

        public Task<DbResult<object>> ExecuteScalerAsync(string cmd, object args = null)
        {
            return Task.FromResult(new DbResult<object> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args });
        }

        public Task<DbResult<object>> ExecuteScalerAsync(string cmd, object args, CancellationToken cancellation)
        {
            return Task.FromResult(new DbResult<object> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args });
        }

        public DbResult<T> ExecuteSingle<T>(string sp, Func<DataRow, T> transform, object args = null) where T : class
        {
            return new DbResult<T> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args };
        }

        public DbResult<T> ExecuteSingle<T>(string sp, Func<IDataReader, T> transform, object args = null) where T : class
        {
            return new DbResult<T> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args };
        }

        public DbResult<T> ExecuteSingle<T>(IDbCommand cmd, Func<DataRow, T> transform, object args = null) where T : class
        {
            return new DbResult<T> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args };
        }

        public DbResult<T> ExecuteSingle<T>(IDbCommand cmd, Func<IDataReader, T> transform, object args = null)
        {
            return new DbResult<T> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args };
        }

        public DbResult<T> ExecuteSingle<T>(IDbCommand cmd, Func<IDataReader, T, T> transform, object args = null)
        {
            return new DbResult<T> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args };
        }

        public Task<DbResult<T>> ExecuteSingleAsync<T>(string sp, Func<IDataReader, T> transform, object args = null) where T : class
        {
            return Task.FromResult(new DbResult<T> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args });
        }

        public Task<DbResult<T>> ExecuteSingleAsync<T>(string sp, Func<IDataReader, T> transform, object args, CancellationToken cancellation) where T : class
        {
            return Task.FromResult(new DbResult<T> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args });
        }

        public Task<DbResult<T>> ExecuteSingleAsync<T>(IDbCommand cmd, Func<IDataReader, T> transform, object args = null)
        {
            return Task.FromResult(new DbResult<T> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args });
        }

        public Task<DbResult<T>> ExecuteSingleAsync<T>(IDbCommand cmd, Func<IDataReader, T> transform, object args, CancellationToken cancellation)
        {
            return Task.FromResult(new DbResult<T> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args });
        }

        public Task<DbResult<T>> ExecuteSingleAsync<T>(IDbCommand cmd, Func<IDataReader, T, T> transform, object args = null)
        {
            return Task.FromResult(new DbResult<T> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args });
        }

        public Task<DbResult<T>> ExecuteSingleAsync<T>(IDbCommand cmd, Func<IDataReader, T, T> transform, object args, CancellationToken cancellation)
        {
            return Task.FromResult(new DbResult<T> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args });
        }

        public DbResult<DataTable> ExecuteTable(IDbCommand cmd, object args = null, string tableName = "table")
        {
            return new DbResult<DataTable> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args };
        }

        public DbResult<List<T>> ExecuteTable<T>(IDbCommand cmd, Func<DataRow, T> transform, object args = null, string tableName = "table")
        {
            return new DbResult<List<T>> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args };
        }

        public DbResult<List<T>> ExecuteTable<T>(IDbCommand cmd, Func<DataColumnCollection, DataRow, T> transform, object args = null, string tableName = "table")
        {
            return new DbResult<List<T>> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args };
        }

        public DbResult<DataTable> ExecuteTable(string cmd, object args = null, string tableName = "table")
        {
            return new DbResult<DataTable> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args };
        }

        public DbResult<List<object>> ExecuteTableDynamic(IDbCommand cmd, object args = null, string tableName = "table")
        {
            return new DbResult<List<object>> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error, ExecArgs = args };
        }

        public IDbCommand GetCommand(string text, bool sproc = true)
        {
            if (ThrowNotImplementedException)
                throw new NotImplementedException();

            return null;
        }

        public DbResult GetConnection(out IDbConnection conn)
        {
            if (ThrowNotImplementedException)
                throw new NotImplementedException();

            conn = null;

            return new DbResult { Exception = new NotImplementedException(), MessageType = DbMessageType.Error };
        }

        public DbResult<T> GetConnection<T>(out IDbConnection conn)
        {
            if (ThrowNotImplementedException)
                throw new NotImplementedException();

            conn = null;

            return new DbResult<T> { Exception = new NotImplementedException(), MessageType = DbMessageType.Error };
        }

        public void Rollback()
        {
            if (ThrowNotImplementedException)
                throw new NotImplementedException();
        }

        public void SetConnectionInitializer(Action<IDbConnection> initConn)
        {
            if (ThrowNotImplementedException)
                throw new NotImplementedException();
        }

        public List<object> TestDB(string cnnStr, string sqlTest = "")
        {
            var result = new List<object>();

            result.Add("FakeDbHelper cannot make any connection.");

            return result;
        }
    }
}
