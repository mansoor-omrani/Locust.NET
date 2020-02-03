using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Locust.Extensions;
using Locust.Base;

namespace Locust.Db
{
    internal class CommandArgument
    {
        internal string Name { get; set; }
        internal object Value { get; set; }
        internal Type Type { get; set; }
        internal int? Size { get; set; }
    }
    public static class DbConnectionExtensions
    {
        private static IEnumerator<CommandArgument> GetCommandParameterEnumeratorFromDictionary(IDictionary<string, object> data)
        {
            foreach (var item in data)
            {
                yield return new CommandArgument { Name = item.Key, Value = item.Value, Type = item.Value?.GetType() };
            }
        }
        private static IEnumerator<CommandArgument> GetCommandParameterEnumeratorFromEnumerable(System.Collections.IEnumerable data)
        {
            foreach (var item in data)
            {
                yield return new CommandArgument { Value = item, Type = item?.GetType() };
            }
        }
        private static IEnumerator<CommandArgument> GetCommandParameterEnumeratorFromObject(object data)
        {
            var props = data?.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            if (props?.Length > 0)
            {
                foreach (var prop in props)
                {
                    if (prop.CanRead)
                    {
                        var sizeAttr = prop.GetCustomAttribute<SizeAttribute>();
                        var size = sizeAttr?.Value;

                        if (prop.CustomAttributes.Count(a => a.AttributeType == typeof(IgnoreAttribute)) == 0)
                        {
                            yield return new CommandArgument { Name = prop.Name, Value = prop.GetValue(data), Type = prop.PropertyType, Size = size };
                        }
                    }
                }
            }
        }
        public static DbCommand CreateCommand(this DbConnection con, string text, CommandType type, object parameters, bool autoNullEmptyStrings = false)
        {
            var dictionaryParams = parameters as IDictionary<string, object>;

            if (dictionaryParams != null)
            {
                return CreateCommand(con, text, type, GetCommandParameterEnumeratorFromDictionary(dictionaryParams), autoNullEmptyStrings);
            }

            var enumerable = parameters as System.Collections.IEnumerable;

            if (enumerable != null)
            {
                return CreateCommand(con, text, type, GetCommandParameterEnumeratorFromEnumerable(enumerable), autoNullEmptyStrings);
            }

            return CreateCommand(con, text, type, GetCommandParameterEnumeratorFromObject(parameters));
        }
        public static DbCommand CreateCommand(this DbConnection con, string text, CommandType type, IEnumerator<CommandArgument> parameters, bool autoNullEmptyStrings = false)
        {
            var result = con.CreateCommand();

            result.CommandText = text;
            result.CommandType = type;

            if (parameters != null)
            {
                while (parameters.MoveNext())
                {
                    var param = parameters.Current;
                    var cmdParam = result.CreateParameter();
                    var cmdParamType = cmdParam.GetType();

                    cmdParam.Direction = ParameterDirection.Input;

                    if (!string.IsNullOrEmpty(param.Name))
                    {
                        if (param.Name[0] == '@')
                        {
                            cmdParam.ParameterName = param.Name;
                        }
                        else
                        {
                            cmdParam.ParameterName = '@' + param.Name;
                        }
                    }

                    do
                    {
                        var value = param.Value;
                        var valueType = param.Type;

                        var dbParam = value as DbParameter;

                        if (dbParam != null)
                        {
                            if (string.IsNullOrEmpty(dbParam.ParameterName))
                            {
                                dbParam.ParameterName = cmdParam.ParameterName;
                            }

                            cmdParam = dbParam;
                            break;
                        }

                        var _param = value as CommandParameter;

                        if (_param != null)
                        {
                            if (!string.IsNullOrEmpty(_param.Name))
                            {
                                cmdParam.ParameterName = _param.Name;
                            }

                            if (_param.Value == null || (autoNullEmptyStrings && string.IsNullOrEmpty(_param.Value.ToString())))
                                cmdParam.Value = DBNull.Value;
                            else
                                cmdParam.Value = _param.Value;

                            cmdParam.Direction = _param.Direction;

                            if (_param.Scale.HasValue)
                            {
                                cmdParam.Scale = _param.Scale.Value;
                            }
                            if (_param.Precision.HasValue)
                            {
                                cmdParam.Precision = _param.Precision.Value;
                            }
                            if (_param.Size.HasValue)
                            {
                                cmdParam.Size = _param.Size.Value;
                            }

                            if (!string.IsNullOrEmpty(_param.TypeProp))
                            {
                                var typeProp = cmdParamType.GetProperty(_param.TypeProp);

                                if (typeProp != null)
                                {
                                    typeProp.SetValue(cmdParam, _param.Type);
                                }
                            }
                            else
                            {
                                cmdParam.DbType = _param.Type;
                            }

                            break;
                        }

                        if (param.Size.HasValue)
                        {
                            cmdParam.Size = param.Size.Value;
                        }
                        else
                        {
                            if (valueType == TypeHelper.TypeOfString)
                            {
                                cmdParam.Size = value == null ? -1 : value.ToString().Length;
                            }
                        }

                        if (value == null || (autoNullEmptyStrings && string.IsNullOrEmpty(value.ToString())))
                        {
                            cmdParam.Value = DBNull.Value;
                            break;
                        }

                        if (valueType.IsNullableOrBasicType())
                        {
                            cmdParam.Value = value;

                            break;
                        }

                        if (valueType.IsEnumerable())
                        {
                            var e = value as System.Collections.IEnumerable;

                            if (e != null)
                            {
                                var sb = new StringBuilder();

                                foreach (var x in e)
                                {
                                    sb.Append((sb.Length == 0 ? "" : ",") + x.ToString());
                                }

                                cmdParam.Value = sb.ToString();
                            }
                            else
                            {
                                cmdParam.Value = value.ToString();
                            }

                            break;
                        }

                        cmdParam.Value = value.ToString();
                    }
                    while (false);

                    result.Parameters.Add(cmdParam);
                }
            }

            return result;
        }
    }
}
