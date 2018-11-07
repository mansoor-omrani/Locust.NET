using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Cryptography
{
    public interface IXorEncryption
    {
        string Apply(string data, string key);
        string Apply(string data, int key);
    }
    public class XorEncryption: IXorEncryption
    {
        public virtual string Apply(string data, string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException(nameof(key));

            if (string.IsNullOrEmpty(data))
                return string.Empty;

            var result = new char[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                result[i] = (char)(data[i] ^ key[i % key.Length]);
            }

            return new string(result);
        }
        public virtual string Apply(string data, int key)
        {
            string result = "";

            for (int i = 0; i < data.Length; i++)
            {
                var ch = Convert.ToInt32(data[i]);
                ch ^= key;

                result += char.ConvertFromUtf32(ch);
            }

            return result;
        }
    }
}
