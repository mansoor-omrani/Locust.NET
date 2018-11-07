using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Serialization
{
    public class BinarySerializer : ISerializer
    {
        public object Deserialize(byte[] bytes)
        {
            var result = null as object;

            if (bytes != null && bytes.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    var bf = new BinaryFormatter();

                    ms.Write(bytes, 0, bytes.Length);
                    ms.Seek(0, SeekOrigin.Begin);

                    result = bf.Deserialize(ms);
                }
            }

            return result;
        }

        public object Deserialize(byte[] bytes, Type type)
        {
            return Deserialize(bytes);
        }

        public byte[] Serialize(object obj)
        {
            if (obj != null)
            {
                var bf = new BinaryFormatter();

                using (var ms = new MemoryStream())
                {
                    bf.Serialize(ms, obj);

                    return ms.ToArray();
                }
            }
            else
            {
                return new byte[] { };
            }
        }
    }
}
