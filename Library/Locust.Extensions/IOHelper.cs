using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Extensions
{
    public static class IOHelper
    {
        public static bool IsDirectoryEmpty(string path)
        {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }
        public static long GetDirectorySize(string path, SearchOption options = SearchOption.AllDirectories)
        {
            var files = Directory.GetFiles(path, "*.*", options);

            long result = 0;

            foreach (string name in files)
            {
                var info = new System.IO.FileInfo(name);

                result += info.Length;
            }

            return result;
        }
    }
}
