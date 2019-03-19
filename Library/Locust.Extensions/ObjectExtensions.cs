using Locust.Base;
using Locust.Expressions;
using Locust.Reflection;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Extensions
{
    public static class ObjectExtensions
    {
        public static string ToLowerCase(this object x)
        {
            return x.ToString().ToLower();
        }
        public static string ToUpperCase(this object x)
        {
            return x.ToString().ToUpper();
        }
        public static string ToLowerCaseInvariant(this object x)
        {
            return x.ToString().ToLowerInvariant();
        }
        public static string ToUpperCaseInvariant(this object x)
        {
            return x.ToString().ToUpperInvariant();
        }
        public static string ToTrimmedLowerCase(this object x)
        {
            return x.ToString().Trim().ToLower();
        }
        public static string ToTrimmedUpperCase(this object x)
        {
            return x.ToString().Trim().ToUpper();
        }
        public static string ToTrimmedLowerCaseInvariant(this object x)
        {
            return x.ToString().Trim().ToLowerInvariant();
        }
        public static string ToTrimmedUpperCaseInvariant(this object x)
        {
            return x.ToString().Trim().ToUpperInvariant();
        }
        public static object Extend(this object x, object y)
        {
            IDictionary<string, object> result = new ExpandoObject();

            var props = GlobalReflectionPropertyCache.Cache.GetPublicInstanceReadableProperties(x.GetType());

            foreach (var prop in props)
            {
                var value = GlobalPropertyProvider.Read(x, prop.Name);

                result.Add(prop.Name, value);
            }

            if (y != null)
            {
                props = GlobalReflectionPropertyCache.Cache.GetPublicInstanceReadableProperties(y.GetType());

                foreach (var prop in props)
                {
                    var value = GlobalPropertyProvider.Read(y, prop.Name);

                    if (result.ContainsKey(prop.Name))
                    {
                        result[prop.Name] = value;
                    }
                    else
                    {
                        result.Add(prop.Name, value);
                    }
                }
            }

            return (object)result;
        }
        private static string JSON_SERIALIZATION_INDENT_CHAR => "  ";
        private static string JsonSerializeInternal(object x, bool ignoreNullProperties = true, bool encodeEnumsAsString = true, bool indented = false, string indent = "")
        {
            var result = "";

            if (x != null)
            {
                var type = x.GetType();

                for (; ; )
                {
                    if (type.IsNullableOrBasicType())
                    {
                        if (type.IsNumeric())
                        {
                            result = x.ToString();
                            break;
                        }
                        if (type == TypeHelper.TypeOfBool)
                        {
                            result = x.ToLowerCase();
                            break;
                        }
                        if (type.IsEnum && !encodeEnumsAsString)
                        {
                            result = ((int)x).ToString();
                            break;
                        }

                        result = $"\"{x}\"";
                        break;
                    }

                    var sb = new StringBuilder();

                    if (type.Implements(TypeHelper.TypeOfIEnumerable))
                    {
                        var e = (x as System.Collections.IEnumerable)?.GetEnumerator();

                        if (e != null)
                        {
                            while (e.MoveNext())
                            {
                                sb.AppendWithComma($" {(e.Current == null ? "null" : e.Current.JsonSerialize(ignoreNullProperties, encodeEnumsAsString))}");
                            }
                        }

                        result = "[" + sb + "]";
                        break;
                    }

                    if (type == TypeHelper.TypeOfException || type.DescendsFrom(TypeHelper.TypeOfException))
                    {
                        result = (x as Exception).ToJson(ignoreNullProperties, encodeEnumsAsString, indented);
                        break;
                    }

                    var props = GlobalReflectionPropertyCache.Cache.GetPublicInstanceReadableProperties(type);

                    if (props != null && props.Count > 0)
                    {
                        foreach (var prop in props)
                        {
                            var value = GlobalPropertyProvider.Read(x, prop.Name);
                            if (value == null)
                            {
                                if (!ignoreNullProperties)
                                {
                                    sb.AppendWithComma($"\"{prop.Name}\": null{(indented ? "" : "\n")}");
                                }
                                continue;
                            }

                            sb.AppendWithComma($"{(indented ? indent + JSON_SERIALIZATION_INDENT_CHAR : "")}\"{prop.Name}\": {JsonSerializeInternal(value, ignoreNullProperties, encodeEnumsAsString, indented, indent + JSON_SERIALIZATION_INDENT_CHAR)}{(indented ? "" : "\n")}");
                        }
                    }

                    result = $"{{{(indented ? "" : "\n")}{sb}{(indented ? "" : $"\n{indent}")}}}";

                    break;
                }
            }
            else
            {
                result = "null";
            }

            return result;
        }
        public static string JsonSerialize(this object x, bool ignoreNullProperties = true, bool encodeEnumsAsString = true, bool indented = false)
        {
            return JsonSerializeInternal(x, ignoreNullProperties, encodeEnumsAsString, indented, "");
        }
    }
}
