using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Serialization
{
    public static class Extensions
    {
        public static string ToJson(this IJsonSerializable x, bool indent = false)
        {
            return x.ToJson(new JsonSerializationOptions { UseIndentation = indent });
        }
        public static object Deserialize(this ISerializer serializer, string data)
        {
            var bytes = Encoding.UTF8.GetBytes(data);

            return serializer.Deserialize(bytes);
        }
        public static T Deserialize<T>(this ISerializer serializer, string data)
        {
            return (T)serializer.Deserialize(data);
        }
        public static string Serialize<T>(this ISerializer serializer, T data)
        {
            var bytes = serializer.Serialize(data);

            return Encoding.UTF8.GetString(bytes);
        }
    }
}
