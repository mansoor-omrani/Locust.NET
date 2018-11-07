using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Locust.WebExtensions
{
    public static class HttpPostedFileExtensions
    {
        public static int DefaultBufferSize = 8192;
        public static async Task<byte[]> GetBytesAsync(this HttpPostedFileBase file, int bufferSize, CancellationToken token)
        {
            using (var ms = new MemoryStream())
            {
                await file.InputStream.CopyToAsync(ms, bufferSize, token);
                return ms.ToArray();
            }
        }
        public static Task<byte[]> GetBytesAsync(this HttpPostedFileBase file)
        {
            return file.GetBytesAsync(DefaultBufferSize, CancellationToken.None);
        }
    }
}
