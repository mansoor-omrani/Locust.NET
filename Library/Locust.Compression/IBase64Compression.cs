using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Compression
{
    public interface IBase64Compression
    {
        string Base64Compress(string data, Base64CompressionOptions options = null);
        string Base64Decompress(string data, Base64CompressionOptions options = null);
        Task<string> Base64CompressAsync(string data, Base64CompressionOptions options = null);
        Task<string> Base64DecompressAsync(string data, Base64CompressionOptions options = null);
    }
}
