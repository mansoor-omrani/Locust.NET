using Locust.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Logging
{
    public class DebugExceptionLogger : IExceptionLogger
    {
        public void LogException(Exception ex, string info = "",
                        [CallerMemberName] string memberName = "",
                        [CallerFilePath] string sourceFilePath = "",
                        [CallerLineNumber] int sourceLineNumber = 0)
        {
            Debug.WriteLine("{0:yyyy/MM/dd HH:mm:ss.fffffff}", DateTime.Now);
            Debug.WriteLine($"File: {sourceFilePath}, Line: {sourceLineNumber}, Member: {memberName}");
            Debug.WriteLine(ex.ToString("\n"));
            if (!string.IsNullOrEmpty(info))
            {
                Debug.WriteLine(info);
            }
            Debug.WriteLine("");
        }
    }
}
