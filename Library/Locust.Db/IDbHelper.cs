using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Locust.ConnectionString;

namespace Locust.Db
{
    public class SchemaBasedList
    {
        public List<string> Schema { get; set; }
        public List<object[]> Items { get; set; }
    }
    public interface IDbHelper
    {
        DbResult GetConnection(out IDbConnection conn);
        DbResult<T> GetConnection<T>(out IDbConnection conn);
        void BeginTran(bool distributed);
        void Commit();
        void Rollback();
        void SetConnectionInitializer(Action<IDbConnection> initConn);    // this is intended for setting Context_Info for a sql session
        IDbCommand GetCommand(string text, bool sproc = true);
        IConnectionStringProvider ConnectionStringProvider { get; }
        IDbContextInfoProvider ContextInfoProvider { get; }

        /* --------------------------- ExecuteReader ----------------------*/
        //                         generic methods
        //                              Non-Async methods
        DbResult<List<T>>       ExecuteReader<T>(IDbCommand cmd, Func<IDataReader, T> transform, object args = null);
        DbResult<List<T>>       ExecuteReader<T>(IDbCommand cmd, Func<IDataReader,T, T> transform, object args = null);
        DbResult<List<T>>       ExecuteReader<T>(string cmd, Func<IDataReader, T> transform, object args = null);
        DbResult<List<T>>       ExecuteReader<T>(string cmd, Func<IDataReader, T, T> transform, object args = null);
        //                              Async methods
        Task<DbResult<List<T>>> ExecuteReaderAsync<T>(IDbCommand cmd, Func<IDataReader, T> transform, object args = null);
        Task<DbResult<List<T>>> ExecuteReaderAsync<T>(IDbCommand cmd, Func<IDataReader, T> transform, object args, CancellationToken cancellation);
        Task<DbResult<List<T>>> ExecuteReaderAsync<T>(IDbCommand cmd, Func<IDataReader, T, T> transform, object args = null);
        Task<DbResult<List<T>>> ExecuteReaderAsync<T>(IDbCommand cmd, Func<IDataReader, T, T> transform, object args, CancellationToken cancellation);
        Task<DbResult<List<T>>> ExecuteReaderAsync<T>(string cmd, Func<IDataReader, T> transform, object args = null);
        Task<DbResult<List<T>>> ExecuteReaderAsync<T>(string cmd, Func<IDataReader, T> transform, object args, CancellationToken cancellation);
        //                         non-generic methods
        //                              Non-Async methods
        DbResult<List<object>> ExecuteReader(IDbCommand cmd, Func<IDataReader, object> transform, object args = null);
        DbResult<List<object>> ExecuteReader(IDbCommand cmd, Func<IDataReader, object, object> transform, object args = null);
        DbResult<List<object>> ExecuteReader(string cmd, Func<IDataReader, object> transform, object args = null);
        DbResult<List<object>> ExecuteReader(string cmd, Func<IDataReader, object, object> transform, object args = null);
        //                              Async methods
        Task<DbResult<List<object>>> ExecuteReaderAsync(IDbCommand cmd, Func<IDataReader, object> transform, object args = null);
        Task<DbResult<List<object>>> ExecuteReaderAsync(IDbCommand cmd, Func<IDataReader, object> transform, object args, CancellationToken cancellation);
        Task<DbResult<List<object>>> ExecuteReaderAsync(IDbCommand cmd, Func<IDataReader, object, object> transform, object args = null);
        Task<DbResult<List<object>>> ExecuteReaderAsync(IDbCommand cmd, Func<IDataReader, object, object> transform, object args, CancellationToken cancellation);
        Task<DbResult<List<object>>> ExecuteReaderAsync(string cmd, Func<IDataReader, object> transform, object args = null);
        Task<DbResult<List<object>>> ExecuteReaderAsync(string cmd, Func<IDataReader, object> transform, object args, CancellationToken cancellation);
        Task<DbResult<List<object>>> ExecuteReaderAsync(string cmd, Func<IDataReader, object, object> transform, object args = null);
        Task<DbResult<List<object>>> ExecuteReaderAsync(string cmd, Func<IDataReader, object, object> transform, object args, CancellationToken cancellation);
        /* --------------------------- ExecuteReader ----------------------*/
        /* --------------------------- ExecuteTable ----------------------*/
        DbResult<DataTable> ExecuteTable(IDbCommand cmd, object args = null, string tableName = "table");
        DbResult<List<T>> ExecuteTable<T>(IDbCommand cmd, Func<DataRow, T> transform, object args = null, string tableName = "table");

