using Locust.Base;
using Locust.Expressions;
using Locust.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Extensions
{
    public enum ExceptionJsonSerializationLevel
    {
        Message
    }
    public static class ExceptionExtentions
    {
        public static string ToString(this Exception e, string separator)
        {
            var sb = new StringBuilder();

            if (e != null)
            {
                sb.Append(e.Message);

                var innerException = e.InnerException;

                while (innerException != null)
                {
                    sb.Append(separator + innerException.Message);

                    innerException = innerException.InnerException;
                }
            }

            return sb.ToString();
        }
        private static string ToJsonInternal(Exception x, bool ignoreNullProperties = true, bool encodeEnumsAsString = true, bool indented = false, string indent = "")
        {
            var result = "";

            if (x != null)
            {
                var type = x.GetType();

                for (; ; )
                {
                    var sb = new StringBuilder();

                    var props = GlobalReflectionPropertyCache.Cache.GetPublicInstanceReadableProperties(type).Where(p => !p.Name.In("TargetSite"));

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

                        sb.AppendWithComma($"{(indented ? indent : "")}\"{prop.Name}\": {value.JsonSerialize(ignoreNullProperties, encodeEnumsAsString, indented)}{(indented ? "" : "\n")}");
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
        public static string ToJson(this Exception x, bool ignoreNullProperties = true, bool encodeEnumsAsString = true, bool indented = false)
        {
            return ToJsonInternal(x, ignoreNullProperties, encodeEnumsAsString, indented, "");
        }
    }
}
