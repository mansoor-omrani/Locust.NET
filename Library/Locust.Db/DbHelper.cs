using Locust.Base;
using Locust.Conversion;
using Locust.Db;
using Locust.Expressions;
using Locust.Extensions;
using Locust.Reflection;
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
        public static T ReflectionTransform<T>(IDataReader reader) where T : class, new()
        {
            var result = new T();

            if (!reader.IsClosed)
            {
                var props = GlobalReflectionPropertyCache.Cache.GetPublicInstanceReadableProperties<T>();

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
        public static T ReflectionSafeTransform<T>(IDataReader reader) where T : class, new()
        {
            var result = new T();

            if (!reader.IsClosed)
            {
                var props = GlobalReflectionPropertyCache.Cache.GetPublicInstanceReadableProperties<T>();

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
                                    if (value != null)
                                    {
                                        object nullableValue = null;
                                        object convertedValue = null;

                                        var nullableFinalType = prop.PropertyType.GenericTypeArguments[0];

                                        if (nullableFinalType == TypeHelper.TypeOfByte)
                                            convertedValue = SafeClrConvert.ToByte(value);
                                        else
                                        if (nullableFinalType == TypeHelper.TypeOfInt16)
                                            convertedValue = SafeClrConvert.ToInt16(value);
                                        else
                                            if (nullableFinalType == TypeHelper.TypeOfInt32)
                                            convertedValue = SafeClrConvert.ToInt32(value);
                                        else
                                            if (nullableFinalType == TypeHelper.TypeOfInt64)
                                            convertedValue = SafeClrConvert.ToInt64(value);
                                        else
                                            if (nullableFinalType == TypeHelper.TypeOfSByte)
                                            convertedValue = SafeClrConvert.ToSByte(value);
                                        else
                                            if (nullableFinalType == TypeHelper.TypeOfUInt16)
                                            convertedValue = SafeClrConvert.ToUInt16(value);
                                        else
                                            if (nullableFinalType == TypeHelper.TypeOfUInt32)
                                            convertedValue = SafeClrConvert.ToUInt32(value);
                                        else
                                            if (nullableFinalType == TypeHelper.TypeOfUInt64)
                                            convertedValue = SafeClrConvert.ToUInt64(value);
                                        else
                                            if (nullableFinalType == TypeHelper.TypeOfSingle)
                                            convertedValue = SafeClrConvert.ToSingle(value);
                                        else
                                            if (nullableFinalType == TypeHelper.TypeOfDouble)
                                            convertedValue = SafeClrConvert.ToDouble(value);
                                        else
                                            if (nullableFinalType == TypeHelper.TypeOfDecimal)
                                            convertedValue = SafeClrConvert.ToDecimal(value);
                                        else
                                            if (nullableFinalType == TypeHelper.TypeOfString)
                                            convertedValue = SafeClrConvert.ToString(value);
                                        else
                                            if (nullableFinalType == TypeHelper.TypeOfDateTime)
                                            convertedValue = SafeClrConvert.ToDateTime(value);
                                        else
                                            if (nullableFinalType == TypeHelper.TypeOfBool)
                                            convertedValue = SafeClrConvert.ToBoolean(value);

                                        nullableValue = Activator.CreateInstance(prop.PropertyType, new object[] { convertedValue });

                                        prop.SetValue(result, nullableValue);
                                    }
                                }
                                else
                                {
                                    object convertedValue = null;

                                    var propType = prop.PropertyType;

                                    if (propType == TypeHelper.TypeOfByte)
                                        convertedValue = SafeClrConvert.ToByte(value);
                                    else
                                    if (propType == TypeHelper.TypeOfInt16)
                                        convertedValue = SafeClrConvert.ToInt16(value);
                                    else
                                        if (propType == TypeHelper.TypeOfInt32)
                                        convertedValue = SafeClrConvert.ToInt32(value);
                                    else
                                        if (propType == TypeHelper.TypeOfInt64)
                                        convertedValue = SafeClrConvert.ToInt64(value);
                                    else
                                        if (propType == TypeHelper.TypeOfSByte)
                                        convertedValue = SafeClrConvert.ToSByte(value);
                                    else
                                        if (propType == TypeHelper.TypeOfUInt16)
                                        convertedValue = SafeClrConvert.ToUInt16(value);
                                    else
                                        if (propType == TypeHelper.TypeOfUInt32)
                                        convertedValue = SafeClrConvert.ToUInt32(value);
                                    else
                                        if (propType == TypeHelper.TypeOfUInt64)
                                        convertedValue = SafeClrConvert.ToUInt64(value);
                                    else
                                        if (propType == TypeHelper.TypeOfSingle)
                                        convertedValue = SafeClrConvert.ToSingle(value);
                                    else
                                        if (propType == TypeHelper.TypeOfDouble)
                                        convertedValue = SafeClrConvert.ToDouble(value);
                                    else
                                        if (propType == TypeHelper.TypeOfDecimal)
                                        convertedValue = SafeClrConvert.ToDecimal(value);
                                    else
                                        if (propType == TypeHelper.TypeOfString)
                                        convertedValue = SafeClrConvert.ToString(value);
                                    else
                                        if (propType == TypeHelper.TypeOfDateTime)
                                        convertedValue = SafeClrConvert.ToDateTime(value);
                                    else
                                        if (propType == TypeHelper.TypeOfBool)
                                            convertedValue = SafeClrConvert.ToBoolean(value);

                                    if (convertedValue != null)
                                    {
                                        prop.SetValue(result, convertedValue);
                                    }
                                    else
                                    {
                                        prop.SetValue(result, value);
                                    }
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
        public static T Transform<T>(IDataReader reader) where T : class, new()
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


                        GlobalPropertyProvider.Write(result, column, value);
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

                            GlobalPropertyProvider.Write(result, column, value);
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
