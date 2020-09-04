using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Extensions
{
    public static class DataExtensions
    {
        // https://stackoverflow.com/questions/373230/check-for-column-name-in-a-sqldatareader-object
        public static bool HasColumn(this IDataRecord dr, string columnName)
        {
            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (dr.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }
            return false;
        }
        public static IDictionary<string, Object> ToDictionary(this IDataParameterCollection prameters)
        {
            var result = new Dictionary<string, Object>();

            foreach (IDbDataParameter p in prameters)
            {
                result.Add(p.ParameterName.Replace("@", ""), p.Value);
            }

            return result;
        }
        public static string Merge(this DataTable table, string cellSeparator = ",", string rowSeparator = "\r\n")
        {
            var sb = new StringBuilder();

            foreach (DataRow row in table.Rows)
            {
                var temp = "";

                for (var i = 0; i < row.Table.Columns.Count; i++)
                {
                    if (temp == "")
                        temp = row[i].ToString();
                    else
                        temp = temp + cellSeparator + row[i].ToString();
                }

                if (sb.Length > 0)
                    sb.Append(rowSeparator + temp);
                else
                    sb.Append(temp);
            }

            var result = sb.ToString();

            return result;
        }
        public static string Merge(this DataTable table, string[] cols, string cellSeparator = ",", string rowSeparator = "\r\n")
        {
            var sb = new StringBuilder();
            var indexes = new List<int>();

            foreach (var col in cols)
            {
                for (var i = 0; i < table.Columns.Count; i++)
                {
                    if (String.Compare(table.Columns[i].ColumnName, col, true) == 0)
                    {
                        indexes.Add(i);
                    }
                }
            }

            if (indexes.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    var temp = "";

                    foreach (var index in indexes)
                    {
                        if (temp == "")
                            temp = row[index].ToString();
                        else
                            temp = temp + cellSeparator + row[index].ToString();
                    }

                    if (sb.Length > 0)
                        sb.Append(rowSeparator + temp);
                    else
                        sb.Append(temp);
                }
            }

            var result = sb.ToString();

            return result;
        }
        public static DataTable ToDataTable<T>(this IEnumerable<T> list)
        {
            var result = new DataTable();
            var type = typeof(T);
            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.CanRead).ToArray();

            foreach (var prop in props)
            {
                result.Columns.Add(prop.Name, prop.PropertyType);
            }

            foreach (var item in list)
            {
                var row = new object[props.Length];
                var i = 0;

                foreach (var prop in props)
                {
                    row[i++] = prop.GetValue(item);
                }

                result.Rows.Add(row);
            }

            return result;
        }
        public static DataTable ToDataTable(this IEnumerable list)
        {
            var result = new DataTable();

            PropertyInfo[] props = null;
            Type itemType = null;

            foreach (var item in list)
            {
                if (props == null && item != null)
                {
                    itemType = item.GetType();
                    props = itemType.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.CanRead).ToArray();

                    foreach (var prop in props)
                    {
                        result.Columns.Add(prop.Name, prop.PropertyType);
                    }
                }

                if (props != null && item != null && item.GetType() == itemType)
                {
                    var row = new object[props.Length];
                    var i = 0;

                    foreach (var prop in props)
                    {
                        row[i++] = prop.GetValue(item);
                    }

                    result.Rows.Add(row);
                }
            }

            return result;
        }
        public static void AddOutput(this SqlParameterCollection spc, string name, SqlDbType type, int? size = null)
        {
            var param = new SqlParameter(name, type);
            param.Direction = ParameterDirection.Output;

            if (size.HasValue)
            {
                param.Size = size.Value;
            }

            spc.Add(param);
        }
        public static void AddReturn(this SqlParameterCollection spc, string name, SqlDbType type)
        {
            var param = new SqlParameter(name, type);
            param.Direction = ParameterDirection.ReturnValue;

            spc.Add(param);
        }
        public static SqlParameter AddInputOutput(this SqlParameterCollection spc, string name, object value)
        {
            SqlParameter result;

            if (value == null)
            {
                result = spc.AddWithValue(name, DBNull.Value);
            }
            else
            {
                result = spc.AddWithValue(name, value);
            }

            result.Direction = ParameterDirection.InputOutput;

            return result;
        }
        public static void AddInput(this SqlParameterCollection spc, string name, object value)
        {
            if (value == null)
            {
                spc.AddWithValue(name, DBNull.Value);
            }
            else
            {
                spc.AddWithValue(name, value);
            }
        }
        public static void AddStructured(this SqlParameterCollection spc, string name, string typename, DataTable value)
        {
            var param = new SqlParameter(name, SqlDbType.Structured);
            param.TypeName = typename;
            param.Value = value;

            spc.Add(param);
        }
        public static void AddStructured(this SqlParameterCollection spc, string name, string typename, DbDataReader value)
        {
            var param = new SqlParameter(name, SqlDbType.Structured);
            param.TypeName = typename;
            param.Value = value;

            spc.Add(param);
        }
        public static void AddUdt(this SqlParameterCollection spc, string name, string udname, object value)
        {
            var param = new SqlParameter(name, SqlDbType.Udt);
            param.UdtTypeName = udname;
            param.Value = value;

            spc.Add(param);
        }
        public static void AddUdtOutput(this SqlParameterCollection spc, string name, string udname)
        {
            var param = new SqlParameter(name, SqlDbType.Udt);
            param.UdtTypeName = udname;
            param.Direction = ParameterDirection.Output;

            spc.Add(param);
        }
        public static SqlParameter ToSqlParameter<T>(this T x) where T : class
        {
            var table = new DataTable();

            Type t = typeof(T);
            PropertyInfo[] propInfos = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var propInfo in propInfos)
            {
                if (propInfo.CanRead)
                {
                    var name = propInfo.Name;
                    var type = propInfo.PropertyType;

                    table.Columns.Add(name, type);
                }
            }

            var row = table.NewRow();

            foreach (var propInfo in propInfos)
            {
                if (propInfo.CanRead)
                {
                    var value = propInfo.GetValue(x);
                    var name = propInfo.Name;

                    row[name] = value;
                }
            }

            table.Rows.Add(row);

            var p = new SqlParameter("@" + typeof(T).ToString(), table);

            p.SqlDbType = SqlDbType.Structured;
            p.TypeName = typeof(T).ToString();

            return p;
        }
        public static SqlDbType ToSqlDbType(int sql_sys_type) // a is a SQL Server 'sys_type_id' from sys.types/sys.systypes table
        {
            SqlDbType result;

            switch (sql_sys_type)
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
        public static T To<T>(this DataRow row) where T : new()
        {
            var result = new T();
            var type = typeof(T);
            var properties = type.GetProperties();

            foreach (var property in properties)
            {
                property.SetValue(result, row[property.Name]);
            }

            return result;
        }
        public static T To<T>(this IDataRecord rec) where T : new()
        {
            var result = new T();
            var type = typeof(T);
            var properties = type.GetProperties();

            foreach (var property in properties)
            {
                property.SetValue(result, rec[property.Name]);
            }

            return result;
        }
        public static List<T> ToList<T>(this DataTable table) where T : new()
        {
            var result = new List<T>();

            foreach (DataRow row in table.Rows)
            {
                result.Add(row.To<T>());
            }

            return result;
        }
        public static List<T> ToList<T>(this DbDataReader reader) where T : new()
        {
            var result = new List<T>();

            while (reader.Read())
            {
                result.Add(reader.To<T>());
            }

            return result;
        }
    }
}
