using Locust.Base;
using Locust.Conversion;
using Locust.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Locust.Db
{
    public static class DbCommandExtensions
    {
        public static void Execute<T>(this DbCommand cmd, IList<T> result, Func<IDataReader, T> fn)
        {
            if (cmd.Connection.State == ConnectionState.Closed || cmd.Connection.State == ConnectionState.Broken)
                cmd.Connection.Open();

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var item = fn(reader);

                    result.Add(item);
                }
            }
        }
        public static object Execute(this DbCommand cmd, bool scaler = false)
        {
            if (cmd.Connection.State == ConnectionState.Closed || cmd.Connection.State == ConnectionState.Broken)
                cmd.Connection.Open();

            object result = null;

            if (scaler)
            {
                result = cmd.ExecuteScalar();
            }
            else
            {
                result = cmd.ExecuteNonQuery();
            }

            return result;
        }
        public static void Execute<T>(this DbCommand cmd, IList<T> result)
        {
            cmd.Execute(result, reader =>
            {
                object record;

                if (typeof(T) == TypeHelper.TypeOfString)
                {
                    record = Activator.CreateInstance(TypeHelper.TypeOfString, "".ToCharArray());
                }
                else
                {
                    record = Activator.CreateInstance(typeof(T));
                }

                reader.DataReaderToObject(ref record, typeof(T));

                return (T)record;
            });
        }
        public static async Task ExecuteAsync<T>(this DbCommand cmd, IList<T> result, Func<IDataReader, T> fn, CancellationToken cancellation)
        {
            if (cmd.Connection.State == ConnectionState.Closed || cmd.Connection.State == ConnectionState.Broken)
                await cmd.Connection.OpenAsync(cancellation);

            using (var reader = await cmd.ExecuteReaderAsync(cancellation))
            {
                while (reader.Read())
                {
                    var item = fn(reader);

                    result.Add(item);
                }
            }
        }
        public static async Task<object> ExecuteAsync(this DbCommand cmd, bool scaler, CancellationToken cancellation)
        {
            if (cmd.Connection.State == ConnectionState.Closed || cmd.Connection.State == ConnectionState.Broken)
                cmd.Connection.Open();

            object result = null;

            if (scaler)
            {
                result = await cmd.ExecuteScalarAsync();
            }
            else
            {
                result = await cmd.ExecuteNonQueryAsync();
            }

            return result;
        }
        public static Task ExecuteAsync<T>(this DbCommand cmd, IList<T> result, CancellationToken cancellation)
        {
            return cmd.ExecuteAsync(result, reader =>
            {
                object record;

                if (typeof(T) == TypeHelper.TypeOfString)
                {
                    record = Activator.CreateInstance(TypeHelper.TypeOfString, "".ToCharArray());
                }
                else
                {
                    record = Activator.CreateInstance(typeof(T));
                }

                reader.DataReaderToObject(ref record, typeof(T));

                return (T)record;
            }, cancellation);
        }
        public static Task<object> ExecuteAsync(this DbCommand cmd, bool scaler = false)
        {
            return ExecuteAsync(cmd, scaler, CancellationToken.None);
        }
        public static void ApplyOutputs(this DbCommand cmd, IDictionary<string, object> parameters, Action<IDictionary<string, object>, string, object> actApply)
        {
            if (cmd != null && parameters != null && cmd.Parameters.Count > 0 && parameters.Count > 0)
            {
                foreach (DbParameter param in cmd.Parameters)
                {
                    if (param.Direction == ParameterDirection.Output || param.Direction == ParameterDirection.InputOutput)
                    {
                        var paramName = param.ParameterName.StartsWith("@") ? param.ParameterName.Substring(1) : param.ParameterName;

                        if (parameters.Keys.Contains(paramName))
                        {
                            actApply(parameters, paramName, param.Value);
                        }
                    }
                }
            }
        }
        public static void ApplyOutputs(this DbCommand cmd, IDictionary<string, object> parameters)
        {
            cmd.ApplyOutputs(parameters, (obj, paramName, value) =>
            {
                obj[paramName] = DBNull.Value.Equals(value) || value == null ? null : value;
            });
        }
        public static void ApplyOutputs(this DbCommand cmd, object parameters, Action<object, PropertyInfo, object> actApply, PropertyInfo[] properties = null)
        {
            if (cmd != null && parameters != null && cmd.Parameters.Count > 0)
            {
                var props = properties != null ? properties :
                                    parameters.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

                if (props.Length > 0)
                {
                    foreach (DbParameter param in cmd.Parameters)
                    {
                        if (param.Direction == ParameterDirection.Output || param.Direction == ParameterDirection.InputOutput)
                        {
                            var paramName = param.ParameterName.StartsWith("@") ? param.ParameterName.Substring(1) : param.ParameterName;

                            foreach (var prop in props)
                            {
                                if (string.Compare(prop.Name, paramName, false) == 0 && prop.CustomAttributes.Count(a => a.AttributeType == typeof(IgnoreAttribute)) == 0)
                                {
                                    actApply(parameters, prop, param.Value);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
        public static void ApplyOutputs(this DbCommand cmd, object parameters, PropertyInfo[] properties = null)
        {
            cmd.ApplyOutputs(parameters, (obj, prop, value) =>
            {
                if (prop.PropertyType == typeof(CommandParameter))
                {
                    var cp = prop.GetValue(obj) as CommandParameter;

                    if (cp != null)
                    {
                        cp.Value = value;
                    }
                }
                else
                {
                    if (prop.CanWrite)
                    {
                        prop.SetValue(parameters, DBNull.Value.Equals(value) || value == null ? null : value);
                    }
                }
            }, properties);
        }
        public static void SafeApplyOutputs(this DbCommand cmd, object parameters, PropertyInfo[] properties = null)
        {
            cmd.ApplyOutputs(parameters, (obj, prop, value) =>
            {
                if (value == null || DBNull.Value.Equals(value))
                {
                    if (prop.PropertyType.IsNullable() && prop.CanWrite)
                    {
                        prop.SetValue(obj, null);
                    }
                }
                else
                {
                    if (prop.PropertyType == typeof(CommandParameter))
                    {
                        var cp = prop.GetValue(obj) as CommandParameter;

                        if (cp != null)
                        {
                            cp.Value = value;
                        }
                    }
                    else
                    {
                        do
                        {
                            if (prop.PropertyType == TypeHelper.TypeOfInt16 || prop.PropertyType == TypeHelper.TypeOfNullableInt16)
                            {
                                prop.SetValue(obj, SafeClrConvert.ToInt16(value));
                                break;
                            }


                            if (prop.PropertyType == TypeHelper.TypeOfInt32 || prop.PropertyType == TypeHelper.TypeOfNullableInt32)
                            {
                                prop.SetValue(obj, SafeClrConvert.ToInt32(value));
                                break;
                            }


                            if (prop.PropertyType == TypeHelper.TypeOfInt64 || prop.PropertyType == TypeHelper.TypeOfNullableInt64)
                            {
                                prop.SetValue(obj, SafeClrConvert.ToInt64(value));
                                break;
                            }


                            if (prop.PropertyType == TypeHelper.TypeOfUInt16 || prop.PropertyType == TypeHelper.TypeOfNullableUInt16)
                            {
                                prop.SetValue(obj, SafeClrConvert.ToUInt16(value));
                                break;
                            }


                            if (prop.PropertyType == TypeHelper.TypeOfUInt32 || prop.PropertyType == TypeHelper.TypeOfNullableUInt32)
                            {
                                prop.SetValue(obj, SafeClrConvert.ToUInt32(value));
                                break;
                            }


                            if (prop.PropertyType == TypeHelper.TypeOfUInt64 || prop.PropertyType == TypeHelper.TypeOfNullableUInt64)
                            {
                                prop.SetValue(obj, SafeClrConvert.ToUInt64(value));
                                break;
                            }


                            if (prop.PropertyType == TypeHelper.TypeOfSingle || prop.PropertyType == TypeHelper.TypeOfNullableSingle)
                            {
                                prop.SetValue(obj, SafeClrConvert.ToSingle(value));
                                break;
                            }

                            if (prop.PropertyType == TypeHelper.TypeOfFloat || prop.PropertyType == TypeHelper.TypeOfNullableFloat)
                            {
                                prop.SetValue(obj, SafeClrConvert.ToFloat(value));
                                break;
                            }

                            if (prop.PropertyType == TypeHelper.TypeOfDouble || prop.PropertyType == TypeHelper.TypeOfNullableDouble)
                            {
                                prop.SetValue(obj, SafeClrConvert.ToDouble(value));
                                break;
                            }

                            if (prop.PropertyType == TypeHelper.TypeOfDecimal || prop.PropertyType == TypeHelper.TypeOfNullableDecimal)
                            {
                                prop.SetValue(obj, SafeClrConvert.ToDecimal(value));
                                break;
                            }

                            if (prop.PropertyType == TypeHelper.TypeOfByte || prop.PropertyType == TypeHelper.TypeOfNullableByte)
                            {
                                prop.SetValue(obj, SafeClrConvert.ToByte(value));
                                break;
                            }

                            if (prop.PropertyType == TypeHelper.TypeOfSByte || prop.PropertyType == TypeHelper.TypeOfNullableSByte)
                            {
                                prop.SetValue(obj, SafeClrConvert.ToSByte(value));
                                break;
                            }

                            if (prop.PropertyType == TypeHelper.TypeOfChar || prop.PropertyType == TypeHelper.TypeOfNullableChar)
                            {
                                prop.SetValue(obj, SafeClrConvert.ToChar(value));
                                break;
                            }

                            if (prop.PropertyType == TypeHelper.TypeOfString)
                            {
                                prop.SetValue(obj, SafeClrConvert.ToString(value));
                                break;
                            }

                            if (prop.PropertyType == TypeHelper.TypeOfBool || prop.PropertyType == TypeHelper.TypeOfNullableBool)
                            {
                                prop.SetValue(obj, SafeClrConvert.ToBoolean(value));
                                break;
                            }

                            if (prop.PropertyType == TypeHelper.TypeOfDateTime || prop.PropertyType == TypeHelper.TypeOfNullableDateTime)
                            {
                                prop.SetValue(obj, SafeClrConvert.ToDateTime(value));
                                break;
                            }

                            if (prop.PropertyType == TypeHelper.TypeOfDateTimeOffset || prop.PropertyType == TypeHelper.TypeOfNullableDateTimeOffset)
                            {
                                prop.SetValue(obj, SafeClrConvert.ToDateTime(value));
                                break;
                            }

                            if (prop.PropertyType == TypeHelper.TypeOfTimeSpan || prop.PropertyType == TypeHelper.TypeOfNullableTimeSpan)
                            {
                                prop.SetValue(obj, SafeClrConvert.ToTimeSpan(value));
                                break;
                            }

                            prop.SetValue(obj, value);
                        }
                        while (false);
                    }
                }
            }, properties);
        }
    }
}
