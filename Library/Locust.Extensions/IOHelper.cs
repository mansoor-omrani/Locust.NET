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
        public static string GetFullPath(string defaultRoot, string defaultBasePath, string defaultPath, string defaultFileName, string path, string filename)
        {
            var result = "";
            var root = defaultRoot;

            if (!Path.IsPathRooted(path))
            {
                if (string.IsNullOrEmpty(defaultBasePath))
                {
                    result = root;
                }
                else
                {
                    result = defaultBasePath;
                }

                if (string.IsNullOrEmpty(path))
                {
                    result += "\\" + defaultPath;
                }
                else
                {
                    result += "\\" + path;
                }
            }
            else
            {
                if (path.IndexOf(':') < 0)
                {
                    result = root.Left(root.IndexOf(':') + 1);
                }
                else
                {
                    result = path;
                }
            }


            if (string.IsNullOrEmpty(filename))
            {
                result += "\\" + defaultFileName;
            }
            else
            {
                result += "\\" + filename;
            }

            result = Path.GetFullPath(result);

            return result;
        }
    }
}
