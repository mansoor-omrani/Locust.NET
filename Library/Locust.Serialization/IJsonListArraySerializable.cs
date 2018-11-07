using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Serialization
{
    public class JsonList
    {
        public IList<string> Props { get; }
        public IList<object> Data { get; }
    }
    public interface IJsonListArraySerializable
    {
        KeyValuePair<string, string> ToJsonList(bool skipSchema = false, bool skipChildSchema = true, JsonSerializationOptions options = null);
    }
}
