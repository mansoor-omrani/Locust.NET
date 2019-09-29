using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Locust.Extensions;
using System.Runtime.CompilerServices;

namespace Locust.Logging
{
    public class FileLogger: BaseLogger
    {
        public FileLogger(string filename)
        {
            FileName = filename;
        }
        public FileLogger(string filename, BaseLogger next) : base(next)
        {
            FileName = filename;
        }
        public string FileName { get; set; }
        protected override void LogCategoryInternal(string data)
        {
            File.AppendAllText(FileName, data);
        }

        protected override void LogInternal(string data)
        {
            File.AppendAllText(FileName, data);
        }
    }
}