        DbResult<List<T>> ExecuteTable<T>(IDbCommand cmd, Func<DataColumnCollection, DataRow, T> transform, object args = null, string tableName = "table");
        DbResult<DataTable> ExecuteTable(string cmd, object args = null, string tableName = "table");
        /* --------------------------- ExecuteTable ----------------------*/
        /* --------------------------- dynamic ----------------------*/
        DbResult<List<object>> ExecuteTableDynamic(IDbCommand cmd, object args = null, string tableName = "table");
        DbResult<List<object>> ExecuteReaderDynamic(IDbCommand cmd, object args = null);
        DbResult<SchemaBasedList> ExecuteReaderSchemaDynamic(IDbCommand cmd, object args = null);
        Task<DbResult<SchemaBasedList>> ExecuteReaderSchemaDynamicAsync(IDbCommand cmd, object args = null);
        Task<DbResult<SchemaBasedList>> ExecuteReaderSchemaDynamicAsync(IDbCommand cmd, object args, CancellationToken cancellation);
        Task<DbResult<List<object>>> ExecuteReaderDynamicAsync(IDbCommand cmd, object args = null);
        Task<DbResult<List<object>>> ExecuteReaderDynamicAsync(IDbCommand cmd, object args, CancellationToken cancellation);
        /* --------------------------- dynamic ----------------------*/
        /* --------------------------- ExecuteScaler ----------------------*/
        DbResult<object> ExecuteScaler(IDbCommand cmd, object args = null);
        Task<DbResult<object>> ExecuteScalerAsync(IDbCommand cmd, object args = null);
        Task<DbResult<object>> ExecuteScalerAsync(IDbCommand cmd, object args, CancellationToken cancellation);

        DbResult<object> ExecuteScaler(string cmd, object args = null);
        Task<DbResult<object>> ExecuteScalerAsync(string cmd, object args = null);
        Task<DbResult<object>> ExecuteScalerAsync(string cmd, object args, CancellationToken cancellation);
        /* --------------------------- ExecuteScaler ----------------------*/
        /* --------------------------- ExecuteNonQuery ----------------------*/
        DbResult<int> ExecuteNonQuery(IDbCommand cmd, object args = null);
        Task<DbResult<int>> ExecuteNonQueryAsync(IDbCommand cmd, object args = null);
        Task<DbResult<int>> ExecuteNonQueryAsync(IDbCommand cmd, object args, CancellationToken cancellation);

        DbResult<int> ExecuteNonQuery(string cmd, object args = null);
        Task<DbResult<int>> ExecuteNonQueryAsync(string cmd, object args = null);
        Task<DbResult<int>> ExecuteNonQueryAsync(string cmd, object args, CancellationToken cancellation);
        /* --------------------------- ExecuteNonQuery ----------------------*/
        /* --------------------------- ExecuteSingle ----------------------*/
        DbResult<T> ExecuteSingle<T>(string sp, Func<DataRow, T> transform, object args = null) where T : class;
        DbResult<T> ExecuteSingle<T>(string sp, Func<IDataReader, T> transform, object args = null) where T : class;
        Task<DbResult<T>> ExecuteSingleAsync<T>(string sp, Func<IDataReader, T> transform, object args = null) where T : class;
        Task<DbResult<T>> ExecuteSingleAsync<T>(string sp, Func<IDataReader, T> transform, object args, CancellationToken cancellation) where T : class;
        DbResult<T> ExecuteSingle<T>(IDbCommand cmd, Func<DataRow, T> transform, object args = null) where T : class;
        DbResult<T> ExecuteSingle<T>(IDbCommand cmd, Func<IDataReader, T> transform, object args = null);// where T : class;
        DbResult<T> ExecuteSingle<T>(IDbCommand cmd, Func<IDataReader, T, T> transform, object args = null);// where T : class;
        Task<DbResult<T>> ExecuteSingleAsync<T>(IDbCommand cmd, Func<IDataReader, T> transform, object args = null);// where T : class;
        Task<DbResult<T>> ExecuteSingleAsync<T>(IDbCommand cmd, Func<IDataReader, T> transform, object args, CancellationToken cancellation);// where T : class;
        Task<DbResult<T>> ExecuteSingleAsync<T>(IDbCommand cmd, Func<IDataReader, T, T> transform, object args = null);// where T : class;
        Task<DbResult<T>> ExecuteSingleAsync<T>(IDbCommand cmd, Func<IDataReader, T, T> transform, object args, CancellationToken cancellation);// where T : class;
        /* --------------------------- ExecuteSingle ----------------------*/
        DbResult<int> ExecuteBatch(string batch);

        List<object> TestDB(string cnnStr, string sqlTest = "");
    }
}
