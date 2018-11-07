using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Serialization
{
    public class JsonSerializer : ISerializer
    {
        public object Deserialize(byte[] bytes)
        {
            var x = Encoding.UTF8.GetString(bytes);
            var result = JsonConvert.DeserializeObject(x);

            return result;
        }

        public object Deserialize(byte[] bytes, Type type)
        {
            var x = Encoding.UTF8.GetString(bytes);
            var result = JsonConvert.DeserializeObject(x, type);

            return result;
        }

        public byte[] Serialize(object o)
        {
            var x = JsonConvert.SerializeObject(o);

            return Encoding.UTF8.GetBytes(x);
        }
    }
}
