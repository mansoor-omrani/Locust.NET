using Locust.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Logging
{
    public class ConsoleExceptionLogger : BaseExceptionLogger
    {
        public ConsoleExceptionLogger()
        {
        }
        public ConsoleExceptionLogger(BaseExceptionLogger next) : base(next)
        {
        }

        protected override bool LogExceptionInternal(Exception ex, string info = "", string memberName = "", string sourceFilePath = "", int sourceLineNumber = 0)
        {
            System.Console.WriteLine("{0:yyyy/MM/dd HH:mm:ss.fffffff}", DateTime.Now);
            System.Console.WriteLine($"File: {sourceFilePath}, Line: {sourceLineNumber}, Member: {memberName}");
            System.Console.WriteLine(ex.ToString("\n"));
            System.Console.WriteLine(ex.StackTrace);

            if (!string.IsNullOrEmpty(info))
            {
                System.Console.WriteLine(info);
            }

            System.Console.WriteLine(info);
            System.Console.WriteLine();

            return true;
        }
    }
}
