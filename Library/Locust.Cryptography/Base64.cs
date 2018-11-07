using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Cryptography
{
    public class Base64
    {
        public IBase64Encoder Encoder { get; set; }
        public IBase64Decoder Decoder { get; set; }
        public Base64()
        {
            Encoder = new Locust.Cryptography.Base64Encoder();
            Decoder = new Locust.Cryptography.Base64Decoder();
        }
    }
}
