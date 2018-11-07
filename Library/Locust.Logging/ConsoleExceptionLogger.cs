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
    public class ConsoleExceptionLogger : IExceptionLogger
    {
        public void LogException(Exception ex, string info = "",
                        [CallerMemberName] string memberName = "",
                        [CallerFilePath] string sourceFilePath = "",
                        [CallerLineNumber] int sourceLineNumber = 0)
        {
            System.Console.WriteLine("{0:yyyy/MM/dd HH:mm:ss.fffffff}", DateTime.Now);
            System.Console.WriteLine($"File: {sourceFilePath}, Line: {sourceLineNumber}, Member: {memberName}");
            System.Console.WriteLine(ex.ToString("\n"));

            if (!string.IsNullOrEmpty(info))
            {
                System.Console.WriteLine(info);
            }
            System.Console.WriteLine(info);
            System.Console.WriteLine();
        }
    }
}
