using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Compression
{
    public class ZlibBase64CompressionOptions: Base64CompressionOptions
    {
        public int DecompressBufferSize { get; set; } = 10240;
        public int CompressBufferSize { get; set; } = 10240;
    }
}
