using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using Locust.CircuitBreaker;
using Locust.ConnectionString;
using Locust.Logging;

namespace Locust.Db
{
    public static class DA
    {
        public static IDbHelper DefaultDb
        {
            get { return _db; }
            set { _db = value; }
        }
        private static IDbHelper _db;
        static DA()
        {
            try
            {
                var _cnn = new AppConfigConnectionStringProvider();
                var cbf = new AppConfigCircuitBreakerFactory();
                var cbs = new AppDomainCircuitBreakerStore();
                var cip = new NoContextInfoProvider();
                var memLogger = new DefaultMemoryLogger();
                var logger = new DebugExceptionLogger();
                _db = new SqlDbHelper(_cnn, cip, cbs, cbf, logger);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        public static IDbCommand GetCommand(string text, bool sproc = true)
        {
            return _db.GetCommand(text, sproc);
        }
        public static DbResult<List<T>> ExecuteReader<T>(SqlCommand cmd, Func<IDataReader, T> transform, dynamic args = null)
        {
            return _db.ExecuteReader(cmd, transform, args);
        }
        public static async Task<DbResult<List<T>>> ExecuteReaderAsync<T>(SqlCommand cmd, Func<IDataReader, T> transform, dynamic args = null)
        {
            return await _db.ExecuteReaderAsync(cmd, transform, args);
        }
        public static DbResult<DataTable> ExecuteTable(SqlCommand cmd, dynamic args, string tableName = "table")
        {
            return _db.ExecuteTable(cmd, args, tableName);
        }
        public static DbResult<object> ExecuteScaler(SqlCommand cmd, dynamic args)
        {
            return _db.ExecuteScaler(cmd, args);
        }
        public static async Task<DbResult<object>> ExecuteScalerAsync(SqlCommand cmd, dynamic args)
        {
            return await _db.ExecuteScaler(cmd, args);
        }
        public static DbResult<int> ExecuteNonQuery(SqlCommand cmd, dynamic args)
        {
            return _db.ExecuteNonQuery(cmd, args);
        }
        public static async Task<DbResult<int>> ExecuteNonQueryAsync(SqlCommand cmd, dynamic args)
        {
            return await _db.ExecuteNonQueryAsync(cmd, args);
        }
        public static IConnectionStringProvider ConnectionStringProvider
        {
            get { return _db.ConnectionStringProvider; }
        }

        public static List<object> TestDB(string cnnStr, string sqlTest = "")
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