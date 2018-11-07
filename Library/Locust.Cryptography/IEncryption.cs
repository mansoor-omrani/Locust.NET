using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Cryptography
{
    public interface IEncryption
    {
        String GetKey(string n, Encoding e);
        String Encrypt(String data, String key);
        String Decrypt(String data, String key);
    }
}
