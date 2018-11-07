using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Cryptography
{
    public interface IBase64Decoder
    {
        byte[] Decode(string base64);
        byte[] Decode(char[] base64);
        string Decode(string base64, Encoding e);
        string Decode(char[] base64, Encoding e);
    }
}
