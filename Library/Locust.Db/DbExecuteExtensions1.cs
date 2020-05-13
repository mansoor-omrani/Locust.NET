using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Locust.Db
{
    public static class DbExecuteExtensions
    {
		public static List<T> ExecuteReaderCommand<T>(this IDb db, string sproc, Func<IDataReader, T> fn, IDictionary<string, object> parameters)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                cmd.Execute(result, fn);

                cmd.ApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
        public static T ExecuteSingleCommand<T>(this IDb db, string sproc, Func<IDataReader, T> fn, IDictionary<string, object> parameters)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                cmd.Execute(result, fn);

                cmd.ApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result.Count > 0 ? result[0]: default(T);
        }
		public static List<T> ExecuteReaderCommand<T>(this IDb db, string sproc, IDictionary<string, object> parameters)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                cmd.Execute(result);

                cmd.ApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
        public static T ExecuteSingleCommand<T>(this IDb db, string sproc, IDictionary<string, object> parameters)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                cmd.Execute(result);

                cmd.ApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result.Count > 0 ? result[0]: default(T);
        }
		public static int ExecuteNonQueryCommand(this IDb db, string sproc, IDictionary<string, object> parameters)
        {
            var result = -1;
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                var obj = cmd.Execute(false);
                
                result = (int)System.Convert.ChangeType(obj, typeof(System.Int32));

                cmd.ApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
		public static List<T> SafeExecuteReaderCommand<T>(this IDb db, string sproc, Func<IDataReader, T> fn, IDictionary<string, object> parameters)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                cmd.Execute(result, fn);

                cmd.SafeApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
        public static T SafeExecuteSingleCommand<T>(this IDb db, string sproc, Func<IDataReader, T> fn, IDictionary<string, object> parameters)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                cmd.Execute(result, fn);

                cmd.SafeApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result.Count > 0 ? result[0]: default(T);
        }
		public static List<T> SafeExecuteReaderCommand<T>(this IDb db, string sproc, IDictionary<string, object> parameters)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                cmd.Execute(result);

                cmd.SafeApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
        public static T SafeExecuteSingleCommand<T>(this IDb db, string sproc, IDictionary<string, object> parameters)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                cmd.Execute(result);

                cmd.SafeApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result.Count > 0 ? result[0]: default(T);
        }
		public static int SafeExecuteNonQueryCommand(this IDb db, string sproc, IDictionary<string, object> parameters)
        {
            var result = -1;
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                var obj = cmd.Execute(false);
                
                result = (int)System.Convert.ChangeType(obj, typeof(System.Int32));

                cmd.SafeApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
		public static List<T> ExecuteReaderCommand<T>(this IDb db, string sproc, Func<IDataReader, T> fn, object parameters = null)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                cmd.Execute(result, fn);

                cmd.ApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
        public static T ExecuteSingleCommand<T>(this IDb db, string sproc, Func<IDataReader, T> fn, object parameters = null)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                cmd.Execute(result, fn);

                cmd.ApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result.Count > 0 ? result[0]: default(T);
        }
		public static List<T> ExecuteReaderCommand<T>(this IDb db, string sproc, object parameters = null)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                cmd.Execute(result);

                cmd.ApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
        public static T ExecuteSingleCommand<T>(this IDb db, string sproc, object parameters = null)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                cmd.Execute(result);

                cmd.ApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result.Count > 0 ? result[0]: default(T);
        }
		public static int ExecuteNonQueryCommand(this IDb db, string sproc, object parameters = null)
        {
            var result = -1;
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                var obj = cmd.Execute(false);
                
                result = (int)System.Convert.ChangeType(obj, typeof(System.Int32));

                cmd.ApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
		public static List<T> SafeExecuteReaderCommand<T>(this IDb db, string sproc, Func<IDataReader, T> fn, object parameters = null)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                cmd.Execute(result, fn);

                cmd.SafeApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
        public static T SafeExecuteSingleCommand<T>(this IDb db, string sproc, Func<IDataReader, T> fn, object parameters = null)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                cmd.Execute(result, fn);

                cmd.SafeApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result.Count > 0 ? result[0]: default(T);
        }
		public static List<T> SafeExecuteReaderCommand<T>(this IDb db, string sproc, object parameters = null)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                cmd.Execute(result);

                cmd.SafeApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
        public static T SafeExecuteSingleCommand<T>(this IDb db, string sproc, object parameters = null)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                cmd.Execute(result);

                cmd.SafeApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result.Count > 0 ? result[0]: default(T);
        }
		public static int SafeExecuteNonQueryCommand(this IDb db, string sproc, object parameters = null)
        {
            var result = -1;
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                var obj = cmd.Execute(false);
                
                result = (int)System.Convert.ChangeType(obj, typeof(System.Int32));

                cmd.SafeApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
		public static List<T> ExecuteReaderSql<T>(this IDb db, string sql, Func<IDataReader, T> fn, IDictionary<string, object> parameters)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                cmd.Execute(result, fn);

                cmd.ApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
        public static T ExecuteSingleSql<T>(this IDb db, string sql, Func<IDataReader, T> fn, IDictionary<string, object> parameters)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                cmd.Execute(result, fn);

                cmd.ApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result.Count > 0 ? result[0]: default(T);
        }
		public static List<T> ExecuteReaderSql<T>(this IDb db, string sql, IDictionary<string, object> parameters)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                cmd.Execute(result);

                cmd.ApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
        public static T ExecuteSingleSql<T>(this IDb db, string sql, IDictionary<string, object> parameters)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                cmd.Execute(result);

                cmd.ApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result.Count > 0 ? result[0]: default(T);
        }
		public static int ExecuteNonQuerySql(this IDb db, string sql, IDictionary<string, object> parameters)
        {
            var result = -1;
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                var obj = cmd.Execute(false);
                
                result = (int)System.Convert.ChangeType(obj, typeof(System.Int32));

                cmd.ApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
		public static List<T> SafeExecuteReaderSql<T>(this IDb db, string sql, Func<IDataReader, T> fn, IDictionary<string, object> parameters)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                cmd.Execute(result, fn);

                cmd.SafeApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
        public static T SafeExecuteSingleSql<T>(this IDb db, string sql, Func<IDataReader, T> fn, IDictionary<string, object> parameters)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                cmd.Execute(result, fn);

                cmd.SafeApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result.Count > 0 ? result[0]: default(T);
        }
		public static List<T> SafeExecuteReaderSql<T>(this IDb db, string sql, IDictionary<string, object> parameters)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                cmd.Execute(result);

                cmd.SafeApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
        public static T SafeExecuteSingleSql<T>(this IDb db, string sql, IDictionary<string, object> parameters)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                cmd.Execute(result);

                cmd.SafeApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result.Count > 0 ? result[0]: default(T);
        }
		public static int SafeExecuteNonQuerySql(this IDb db, string sql, IDictionary<string, object> parameters)
        {
            var result = -1;
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                var obj = cmd.Execute(false);
                
                result = (int)System.Convert.ChangeType(obj, typeof(System.Int32));

                cmd.SafeApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
		public static List<T> ExecuteReaderSql<T>(this IDb db, string sql, Func<IDataReader, T> fn, object parameters = null)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                cmd.Execute(result, fn);

                cmd.ApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
        public static T ExecuteSingleSql<T>(this IDb db, string sql, Func<IDataReader, T> fn, object parameters = null)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                cmd.Execute(result, fn);

                cmd.ApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result.Count > 0 ? result[0]: default(T);
        }
		public static List<T> ExecuteReaderSql<T>(this IDb db, string sql, object parameters = null)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                cmd.Execute(result);

                cmd.ApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
        public static T ExecuteSingleSql<T>(this IDb db, string sql, object parameters = null)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                cmd.Execute(result);

                cmd.ApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result.Count > 0 ? result[0]: default(T);
        }
		public static int ExecuteNonQuerySql(this IDb db, string sql, object parameters = null)
        {
            var result = -1;
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                var obj = cmd.Execute(false);
                
                result = (int)System.Convert.ChangeType(obj, typeof(System.Int32));

                cmd.ApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
		public static List<T> SafeExecuteReaderSql<T>(this IDb db, string sql, Func<IDataReader, T> fn, object parameters = null)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                cmd.Execute(result, fn);

                cmd.SafeApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
        public static T SafeExecuteSingleSql<T>(this IDb db, string sql, Func<IDataReader, T> fn, object parameters = null)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                cmd.Execute(result, fn);

                cmd.SafeApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result.Count > 0 ? result[0]: default(T);
        }
		public static List<T> SafeExecuteReaderSql<T>(this IDb db, string sql, object parameters = null)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                cmd.Execute(result);

                cmd.SafeApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
        public static T SafeExecuteSingleSql<T>(this IDb db, string sql, object parameters = null)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                cmd.Execute(result);

                cmd.SafeApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result.Count > 0 ? result[0]: default(T);
        }
		public static int SafeExecuteNonQuerySql(this IDb db, string sql, object parameters = null)
        {
            var result = -1;
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                var obj = cmd.Execute(false);
                
                result = (int)System.Convert.ChangeType(obj, typeof(System.Int32));

                cmd.SafeApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
		public static async Task<List<T>> ExecuteReaderCommandAsync<T>(this IDb db, string sproc, Func<IDataReader, T> fn, IDictionary<string, object> parameters, CancellationToken cancellation)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                await cmd.ExecuteAsync(result, fn, cancellation);

                cmd.ApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
        public static async Task<T> ExecuteSingleCommandAsync<T>(this IDb db, string sproc, Func<IDataReader, T> fn, IDictionary<string, object> parameters, CancellationToken cancellation)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                await cmd.ExecuteAsync(result, fn, cancellation);

                cmd.ApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result.Count > 0 ? result[0]: default(T);
        }
		public static Task<List<T>> ExecuteReaderCommandAsync<T>(this IDb db, string sproc, Func<IDataReader, T> fn, IDictionary<string, object> parameters = null)
        {
            return db.ExecuteReaderCommandAsync<T>(sproc, fn, parameters, CancellationToken.None);
        }
        public static Task<T> ExecuteSingleCommandAsync<T>(this IDb db, string sproc, Func<IDataReader, T> fn, IDictionary<string, object> parameters = null)
        {
            return db.ExecuteSingleCommandAsync<T>(sproc, fn, parameters, CancellationToken.None);
        }
		public static async Task<List<T>> ExecuteReaderCommandAsync<T>(this IDb db, string sproc, IDictionary<string, object> parameters, CancellationToken cancellation)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                await cmd.ExecuteAsync(result, cancellation);

                cmd.ApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
        public static async Task<T> ExecuteSingleCommandAsync<T>(this IDb db, string sproc, IDictionary<string, object> parameters, CancellationToken cancellation)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                await cmd.ExecuteAsync(result, cancellation);

                cmd.ApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result.Count > 0 ? result[0]: default(T);
        }
		public static Task<List<T>> ExecuteReaderCommandAsync<T>(this IDb db, string sproc, IDictionary<string, object> parameters = null)
        {
            return db.ExecuteReaderCommandAsync<T>(sproc, parameters, CancellationToken.None);
        }
        public static Task<T> ExecuteSingleCommandAsync<T>(this IDb db, string sproc, IDictionary<string, object> parameters = null)
        {
            return db.ExecuteSingleCommandAsync<T>(sproc, parameters, CancellationToken.None);
        }
		public static async Task<int> ExecuteNonQueryCommandAsync(this IDb db, string sproc, IDictionary<string, object> parameters, CancellationToken cancellation)
        {
            var result = -1;
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                var obj = await cmd.ExecuteAsync(false,cancellation);
                
                result = (int)System.Convert.ChangeType(obj, typeof(System.Int32));

                cmd.ApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
		public static Task<int> ExecuteNonQueryCommandAsync(this IDb db, string sproc, IDictionary<string, object> parameters = null)
        {
            return db.ExecuteNonQueryCommandAsync(sproc, parameters, CancellationToken.None);
        }
		public static async Task<List<T>> SafeExecuteReaderCommandAsync<T>(this IDb db, string sproc, Func<IDataReader, T> fn, IDictionary<string, object> parameters, CancellationToken cancellation)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                await cmd.ExecuteAsync(result, fn, cancellation);

                cmd.SafeApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
        public static async Task<T> SafeExecuteSingleCommandAsync<T>(this IDb db, string sproc, Func<IDataReader, T> fn, IDictionary<string, object> parameters, CancellationToken cancellation)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                await cmd.ExecuteAsync(result, fn, cancellation);

                cmd.SafeApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result.Count > 0 ? result[0]: default(T);
        }
		public static Task<List<T>> SafeExecuteReaderCommandAsync<T>(this IDb db, string sproc, Func<IDataReader, T> fn, IDictionary<string, object> parameters = null)
        {
            return db.SafeExecuteReaderCommandAsync<T>(sproc, fn, parameters, CancellationToken.None);
        }
        public static Task<T> SafeExecuteSingleCommandAsync<T>(this IDb db, string sproc, Func<IDataReader, T> fn, IDictionary<string, object> parameters = null)
        {
            return db.SafeExecuteSingleCommandAsync<T>(sproc, fn, parameters, CancellationToken.None);
        }
		public static async Task<List<T>> SafeExecuteReaderCommandAsync<T>(this IDb db, string sproc, IDictionary<string, object> parameters, CancellationToken cancellation)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                await cmd.ExecuteAsync(result, cancellation);

                cmd.SafeApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
        public static async Task<T> SafeExecuteSingleCommandAsync<T>(this IDb db, string sproc, IDictionary<string, object> parameters, CancellationToken cancellation)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                await cmd.ExecuteAsync(result, cancellation);

                cmd.SafeApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result.Count > 0 ? result[0]: default(T);
        }
		public static Task<List<T>> SafeExecuteReaderCommandAsync<T>(this IDb db, string sproc, IDictionary<string, object> parameters = null)
        {
            return db.SafeExecuteReaderCommandAsync<T>(sproc, parameters, CancellationToken.None);
        }
        public static Task<T> SafeExecuteSingleCommandAsync<T>(this IDb db, string sproc, IDictionary<string, object> parameters = null)
        {
            return db.SafeExecuteSingleCommandAsync<T>(sproc, parameters, CancellationToken.None);
        }
		public static async Task<int> SafeExecuteNonQueryCommandAsync(this IDb db, string sproc, IDictionary<string, object> parameters, CancellationToken cancellation)
        {
            var result = -1;
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                var obj = await cmd.ExecuteAsync(false,cancellation);
                
                result = (int)System.Convert.ChangeType(obj, typeof(System.Int32));

                cmd.SafeApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
		public static Task<int> SafeExecuteNonQueryCommandAsync(this IDb db, string sproc, IDictionary<string, object> parameters = null)
        {
            return db.SafeExecuteNonQueryCommandAsync(sproc, parameters, CancellationToken.None);
        }
		public static async Task<List<T>> ExecuteReaderCommandAsync<T>(this IDb db, string sproc, Func<IDataReader, T> fn, object parameters, CancellationToken cancellation)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                await cmd.ExecuteAsync(result, fn, cancellation);

                cmd.ApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
        public static async Task<T> ExecuteSingleCommandAsync<T>(this IDb db, string sproc, Func<IDataReader, T> fn, object parameters, CancellationToken cancellation)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                await cmd.ExecuteAsync(result, fn, cancellation);

                cmd.ApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result.Count > 0 ? result[0]: default(T);
        }
		public static Task<List<T>> ExecuteReaderCommandAsync<T>(this IDb db, string sproc, Func<IDataReader, T> fn, object parameters = null)
        {
            return db.ExecuteReaderCommandAsync<T>(sproc, fn, parameters, CancellationToken.None);
        }
        public static Task<T> ExecuteSingleCommandAsync<T>(this IDb db, string sproc, Func<IDataReader, T> fn, object parameters = null)
        {
            return db.ExecuteSingleCommandAsync<T>(sproc, fn, parameters, CancellationToken.None);
        }
		public static async Task<List<T>> ExecuteReaderCommandAsync<T>(this IDb db, string sproc, object parameters, CancellationToken cancellation)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                await cmd.ExecuteAsync(result, cancellation);

                cmd.ApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
        public static async Task<T> ExecuteSingleCommandAsync<T>(this IDb db, string sproc, object parameters, CancellationToken cancellation)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                await cmd.ExecuteAsync(result, cancellation);

                cmd.ApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result.Count > 0 ? result[0]: default(T);
        }
		public static Task<List<T>> ExecuteReaderCommandAsync<T>(this IDb db, string sproc, object parameters = null)
        {
            return db.ExecuteReaderCommandAsync<T>(sproc, parameters, CancellationToken.None);
        }
        public static Task<T> ExecuteSingleCommandAsync<T>(this IDb db, string sproc, object parameters = null)
        {
            return db.ExecuteSingleCommandAsync<T>(sproc, parameters, CancellationToken.None);
        }
		public static async Task<int> ExecuteNonQueryCommandAsync(this IDb db, string sproc, object parameters, CancellationToken cancellation)
        {
            var result = -1;
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                var obj = await cmd.ExecuteAsync(false,cancellation);
                
                result = (int)System.Convert.ChangeType(obj, typeof(System.Int32));

                cmd.ApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
		public static Task<int> ExecuteNonQueryCommandAsync(this IDb db, string sproc, object parameters = null)
        {
            return db.ExecuteNonQueryCommandAsync(sproc, parameters, CancellationToken.None);
        }
		public static async Task<List<T>> SafeExecuteReaderCommandAsync<T>(this IDb db, string sproc, Func<IDataReader, T> fn, object parameters, CancellationToken cancellation)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                await cmd.ExecuteAsync(result, fn, cancellation);

                cmd.SafeApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
        public static async Task<T> SafeExecuteSingleCommandAsync<T>(this IDb db, string sproc, Func<IDataReader, T> fn, object parameters, CancellationToken cancellation)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                await cmd.ExecuteAsync(result, fn, cancellation);

                cmd.SafeApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result.Count > 0 ? result[0]: default(T);
        }
		public static Task<List<T>> SafeExecuteReaderCommandAsync<T>(this IDb db, string sproc, Func<IDataReader, T> fn, object parameters = null)
        {
            return db.SafeExecuteReaderCommandAsync<T>(sproc, fn, parameters, CancellationToken.None);
        }
        public static Task<T> SafeExecuteSingleCommandAsync<T>(this IDb db, string sproc, Func<IDataReader, T> fn, object parameters = null)
        {
            return db.SafeExecuteSingleCommandAsync<T>(sproc, fn, parameters, CancellationToken.None);
        }
		public static async Task<List<T>> SafeExecuteReaderCommandAsync<T>(this IDb db, string sproc, object parameters, CancellationToken cancellation)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                await cmd.ExecuteAsync(result, cancellation);

                cmd.SafeApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
        public static async Task<T> SafeExecuteSingleCommandAsync<T>(this IDb db, string sproc, object parameters, CancellationToken cancellation)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                await cmd.ExecuteAsync(result, cancellation);

                cmd.SafeApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result.Count > 0 ? result[0]: default(T);
        }
		public static Task<List<T>> SafeExecuteReaderCommandAsync<T>(this IDb db, string sproc, object parameters = null)
        {
            return db.SafeExecuteReaderCommandAsync<T>(sproc, parameters, CancellationToken.None);
        }
        public static Task<T> SafeExecuteSingleCommandAsync<T>(this IDb db, string sproc, object parameters = null)
        {
            return db.SafeExecuteSingleCommandAsync<T>(sproc, parameters, CancellationToken.None);
        }
		public static async Task<int> SafeExecuteNonQueryCommandAsync(this IDb db, string sproc, object parameters, CancellationToken cancellation)
        {
            var result = -1;
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                var obj = await cmd.ExecuteAsync(false,cancellation);
                
                result = (int)System.Convert.ChangeType(obj, typeof(System.Int32));

                cmd.SafeApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
		public static Task<int> SafeExecuteNonQueryCommandAsync(this IDb db, string sproc, object parameters = null)
        {
            return db.SafeExecuteNonQueryCommandAsync(sproc, parameters, CancellationToken.None);
        }
		public static async Task<List<T>> ExecuteReaderSqlAsync<T>(this IDb db, string sql, Func<IDataReader, T> fn, IDictionary<string, object> parameters, CancellationToken cancellation)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                await cmd.ExecuteAsync(result, fn, cancellation);

                cmd.ApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
        public static async Task<T> ExecuteSingleSqlAsync<T>(this IDb db, string sql, Func<IDataReader, T> fn, IDictionary<string, object> parameters, CancellationToken cancellation)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                await cmd.ExecuteAsync(result, fn, cancellation);

                cmd.ApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result.Count > 0 ? result[0]: default(T);
        }
		public static Task<List<T>> ExecuteReaderSqlAsync<T>(this IDb db, string sql, Func<IDataReader, T> fn, IDictionary<string, object> parameters = null)
        {
            return db.ExecuteReaderSqlAsync<T>(sql, fn, parameters, CancellationToken.None);
        }
        public static Task<T> ExecuteSingleSqlAsync<T>(this IDb db, string sql, Func<IDataReader, T> fn, IDictionary<string, object> parameters = null)
        {
            return db.ExecuteSingleSqlAsync<T>(sql, fn, parameters, CancellationToken.None);
        }
		public static async Task<List<T>> ExecuteReaderSqlAsync<T>(this IDb db, string sql, IDictionary<string, object> parameters, CancellationToken cancellation)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                await cmd.ExecuteAsync(result, cancellation);

                cmd.ApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
        public static async Task<T> ExecuteSingleSqlAsync<T>(this IDb db, string sql, IDictionary<string, object> parameters, CancellationToken cancellation)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                await cmd.ExecuteAsync(result, cancellation);

                cmd.ApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result.Count > 0 ? result[0]: default(T);
        }
		public static Task<List<T>> ExecuteReaderSqlAsync<T>(this IDb db, string sql, IDictionary<string, object> parameters = null)
        {
            return db.ExecuteReaderSqlAsync<T>(sql, parameters, CancellationToken.None);
        }
        public static Task<T> ExecuteSingleSqlAsync<T>(this IDb db, string sql, IDictionary<string, object> parameters = null)
        {
            return db.ExecuteSingleSqlAsync<T>(sql, parameters, CancellationToken.None);
        }
		public static async Task<int> ExecuteNonQuerySqlAsync(this IDb db, string sql, IDictionary<string, object> parameters, CancellationToken cancellation)
        {
            var result = -1;
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                var obj = await cmd.ExecuteAsync(false,cancellation);
                
                result = (int)System.Convert.ChangeType(obj, typeof(System.Int32));

                cmd.ApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
		public static Task<int> ExecuteNonQuerySqlAsync(this IDb db, string sql, IDictionary<string, object> parameters = null)
        {
            return db.ExecuteNonQuerySqlAsync(sql, parameters, CancellationToken.None);
        }
		public static async Task<List<T>> SafeExecuteReaderSqlAsync<T>(this IDb db, string sql, Func<IDataReader, T> fn, IDictionary<string, object> parameters, CancellationToken cancellation)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                await cmd.ExecuteAsync(result, fn, cancellation);

                cmd.SafeApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
        public static async Task<T> SafeExecuteSingleSqlAsync<T>(this IDb db, string sql, Func<IDataReader, T> fn, IDictionary<string, object> parameters, CancellationToken cancellation)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                await cmd.ExecuteAsync(result, fn, cancellation);

                cmd.SafeApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result.Count > 0 ? result[0]: default(T);
        }
		public static Task<List<T>> SafeExecuteReaderSqlAsync<T>(this IDb db, string sql, Func<IDataReader, T> fn, IDictionary<string, object> parameters = null)
        {
            return db.SafeExecuteReaderSqlAsync<T>(sql, fn, parameters, CancellationToken.None);
        }
        public static Task<T> SafeExecuteSingleSqlAsync<T>(this IDb db, string sql, Func<IDataReader, T> fn, IDictionary<string, object> parameters = null)
        {
            return db.SafeExecuteSingleSqlAsync<T>(sql, fn, parameters, CancellationToken.None);
        }
		public static async Task<List<T>> SafeExecuteReaderSqlAsync<T>(this IDb db, string sql, IDictionary<string, object> parameters, CancellationToken cancellation)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                await cmd.ExecuteAsync(result, cancellation);

                cmd.SafeApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
        public static async Task<T> SafeExecuteSingleSqlAsync<T>(this IDb db, string sql, IDictionary<string, object> parameters, CancellationToken cancellation)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                await cmd.ExecuteAsync(result, cancellation);

                cmd.SafeApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result.Count > 0 ? result[0]: default(T);
        }
		public static Task<List<T>> SafeExecuteReaderSqlAsync<T>(this IDb db, string sql, IDictionary<string, object> parameters = null)
        {
            return db.SafeExecuteReaderSqlAsync<T>(sql, parameters, CancellationToken.None);
        }
        public static Task<T> SafeExecuteSingleSqlAsync<T>(this IDb db, string sql, IDictionary<string, object> parameters = null)
        {
            return db.SafeExecuteSingleSqlAsync<T>(sql, parameters, CancellationToken.None);
        }
		public static async Task<int> SafeExecuteNonQuerySqlAsync(this IDb db, string sql, IDictionary<string, object> parameters, CancellationToken cancellation)
        {
            var result = -1;
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                var obj = await cmd.ExecuteAsync(false,cancellation);
                
                result = (int)System.Convert.ChangeType(obj, typeof(System.Int32));

                cmd.SafeApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
		public static Task<int> SafeExecuteNonQuerySqlAsync(this IDb db, string sql, IDictionary<string, object> parameters = null)
        {
            return db.SafeExecuteNonQuerySqlAsync(sql, parameters, CancellationToken.None);
        }
		public static async Task<List<T>> ExecuteReaderSqlAsync<T>(this IDb db, string sql, Func<IDataReader, T> fn, object parameters, CancellationToken cancellation)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                await cmd.ExecuteAsync(result, fn, cancellation);

                cmd.ApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
        public static async Task<T> ExecuteSingleSqlAsync<T>(this IDb db, string sql, Func<IDataReader, T> fn, object parameters, CancellationToken cancellation)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                await cmd.ExecuteAsync(result, fn, cancellation);

                cmd.ApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result.Count > 0 ? result[0]: default(T);
        }
		public static Task<List<T>> ExecuteReaderSqlAsync<T>(this IDb db, string sql, Func<IDataReader, T> fn, object parameters = null)
        {
            return db.ExecuteReaderSqlAsync<T>(sql, fn, parameters, CancellationToken.None);
        }
        public static Task<T> ExecuteSingleSqlAsync<T>(this IDb db, string sql, Func<IDataReader, T> fn, object parameters = null)
        {
            return db.ExecuteSingleSqlAsync<T>(sql, fn, parameters, CancellationToken.None);
        }
		public static async Task<List<T>> ExecuteReaderSqlAsync<T>(this IDb db, string sql, object parameters, CancellationToken cancellation)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                await cmd.ExecuteAsync(result, cancellation);

                cmd.ApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
        public static async Task<T> ExecuteSingleSqlAsync<T>(this IDb db, string sql, object parameters, CancellationToken cancellation)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                await cmd.ExecuteAsync(result, cancellation);

                cmd.ApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result.Count > 0 ? result[0]: default(T);
        }
		public static Task<List<T>> ExecuteReaderSqlAsync<T>(this IDb db, string sql, object parameters = null)
        {
            return db.ExecuteReaderSqlAsync<T>(sql, parameters, CancellationToken.None);
        }
        public static Task<T> ExecuteSingleSqlAsync<T>(this IDb db, string sql, object parameters = null)
        {
            return db.ExecuteSingleSqlAsync<T>(sql, parameters, CancellationToken.None);
        }
		public static async Task<int> ExecuteNonQuerySqlAsync(this IDb db, string sql, object parameters, CancellationToken cancellation)
        {
            var result = -1;
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                var obj = await cmd.ExecuteAsync(false,cancellation);
                
                result = (int)System.Convert.ChangeType(obj, typeof(System.Int32));

                cmd.ApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
		public static Task<int> ExecuteNonQuerySqlAsync(this IDb db, string sql, object parameters = null)
        {
            return db.ExecuteNonQuerySqlAsync(sql, parameters, CancellationToken.None);
        }
		public static async Task<List<T>> SafeExecuteReaderSqlAsync<T>(this IDb db, string sql, Func<IDataReader, T> fn, object parameters, CancellationToken cancellation)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                await cmd.ExecuteAsync(result, fn, cancellation);

                cmd.SafeApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
        public static async Task<T> SafeExecuteSingleSqlAsync<T>(this IDb db, string sql, Func<IDataReader, T> fn, object parameters, CancellationToken cancellation)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                await cmd.ExecuteAsync(result, fn, cancellation);

                cmd.SafeApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result.Count > 0 ? result[0]: default(T);
        }
		public static Task<List<T>> SafeExecuteReaderSqlAsync<T>(this IDb db, string sql, Func<IDataReader, T> fn, object parameters = null)
        {
            return db.SafeExecuteReaderSqlAsync<T>(sql, fn, parameters, CancellationToken.None);
        }
        public static Task<T> SafeExecuteSingleSqlAsync<T>(this IDb db, string sql, Func<IDataReader, T> fn, object parameters = null)
        {
            return db.SafeExecuteSingleSqlAsync<T>(sql, fn, parameters, CancellationToken.None);
        }
		public static async Task<List<T>> SafeExecuteReaderSqlAsync<T>(this IDb db, string sql, object parameters, CancellationToken cancellation)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                await cmd.ExecuteAsync(result, cancellation);

                cmd.SafeApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
        public static async Task<T> SafeExecuteSingleSqlAsync<T>(this IDb db, string sql, object parameters, CancellationToken cancellation)
        {
            var result = new List<T>();
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                await cmd.ExecuteAsync(result, cancellation);

                cmd.SafeApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result.Count > 0 ? result[0]: default(T);
        }
		public static Task<List<T>> SafeExecuteReaderSqlAsync<T>(this IDb db, string sql, object parameters = null)
        {
            return db.SafeExecuteReaderSqlAsync<T>(sql, parameters, CancellationToken.None);
        }
        public static Task<T> SafeExecuteSingleSqlAsync<T>(this IDb db, string sql, object parameters = null)
        {
            return db.SafeExecuteSingleSqlAsync<T>(sql, parameters, CancellationToken.None);
        }
		public static async Task<int> SafeExecuteNonQuerySqlAsync(this IDb db, string sql, object parameters, CancellationToken cancellation)
        {
            var result = -1;
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                var obj = await cmd.ExecuteAsync(false,cancellation);
                
                result = (int)System.Convert.ChangeType(obj, typeof(System.Int32));

                cmd.SafeApplyOutputs(parameters);
                
				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
		public static Task<int> SafeExecuteNonQuerySqlAsync(this IDb db, string sql, object parameters = null)
        {
            return db.SafeExecuteNonQuerySqlAsync(sql, parameters, CancellationToken.None);
        }


		public static object ExecuteScalerCommand(this IDb db, string sproc, IDictionary<string, object> parameters)
        {
            object result = null;
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                result = cmd.Execute(true);

                cmd.ApplyOutputs(parameters);

				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
		public static object SafeExecuteScalerCommand(this IDb db, string sproc, IDictionary<string, object> parameters)
        {
            object result = null;
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                result = cmd.Execute(true);

                cmd.SafeApplyOutputs(parameters);

				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
		public static object ExecuteScalerCommand(this IDb db, string sproc, object parameters = null)
        {
            object result = null;
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                result = cmd.Execute(true);

                cmd.ApplyOutputs(parameters);

				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
		public static object SafeExecuteScalerCommand(this IDb db, string sproc, object parameters = null)
        {
            object result = null;
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                result = cmd.Execute(true);

                cmd.SafeApplyOutputs(parameters);

				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
		public static object ExecuteScalerSql(this IDb db, string sql, IDictionary<string, object> parameters)
        {
            object result = null;
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                result = cmd.Execute(true);

                cmd.ApplyOutputs(parameters);

				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
		public static object SafeExecuteScalerSql(this IDb db, string sql, IDictionary<string, object> parameters)
        {
            object result = null;
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                result = cmd.Execute(true);

                cmd.SafeApplyOutputs(parameters);

				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
		public static object ExecuteScalerSql(this IDb db, string sql, object parameters = null)
        {
            object result = null;
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                result = cmd.Execute(true);

                cmd.ApplyOutputs(parameters);

				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
		public static object SafeExecuteScalerSql(this IDb db, string sql, object parameters = null)
        {
            object result = null;
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                result = cmd.Execute(true);

                cmd.SafeApplyOutputs(parameters);

				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
		public static async Task<object> ExecuteScalerCommandAsync(this IDb db, string sproc, IDictionary<string, object> parameters, CancellationToken cancellation)
        {
            object result = null;
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                result = await cmd.ExecuteAsync(true, cancellation);

                cmd.ApplyOutputs(parameters);

				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
		public static Task<object> ExecuteScalerCommandAsync(this IDb db, string sproc, IDictionary<string, object> parameters = null)
        {
            return db.ExecuteScalerCommandAsync(sproc, parameters, CancellationToken.None);
        }
		public static async Task<object> SafeExecuteScalerCommandAsync(this IDb db, string sproc, IDictionary<string, object> parameters, CancellationToken cancellation)
        {
            object result = null;
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                result = await cmd.ExecuteAsync(true, cancellation);

                cmd.SafeApplyOutputs(parameters);

				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
		public static Task<object> SafeExecuteScalerCommandAsync(this IDb db, string sproc, IDictionary<string, object> parameters = null)
        {
            return db.SafeExecuteScalerCommandAsync(sproc, parameters, CancellationToken.None);
        }
		public static async Task<object> ExecuteScalerCommandAsync(this IDb db, string sproc, object parameters, CancellationToken cancellation)
        {
            object result = null;
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                result = await cmd.ExecuteAsync(true, cancellation);

                cmd.ApplyOutputs(parameters);

				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
		public static Task<object> ExecuteScalerCommandAsync(this IDb db, string sproc, object parameters = null)
        {
            return db.ExecuteScalerCommandAsync(sproc, parameters, CancellationToken.None);
        }
		public static async Task<object> SafeExecuteScalerCommandAsync(this IDb db, string sproc, object parameters, CancellationToken cancellation)
        {
            object result = null;
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sproc, CommandType.StoredProcedure, parameters, db.AutoNullEmptyStrings);

                result = await cmd.ExecuteAsync(true, cancellation);

                cmd.SafeApplyOutputs(parameters);

				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
		public static Task<object> SafeExecuteScalerCommandAsync(this IDb db, string sproc, object parameters = null)
        {
            return db.SafeExecuteScalerCommandAsync(sproc, parameters, CancellationToken.None);
        }
		public static async Task<object> ExecuteScalerSqlAsync(this IDb db, string sql, IDictionary<string, object> parameters, CancellationToken cancellation)
        {
            object result = null;
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                result = await cmd.ExecuteAsync(true, cancellation);

                cmd.ApplyOutputs(parameters);

				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
		public static Task<object> ExecuteScalerSqlAsync(this IDb db, string sql, IDictionary<string, object> parameters = null)
        {
            return db.ExecuteScalerSqlAsync(sql, parameters, CancellationToken.None);
        }
		public static async Task<object> SafeExecuteScalerSqlAsync(this IDb db, string sql, IDictionary<string, object> parameters, CancellationToken cancellation)
        {
            object result = null;
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                result = await cmd.ExecuteAsync(true, cancellation);

                cmd.SafeApplyOutputs(parameters);

				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
		public static Task<object> SafeExecuteScalerSqlAsync(this IDb db, string sql, IDictionary<string, object> parameters = null)
        {
            return db.SafeExecuteScalerSqlAsync(sql, parameters, CancellationToken.None);
        }
		public static async Task<object> ExecuteScalerSqlAsync(this IDb db, string sql, object parameters, CancellationToken cancellation)
        {
            object result = null;
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                result = await cmd.ExecuteAsync(true, cancellation);

                cmd.ApplyOutputs(parameters);

				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
		public static Task<object> ExecuteScalerSqlAsync(this IDb db, string sql, object parameters = null)
        {
            return db.ExecuteScalerSqlAsync(sql, parameters, CancellationToken.None);
        }
		public static async Task<object> SafeExecuteScalerSqlAsync(this IDb db, string sql, object parameters, CancellationToken cancellation)
        {
            object result = null;
            var con = db.GetConnection();

            if (con != null)
            {
                var cmd = con.CreateCommand(sql, CommandType.Text, parameters, db.AutoNullEmptyStrings);

                result = await cmd.ExecuteAsync(true, cancellation);

                cmd.SafeApplyOutputs(parameters);

				if (!db.PersistConnection)
				{
					con.Dispose();
				}
            }

            return result;
        }
		public static Task<object> SafeExecuteScalerSqlAsync(this IDb db, string sql, object parameters = null)
        {
            return db.SafeExecuteScalerSqlAsync(sql, parameters, CancellationToken.None);
        }
	}
}
