using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zlib = ComponentAce.Compression.Libs.zlib;

namespace Locust.Compression
{
    public class ZlibCompression: ICompression
    {
        private void copyStream(System.IO.Stream input, System.IO.Stream output, int bufferSize)
        {
            byte[] buffer;
            int len;

            buffer = new byte[bufferSize];

            while ((len = input.Read(buffer, 0, bufferSize)) > 0)
            {
                output.Write(buffer, 0, len);
            }

            output.Flush();
        }
        private async Task copyStreamAsync(System.IO.Stream input, System.IO.Stream output, int bufferSize)
        {
            byte[] buffer;
            int len;

            buffer = new byte[bufferSize];

            while ((len = await input.ReadAsync(buffer, 0, bufferSize)) > 0)
            {
                await output.WriteAsync(buffer, 0, len);
            }

            await output.FlushAsync();
        }

        private ZlibCompressionOptions GetOptions(ZlibCompressionOptions options)
        {
            var result = (options == null) ? new ZlibCompressionOptions(): options;

            if (result.CompressBufferSize <= 0)
                result.CompressBufferSize = 10420;

            if (result.DecompressBufferSize <= 0)
                result.DecompressBufferSize = 10420;

            return result;
        }
        public byte[] Decompress(byte[] data)
        {
            return Decompress(data, null);
        }
        public Task<byte[]> DecompressAsync(byte[] data)
        {
            return DecompressAsync(data, null);
        }
        public byte[] Decompress(byte[] data, ZlibCompressionOptions options)
        {
            var _options = GetOptions(options);
            var inStream = new MemoryStream();
            var bytes = data;

            inStream.Write(bytes, 0, bytes.Length);
            inStream.Position = 0;

            var outStream = new MemoryStream();
            var outZStream = new zlib.ZOutputStream(outStream);

            try
            {
                copyStream(inStream, outZStream, _options.DecompressBufferSize);
            }
            finally
            {
                outZStream.Close();
                outStream.Close();
                inStream.Close();
            }

            return outStream.ToArray();
        }
        public async Task<byte[]> DecompressAsync(byte[] data, ZlibCompressionOptions options)
        {
            var _options = GetOptions(options);
            var inStream = new MemoryStream();
            var bytes = data;

            await inStream.WriteAsync(bytes, 0, bytes.Length);
            inStream.Position = 0;

            var outStream = new MemoryStream();
            var outZStream = new zlib.ZOutputStream(outStream);

            try
            {
                await copyStreamAsync(inStream, outZStream, _options.DecompressBufferSize);
            }
            finally
            {
                outZStream.Close();
                outStream.Close();
                inStream.Close();
            }

            return outStream.ToArray();
        }
        public byte[] Compress(byte[] data)
        {
            return Compress(data, null);
        }
        public Task<byte[]> CompressAsync(byte[] data)
        {
            return CompressAsync(data, null);
        }
        public byte[] Compress(byte[] data, ZlibCompressionOptions options)
        {
            var _options = GetOptions(options);
            var bytes = data;
            var outStream = new MemoryStream();
            var inStream = new MemoryStream();

            inStream.Write(bytes, 0, bytes.Length);
            inStream.Position = 0;

            var outZStream = new zlib.ZOutputStream(outStream, zlib.zlibConst.Z_DEFAULT_COMPRESSION);

            try
            {
                copyStream(inStream, outZStream, _options.CompressBufferSize);
            }
            finally
            {
                outZStream.Close();
                outStream.Close();
                inStream.Close();
            }

            return outStream.ToArray();
        }
        public async Task<byte[]> CompressAsync(byte[] data, ZlibCompressionOptions options)
        {
            var _options = GetOptions(options);
            var bytes = data;
            var outStream = new MemoryStream();
            var inStream = new MemoryStream();

            await inStream.WriteAsync(bytes, 0, bytes.Length);
            inStream.Position = 0;

            var outZStream = new zlib.ZOutputStream(outStream, zlib.zlibConst.Z_DEFAULT_COMPRESSION);

            try
            {
                await copyStreamAsync(inStream, outZStream, _options.CompressBufferSize);
            }
            finally
            {
                outZStream.Close();
                outStream.Close();
                inStream.Close();
            }

            return outStream.ToArray();
        }
        public Stream Compress(Stream data)
        {
            return Compress(data, null);
        }
        public Task<Stream> CompressAsync(Stream data)
        {
            return CompressAsync(data, null);
        }
        public Stream Compress(Stream data, ZlibCompressionOptions options)
        {
            var _options = GetOptions(options);
            var outStream = new MemoryStream();
            var inStream = data;

            var outZStream = new zlib.ZOutputStream(outStream, zlib.zlibConst.Z_DEFAULT_COMPRESSION);

            try
            {
                copyStream(inStream, outZStream, _options.CompressBufferSize);
            }
            finally
            {
                outZStream.Close();
                outStream.Close();
                inStream.Close();
            }

            return outStream;
        }
        public async Task<Stream> CompressAsync(Stream data, ZlibCompressionOptions options)
        {
            var _options = GetOptions(options);
            var outStream = new MemoryStream();
            var inStream = data;

            var outZStream = new zlib.ZOutputStream(outStream, zlib.zlibConst.Z_DEFAULT_COMPRESSION);

            try
            {
                await copyStreamAsync(inStream, outZStream, _options.CompressBufferSize);
            }
            finally
            {
                outZStream.Close();
                outStream.Close();
                inStream.Close();
            }

            return outStream;
        }
        public Stream Decompress(Stream data)
        {
            return Decompress(data, null);
        }
        public Task<Stream> DecompressAsync(Stream data)
        {
            return DecompressAsync(data, null);
        }
        public Stream Decompress(Stream data, ZlibCompressionOptions options)
        {
            var _options = GetOptions(options);
            var inStream = data;
            var outStream = new MemoryStream();
            var outZStream = new zlib.ZOutputStream(outStream);

            try
            {
                copyStream(inStream, outZStream, _options.DecompressBufferSize);
            }
            finally
            {
                outZStream.Close();
                outStream.Close();
                inStream.Close();
            }

            return outStream;
        }
        public async Task<Stream> DecompressAsync(Stream data, ZlibCompressionOptions options)
        {
            var _options = GetOptions(options);
            var inStream = data;
            var outStream = new MemoryStream();
            var outZStream = new zlib.ZOutputStream(outStream);

            try
            {
                await copyStreamAsync(inStream, outZStream, _options.DecompressBufferSize);
            }
            finally
            {
                outZStream.Close();
                outStream.Close();
                inStream.Close();
            }

            return outStream;
        }
    }
}
