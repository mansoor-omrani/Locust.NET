using Locust.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Logging
{
    public class FileExceptionLogger : BaseExceptionLogger
    {
        public string FileName { get; set; }
        public string Format { get; set; }
        public FileExceptionLogger(string filename)
        {
            FileName = filename;
            Format = "{date}\nCalling {method} failed. Line {line} at {file}\nInfo: {info}\nSource: {source}\n{exception}\n\n{stack}\n" + new string('-', 80) + "\n";
        }
        public FileExceptionLogger(string filename, BaseExceptionLogger next) : base(next)
        {
            FileName = filename;
        }
        protected override bool LogExceptionInternal(Exception ex, string info = "", string memberName = "", string sourceFilePath = "", int sourceLineNumber = 0)
        {
            var data = Format
                             .Replace("{date}", string.Format("{0:yyyy/MM/dd HH:mm:ss.fffffff}", DateTime.Now))
                             .Replace("{method}", memberName)
                             .Replace("{line}", sourceLineNumber.ToString())
                             .Replace("{file}", sourceFilePath)
                             .Replace("{info}", info)
                             .Replace("{source}", ex.Source)
                             .Replace("{exception}", ex.ToString("\n"))
                             .Replace("{stacktrace}", ex.StackTrace);
            
            try
            {
                File.AppendAllText(FileName, data);

                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
