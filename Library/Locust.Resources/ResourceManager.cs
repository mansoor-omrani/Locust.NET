using Locust.Extensions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Resources
{
    public static class ResourceManager
    {
        public static Stream GetResourceStream(string name)
        {
            var assembly = Assembly.GetCallingAssembly();
            
            return assembly.GetResourceStream(name);
        }
        public static string GetResourceString(string name)
        {
            var stream = GetResourceStream(name);
            var reader = new StreamReader(stream);
            var result = reader.ReadToEnd();

            return result;
        }
        public static async Task<string> GetResourceStringAsync(string name)
        {
            var stream = GetResourceStream(name);
            var reader = new StreamReader(stream);
            var result = await reader.ReadToEndAsync();

            return result;
        }
        public static byte[] GetResourceBytes(string name)
        {
            var stream = GetResourceStream(name);
            var reader = new MemoryStream();
            stream.CopyTo(reader);
            var result = reader.ToArray();

            return result;
        }
        public static async Task<byte[]> GetResourceBytesAsync(string name)
        {
            var stream = GetResourceStream(name);
            var reader = new MemoryStream();
            await stream.CopyToAsync(reader);
            var result = reader.ToArray();

            return result;
        }
        private static ConcurrentDictionary<Assembly, string[]> resourceNames = new ConcurrentDictionary<Assembly, string[]>();
        // helper source: https://stackoverflow.com/questions/4723772/wpf-check-resource-exists-without-structured-exception-handling
        public static bool ResourceExists(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var _resourceNames = resourceNames.GetOrAdd(assembly, assembly.GetManifestResourceNames());
            
            return _resourceNames.Contains(resourceName);
        }
    }
}
