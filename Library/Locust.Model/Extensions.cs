using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Locust.Db;
using Locust.Extensions;
using Locust.Json;
using Locust.Serialization;

namespace Locust.Model
{
    public static class Extensions
    {
        public static bool IsBaseModel(this Type type)
        {
            return type.DescendsFrom(typeof(BaseModel));
        }
        public static bool IsEnumerableBaseModel(this Type type)
        {
            Type itemType;

            if (type.TryGetItemType(out itemType))
            {
                return itemType.IsBaseModel();
            }
            return false;
        }
        public static DbResult<List<T>> ExecuteReader<T>(this IDbHelper db, SqlCommand cmd, dynamic args = null) where T: BaseModel, new()
        {
            Func<IDataReader, T> transform = (row) =>
            {
                var model = new T();

                model.Read(row);

                return model;
            };

            return db.ExecuteReader(cmd, transform, args);
        }
        public static Task<DbResult<List<T>>> ExecuteReaderAsync<T>(this IDbHelper db, SqlCommand cmd, dynamic args = null) where T : BaseModel, new()
        {
            return db.ExecuteReaderAsync(cmd, args, CancellationToken.None);
        }

        public static Task<DbResult<List<T>>> ExecuteReaderAsync<T>(this IDbHelper db, SqlCommand cmd, dynamic args, CancellationToken cancellation) where T : BaseModel, new()
        {
            Func<IDataReader, T> transform = (row) =>
            {
                var model = new T();

                model.Read(row);

                return model;
            };

            return db.ExecuteReaderAsync(cmd, transform, args, cancellation);
        }


        public static DbResult<List<T>> ExecuteReader<T>(this IDbHelper db, string cmd, dynamic args = null) where T : BaseModel, new()
        {
            Func<IDataReader, T> transform = (row) =>
            {
                var model = new T();

                model.Read(row);

                return model;
            };

            return db.ExecuteReader(cmd, transform, args);
        }
        public static Task<DbResult<List<T>>> ExecuteReaderAsync<T>(this IDbHelper db, string cmd, dynamic args = null) where T : BaseModel, new()
        {
            return db.ExecuteReaderAsync(cmd, args, CancellationToken.None);
        }

        public static Task<DbResult<List<T>>> ExecuteReaderAsync<T>(this IDbHelper db, string cmd, dynamic args, CancellationToken cancellation) where T : BaseModel, new()
        {
            Func<IDataReader, T> transform = (row) =>
            {
                var model = new T();

                model.Read(row);

                return model;
            };

            return db.ExecuteReaderAsync(cmd, transform, args, cancellation);
        }

        public static DataTable ToDataTable<T>(this List<T> list, string jsonTemplate = null) where T: BaseModel, new()
        {
            ModelReadTemplate template = null;

            if (!string.IsNullOrEmpty(jsonTemplate))
            {
                template = ModelReadTemplate.FromJson(jsonTemplate);
            }
            else
            {
                template = ModelReadTemplate.GetDefault<T>();
            }

            var result = BaseModel.GetDataTable<T>(template);
            
            foreach (var item in list)
            {
                var row = item.ToDataRow(template, result);

                result.Rows.Add(row);
            }

            return result;
        }

        public static void ReadJson<T>(this IList<T> x, string json) where T:BaseModel
        {
            var jp = new JsonParser();

            jp.OnObjectItem += reader =>
            {
                var item = Activator.CreateInstance<T>();
                item.ReadJson(reader);
                x.Add(item);
                return true;
            };

            jp.ReadJson(json);
        }
        public static bool TryReadJson(this object x, string json)
        {
            var thisType = x.GetType();
            Type itemType;

            if (thisType.IsJsonModel())
            {
                (x as JsonModel).ReadJson(json);

                return true;
            }

            if (thisType.TryGetItemType(out itemType))
            {
                if (itemType.IsJsonModel())
                {
                    // currently we only support List<T>
                    // that said, we add items to the list using List<T>.Add() method

                    var addMethod = thisType.GetMethod("Add", BindingFlags.Instance | BindingFlags.Public);

                    if (addMethod != null)
                    {
                        var jp = new JsonParser();

                        jp.OnObjectItem += reader =>
                        {
                            var item = Activator.CreateInstance(itemType) as JsonModel;
                            item.ReadJson(reader);
                            addMethod.Invoke(x, new object[] { item });
                            return true;
                        };

                        jp.ReadJson(json);

                        return true;
                    }
                }
            }

            return false;
        }
        public static string ToJson<T>(this IEnumerable<T> x) where T : BaseModel
        {
            var sb = new StringBuilder();
            foreach (var item in x)
            {
                sb.AppendWithComma(item.ToJson());
            }
            
            return "[" + sb + "]";
        }
    }
}
