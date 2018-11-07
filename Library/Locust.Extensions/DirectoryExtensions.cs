using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Extensions
{
    public static class DirectoryExtensions
    {
        // source: http://stackoverflow.com/questions/2023975/renaming-a-directory-in-c-sharp
        //public static void RenameTo(this DirectoryInfo di, string name)
        //{
        //    if (di == null)
        //    {
        //        throw new ArgumentNullException("di", "Directory info to rename cannot be null");
        //    }

        //    if (string.IsNullOrWhiteSpace(name))
        //    {
        //        throw new ArgumentException("New name cannot be null or blank", "name");
        //    }

        //    di.MoveTo(Path.Combine(di.Parent.FullName, name));
        //}
    }
}
