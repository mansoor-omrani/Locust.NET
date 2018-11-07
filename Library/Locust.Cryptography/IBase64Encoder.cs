using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Cryptography
{
    public interface IBase64Encoder
    {
        char[] Encode(byte[] input);
        char[] Encode(string input, Encoding e);
    }
}
