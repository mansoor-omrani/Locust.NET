using Locust.Db;
using Locust.Expressions;
using Locust.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Locust.Db
{
    public static class DbHelper
    {
        private static PropertyProvider propertyProvider;
        static DbHelper()
        {
            propertyProvider = new PropertyProvider();
        }
        public static T ReflectionTransform<T>(IDataReader reader) where T : class, new()
        {
            var result = new T();

            if (!reader.IsClosed)
            {
                var props = PropertyProvider.PropertyCache.GetPublicInstanceReadableProperties<T>();

                for (var i = 0; i < reader.FieldCount; i++)
                {
                    if (!reader.IsDBNull(i))
                    {
                        var column = reader.GetName(i);
                        var value = reader[i];

                        var prop = props.FirstOrDefault(p => string.Compare(p.Name, column, true) == 0);

                        if (prop != null)
                        {
                            try
                            {
                                if (prop.PropertyType.IsNullable())
                                {
                                    var nullableValue = Activator.CreateInstance(prop.PropertyType, new object[] { value });

                                    prop.SetValue(result, nullableValue);
                                }
                                else
                                {
                                    prop.SetValue(result, value);
                                }
                            }
                            catch (Exception e)
                            {
                                throw new Exception($"error reading column {column} into prop {prop.Name}", e);
                            }
                        }
                    }
                }
            }

            return result;
        }
        public static T Transform<T>(IDataReader reader) where T:class, new()
        {
            var result = new T();

            if (!reader.IsClosed)
            {
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    if (!reader.IsDBNull(i))
                    {
                        var column = reader.GetName(i);
                        var value = reader[i];

                        
                        propertyProvider.Write(result, column, value);
                    }
                }
            }

            return result;
        }
        public static Func<IDataReader, T> GetTransform<T>() where T : class, new()
        {
            Func<IDataReader, T> f = (reader) =>
            {
                var result = new T();

                if (!reader.IsClosed)
                {
                    for (var i = 0; i < reader.FieldCount; i++)
                    {
                        if (!reader.IsDBNull(i))
                        {
                            var column = reader.GetName(i);
                            var value = reader[i];

                            propertyProvider.Write(result, column, value);
                        }
                    }
                }

                return result;
            };

            return f;
        }
        public static DbResult<List<T>> ExecuteReader<T>(this IDbHelper db, IDbCommand cmd, object args = null) where T : class, new()
        {
            return db.ExecuteReader<T>(cmd, (reader) => ReflectionTransform<T>(reader), args);
        }
        public static DbResult<List<T>> ExecuteReader<T>(this IDbHelper db, string cmd, object args = null) where T : class, new()
        {
            return db.ExecuteReader<T>(cmd, (reader) => ReflectionTransform<T>(reader), args);
        }
        public static Task<DbResult<List<T>>> ExecuteReaderAsync<T>(this IDbHelper db, IDbCommand cmd, object args, CancellationToken cancellation) where T : class, new()
        {
            return db.ExecuteReaderAsync<T>(cmd, (reader) => ReflectionTransform<T>(reader), args, cancellation);
        }
        public static Task<DbResult<List<T>>> ExecuteReaderAsync<T>(this IDbHelper db, string cmd, object args, CancellationToken cancellation) where T : class, new()
        {
            return db.ExecuteReaderAsync<T>(cmd, (reader) => ReflectionTransform<T>(reader), args, cancellation);
        }
        public static Task<DbResult<List<T>>> ExecuteReaderAsync<T>(this IDbHelper db, IDbCommand cmd, object args = null) where T : class, new()
        {
            return db.ExecuteReaderAsync<T>(cmd, args, CancellationToken.None);
        }
        public static Task<DbResult<List<T>>> ExecuteReaderAsync<T>(this IDbHelper db, string cmd, object args = null) where T : class, new()
        {
            return db.ExecuteReaderAsync<T>(cmd, args, CancellationToken.None);
        }
        // -------------------------- ExecuteSingle --------------------------
        public static DbResult<T> ExecuteSingle<T>(this IDbHelper db, IDbCommand cmd, object args = null) where T : class, new()
        {
            return db.ExecuteSingle<T>(cmd, (reader) => ReflectionTransform<T>(reader), args);
        }
        public static DbResult<T> ExecuteSingle<T>(this IDbHelper db, string cmd, object args = null) where T : class, new()
        {
            return db.ExecuteSingle<T>(cmd, (reader) => ReflectionTransform<T>(reader), args);
        }
        public static Task<DbResult<T>> ExecuteSingleAsync<T>(this IDbHelper db, IDbCommand cmd, object args, CancellationToken cancellation) where T : class, new()
        {
            return db.ExecuteSingleAsync<T>(cmd, (reader) => ReflectionTransform<T>(reader), args, cancellation);
        }
        public static Task<DbResult<T>> ExecuteSingleAsync<T>(this IDbHelper db, string cmd, object args, CancellationToken cancellation) where T : class, new()
        {
            return db.ExecuteSingleAsync<T>(cmd, (reader) => ReflectionTransform<T>(reader), args, cancellation);
        }
        public static Task<DbResult<T>> ExecuteSingleAsync<T>(this IDbHelper db, IDbCommand cmd, object args = null) where T : class, new()
        {
            return db.ExecuteSingleAsync<T>(cmd, args, CancellationToken.None);
        }
        public static Task<DbResult<T>> ExecuteSingleAsync<T>(this IDbHelper db, string cmd, object args = null) where T : class, new()
        {
            return db.ExecuteSingleAsync<T>(cmd, args, CancellationToken.None);
        }
    }
}
