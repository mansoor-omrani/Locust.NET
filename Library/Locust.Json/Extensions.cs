using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Locust.Base;
using Locust.Extensions;
using Locust.Serialization;

namespace Locust.Json
{
    public static class JsonHelper
    {
        public static Type JsonModelType { get; set; }

        static JsonHelper()
        {
            JsonModelType = typeof(JsonModel);
        }

        public static bool IsJsonModel(this Type type)
        {
            return type.DescendsFrom(JsonModelType);
        }
    }
    public static class Extensions
    {
        public static string ToJson(this IEnumerable arr, JsonSerializationOptions options)
        {
            var result = new StringBuilder();
            var c = 0;

            result.Append("[");
            if (arr != null)
            {
                foreach (var item in arr)
                {
                    c++;
                    var value = item;
                    if (c > 1)
                    {
                        result.Append(", ");
                    }
                    if (value == null)
                    {
                        result.Append("null");
                        continue;
                    }
                    var valueType = value.GetType();
                    if (valueType == TypeHelper.TypeOfBool)
                    {
                        result.Append(value.ToString().ToLower());
                        continue;
                    }
                    if (valueType.IsNumeric())
                    {
                        result.Append(value);
                        continue;
                    }
                    if (valueType == TypeHelper.TypeOfChar)
                    {
                        result.AppendFormat("'{0}'", value);
                        continue;
                    }
                    if (valueType == TypeHelper.TypeOfGuid)
                    {
                        if ((Guid)(object)(value) != Guid.Empty)
                        {
                            result.AppendFormat("\"{0}\"", value);
                            continue;
                        }
                        else
                        {
                            result.AppendFormat("\"{0}\"", "null");
                            continue;
                        }
                    }
                    if (valueType  == TypeHelper.TypeOfString)
                    {
                        result.AppendFormat("\"{0}\"", HttpUtility.JavaScriptStringEncode(value.ToString()));
                        
                        continue;
                    }

                    var jm = value as IJsonSerializable;

                    if (jm != null)
                    {
                        result.Append(jm.ToJson(options));
                        continue;
                    }

                    var e = value as IEnumerable;
                    if (e != null)
                    {
                        result.Append(e.ToJson(options));
                        continue;
                    }
                    result.AppendFormat("\"{0}\"", value);
                }
            }
            result.Append("]");

            return result.ToString();
        }
        public static string ToJsonList(this IEnumerable<JsonModel> list, JsonSerializationOptions options = null)
        {
            var _options = new JsonSerializationOptions(options);
            var first = true;
            var sb = new StringBuilder();
            var schema = "";
            var skipSchema = false;

            foreach (var item in list)
            {
                var jl = item.ToJsonList(skipSchema, skipSchema, _options);

                if (first)
                {
                    schema = jl.Key;

                    first = false;
                    skipSchema = true;
                }

                sb.AppendWithCommaIfNotEmpty(jl.Value);
            }

            return string.Format("{{\"Schema\": {0},\"Data\":[{1}]}}", schema, sb);
        }
    }
}
