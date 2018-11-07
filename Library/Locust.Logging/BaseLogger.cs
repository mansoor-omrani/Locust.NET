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
    public abstract class BaseLogger : ILogger
    {
        public void Log(object log)
        {
            string x = null;

            if (log != null)
            {
                if (log.GetType().IsNullableOrBasicType())
                    x = log.ToString();
                else
                {
                    x = JsonConvert.SerializeObject(log, Formatting.Indented);
                }
            }

            var data = string.Format("{0:yyyy/MM/dd HH:mm:ss.fffffff}       {1}\n", DateTime.Now, x);

            LogInternal(data);
        }
        protected abstract void LogCategoryInternal(string data);
        public void LogCategory(object category = null,
                [CallerMemberName] string memberName = "",
                [CallerFilePath] string sourceFilePath = "",
                [CallerLineNumber] int sourceLineNumber = 0)
        {
            var d = DateTime.Now;
            var data = string.Format("\n{0:yyyy/MM/dd HH:mm:ss.fffffff}   {1}\n", d, ((category != null) ? category + ":" : "")) +
                        $"  Member: {memberName}\n  File: {sourceFilePath}\n  Line: {sourceLineNumber}\n";

            LogCategoryInternal(data);
        }
        protected abstract void LogInternal(string data);
    }
}
