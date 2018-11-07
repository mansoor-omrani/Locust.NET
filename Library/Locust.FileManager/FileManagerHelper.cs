using Locust.Extensions;
using Locust.Resources;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.FileManager
{
    public static class FileManagerHelper
    {
        public static async Task<byte[]> GetImageAsync(string extension)
        {
            var result = null as byte[];
            var file = "";

            extension = extension?.Trim().ToLower();

            if (!string.IsNullOrEmpty(extension))
            {
                if (extension[0] == '.')
                {
                    extension = extension.Substring(1);
                }

                if (typeof(FileManagerHelper).Assembly.ResourceExists("image." + extension + ".png"))
                {
                    file = extension + ".png";
                }
            }
            
            if (string.IsNullOrEmpty(file))
            {
                file = "file.png";
            }

            try
            {
                result = await typeof(FileManagerHelper).Assembly.GetResourceBytesAsync("image." + file);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            if (result == null || result.Length == 0)
            {
                // This is the Base64 of 'image/file.png'

                result = System.Convert.FromBase64String("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");
            }

            return result;
        }
    }
}
