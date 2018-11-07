using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Compression
{
    public interface ICompression
    {
        byte[] Compress(byte[] data);
        byte[] Decompress(byte[] data);
        Stream Compress(Stream data);
        Stream Decompress(Stream data);
        Task<byte[]> CompressAsync(byte[] data);
        Task<byte[]> DecompressAsync(byte[] data);
        Task<Stream> CompressAsync(Stream data);
        Task<Stream> DecompressAsync(Stream data);
    }
}
