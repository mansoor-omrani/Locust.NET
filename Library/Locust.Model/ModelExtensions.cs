using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Locust.Db;
using Locust.Extensions;
using Locust.ModelField;

namespace Locust.Model
{
    public enum RequestValues
    {
        All,
        Querystring,
        Form
    }
    public static class ModelExtensions
    {
        public static ModelValues Values(this IDataRecord row)
        {
            var result = new ModelValues();

            for (int i = 0; i < row.FieldCount; i++)
            {
                result.Add(row.GetName(i), row[i]);
            }

            return result;
        }
        public static ModelValues Values(this DataRow row)
        {
            var result = new ModelValues();

            var dt = row.Table;
            foreach (DataColumn col in dt.Columns)
            {
                result.Add(col.ColumnName, row[col.ColumnName]);
            }

            return result;
        }

        public static ModelValues Values(this HttpRequestBase request, RequestValues source = RequestValues.All)
        {
            var result = new ModelValues();

            if (source == RequestValues.All || source == RequestValues.Querystring)
            {
                foreach (string qs in request.QueryString)
                {
                    result.Add(qs, request.QueryString[qs]);
                }
            }

            if (source == RequestValues.All || source == RequestValues.Form)
            {
                foreach (string qs in request.Form)
                {
                    result.Add(qs, request.Form[qs]);
                }
            }

            return result;
        }

        public static ModelValues Values(this HttpRequest request, RequestValues source = RequestValues.All)
        {
            var requestBase = new HttpRequestWrapper(request);

            return Values(requestBase, source);
        }
        public static ModelValues ModelValues(this IDictionary<string, object> dictionary)
        {
            var result = new ModelValues();

            foreach (var item in dictionary)
            {
                result.Add(item);
            }

            return result;
        }
        public static ModelValues Values(this IDbCommand cmd)
        {
            var result = new ModelValues();

            foreach (IDbDataParameter p in cmd.Parameters)
            {
                result.Add(p.ParameterName, p.Value);
            }

            return result;
        }

        public static DataTable ToDataTable<T>(this IEnumerable<T> list, ModelReadTemplate template = null) where T : BaseModel
        {
            var result = BaseModel.GetDataTable(typeof(T));

            foreach (var model in list)
            {
                result.Rows.Add(model.ToDataRow(template));
            }

            return result;
        }

        public static DbResult<List<T>> Execute<T>(this IDbHelper db, string cmd, object args = null) where T: BaseModel, new()
        {
            var result = db.ExecuteReader(cmd, (reader) =>
            {
                var r = new T();
                r.Read(reader);
                return r;
            }, args);

            return result;
        }
        public static Task<DbResult<List<T>>> ExecuteAsync<T>(this IDbHelper db, string cmd, object args = null) where T : BaseModel, new()
        {
            var result = db.ExecuteReaderAsync(cmd, (reader) =>
            {
                var r = new T();
                r.Read(reader);
                return r;
            }, args);

            return result;
        }
        public static DbResult<List<T>> Execute<T>(this IDbHelper db, IDbCommand cmd, object args = null) where T : BaseModel, new()
        {
            var result = db.ExecuteReader(cmd, (reader) =>
            {
                var r = new T();
                r.Read(reader);
                return r;
            }, args);

            return result;
        }
        public static Task<DbResult<List<T>>> ExecuteAsync<T>(this IDbHelper db, IDbCommand cmd, object args = null) where T : BaseModel, new()
        {
            var result = db.ExecuteReaderAsync(cmd, (reader) =>
            {
                var r = new T();
                r.Read(reader);
                return r;
            }, args);

            return result;
        }
        public static DbResult<T> ExecuteSingle<T>(this IDbHelper db, string cmd, object args = null) where T : BaseModel, new()
        {
            var result = db.ExecuteSingle(cmd, (IDataReader reader) =>
            {
                var r = new T();
                r.Read(reader);
                return r;
            }, args);

            return result;
        }
        public static Task<DbResult<T>> ExecuteSingleAsync<T>(this IDbHelper db, string cmd, object args = null) where T : BaseModel, new()
        {
            var result = db.ExecuteSingleAsync(cmd, (reader) =>
            {
                var r = new T();
                r.Read(reader);
                return r;
            }, args);

            return result;
        }
        public static DbResult<T> ExecuteSingle<T>(this IDbHelper db, IDbCommand cmd, object args = null) where T : BaseModel, new()
        {
            var result = db.ExecuteSingle(cmd, (IDataReader reader) =>
            {
                var r = new T();
                r.Read(reader);
                return r;
            }, args);

            return result;
        }
        public static Task<DbResult<T>> ExecuteSingleAsync<T>(this IDbHelper db, IDbCommand cmd, object args = null) where T : BaseModel, new()
        {
            var result = db.ExecuteSingleAsync(cmd, (reader) =>
            {
                var r = new T();
                r.Read(reader);
                return r;
            }, args);

            return result;
        }
    }
}
