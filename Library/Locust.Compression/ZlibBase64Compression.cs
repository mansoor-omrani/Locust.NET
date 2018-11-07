using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zlib = ComponentAce.Compression.Libs.zlib;

namespace Locust.Compression
{
    public class ZlibBase64Compression: IBase64Compression
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

        private ZlibBase64CompressionOptions GetOptions(Base64CompressionOptions options)
        {
            var result = (options == null)
                ? new ZlibBase64CompressionOptions()
                : (options as ZlibBase64CompressionOptions) ?? new ZlibBase64CompressionOptions();

            if (result.CompressBufferSize <= 0)
                result.CompressBufferSize = 10420;

            if (result.DecompressBufferSize <= 0)
                result.DecompressBufferSize = 10420;

            return result;
        }
        public string Base64Decompress(string data, Base64CompressionOptions options = null)
        {
            var _options = GetOptions(options);
            var inStream = new MemoryStream();
            var bytes = System.Convert.FromBase64String(data);

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

            var x = outStream.ToArray();

            return Encoding.UTF8.GetString(x);
        }
        public async Task<string> Base64DecompressAsync(string data, Base64CompressionOptions options = null)
        {
            var _options = GetOptions(options);
            var inStream = new MemoryStream();
            var bytes = System.Convert.FromBase64String(data);

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

            var x = outStream.ToArray();

            return Encoding.UTF8.GetString(x);
        }
        public string Base64Compress(string data, Base64CompressionOptions options = null)
        {
            var _options = GetOptions(options);
            var bytes = Encoding.UTF8.GetBytes(data);
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

            var x = outStream.ToArray();

            return System.Convert.ToBase64String(x);
        }
        public async Task<string> Base64CompressAsync(string data, Base64CompressionOptions options = null)
        {
            var _options = GetOptions(options);
            var bytes = Encoding.UTF8.GetBytes(data);
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

            var x = outStream.ToArray();

            return System.Convert.ToBase64String(x);
        }
    }
}
