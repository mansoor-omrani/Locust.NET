using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Extensions
{
    public static class ResourceExtensions
    {
        public static string GetResourceText(this Assembly assembly, string resourceName)
        {
            var stream = assembly.GetManifestResourceStream(resourceName);
            var reader = new StreamReader(stream);
            var x = reader.ReadToEnd();

            return x;
        }
        public static byte[] GetResourceBytes(this Assembly assembly, string resourceName)
        {
            var stream = assembly.GetManifestResourceStream(resourceName);
            var result = new MemoryStream(new byte[stream.Length], true);
            stream.CopyTo(result);

            return result.ToArray();
        }
    }
}
