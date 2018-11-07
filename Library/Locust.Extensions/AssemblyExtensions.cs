using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Extensions
{
    public static class AssemblyExtensions
    {
        private static ConcurrentDictionary<Assembly, string> assemblyNames = new ConcurrentDictionary<Assembly, string>();
        private static string GetAssemblyName(Assembly assembly)
        {
            return assemblyNames.GetOrAdd(assembly, assembly.GetName().Name);
        }
        public static List<Type> GetSubClasses<T>(this Assembly assembly, bool directDescendent = true)
        {
            return assembly.GetSubClasses(typeof(T), directDescendent);
        }
        public static List<Type> GetSubClasses(this Assembly assembly, Type type, bool directDescendent = true)
        {
            if (directDescendent)
                return assembly.GetTypes().Where(t => t.IsSubclassOf(type)).ToList();
            else
                return assembly.GetTypes().Where(t => t.DescendsFrom(type)).ToList();
        }
        public static bool IsNamespaceDefined(this Assembly assembly, string nameSpace, StringComparison comparison = StringComparison.Ordinal)
        {
            return
                (from type in assembly.GetTypes()
                 where string.Compare(type.Namespace, nameSpace, comparison) == 0
                 select type).Any();
        }
        public static bool IsTypeDefined(this Assembly assembly, string nameSpace, string className, StringComparison comparison = StringComparison.Ordinal)
        {
            return (from type in assembly.GetTypes()
                    where string.Compare(type.Name, className, comparison) == 0 && type.GetMethods().Any()
                    select type).FirstOrDefault() != null;
        }
        public static Stream GetResourceStream(this Assembly assembly, string name)
        {
            var assemblyName = GetAssemblyName(assembly);

            var result = assembly.GetManifestResourceStream(assemblyName + "." + name);

            return result;
        }
        public static string GetResourceString(this Assembly assembly, string name)
        {
            var stream = assembly.GetResourceStream(name);
            var reader = new StreamReader(stream);
            var result = reader.ReadToEnd();

            return result;
        }
        public static async Task<string> GetResourceStringAsync(this Assembly assembly, string name)
        {
            var stream = assembly.GetResourceStream(name);
            var reader = new StreamReader(stream);
            var result = await reader.ReadToEndAsync();

            return result;
        }
        public static byte[] GetResourceBytes(this Assembly assembly, string name)
        {
            var stream = assembly.GetResourceStream(name);
            var reader = new MemoryStream();
            stream.CopyTo(reader);
            var result = reader.ToArray();

            return result;
        }
        public static async Task<byte[]> GetResourceBytesAsync(this Assembly assembly, string name)
        {
            var stream = assembly.GetResourceStream(name);
            var reader = new MemoryStream();
            await stream.CopyToAsync(reader);
            var result = reader.ToArray();

            return result;
        }
        private static ConcurrentDictionary<Assembly, string[]> assemblyResourceNames = new ConcurrentDictionary<Assembly, string[]>();
        private static string[] GetResourceNames(Assembly assembly)
        {
            return assemblyResourceNames.GetOrAdd(assembly, assembly.GetManifestResourceNames());
        }
        public static bool ResourceExists(this Assembly assembly, string name)
        {
            var resourceNames = GetResourceNames(assembly);
            var assemblyName = GetAssemblyName(assembly);

            return resourceNames.Contains(assemblyName + "." + name);
        }
    }
}
