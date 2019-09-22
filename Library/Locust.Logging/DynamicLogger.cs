using Locust.AppPath;
using Locust.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Logging
{
    public enum LoggerType
    {
        Null,
        Console,
        Debug,
        Trace,
        String,
        File
    }
    public class DynamicLogger : ILogger
    {
        public ILogger Instance { get; protected set; }
        protected virtual ILogger GetFileLogger()
        {
            var filename = ConfigurationManager.AppSettings["Logger.File"];

            if (string.IsNullOrEmpty(filename))
            {
                filename = ApplicationPath.Root + "\\logs.log";
            }

            var result = new FileLogger(filename);

            return result;
        }
        public DynamicLogger()
        {
            var type = ConfigHelper.AppSetting("Logger.Type", LoggerType.Null);

            switch (type)
            {
                case LoggerType.Null: Instance = new NullLogger(); break;
                case LoggerType.Console: Instance = new ConsoleLogger(); break;
                case LoggerType.Debug: Instance = new DebugLogger(); break;
                case LoggerType.Trace: Instance = new TraceLogger(); break;
                case LoggerType.String: Instance = new StringLogger(); break;
                case LoggerType.File: Instance = GetFileLogger(); break;
                default:
                    throw new Exception("invalid logger type: " + type);
            }
        }
        public void Log(object log)
        {
            Instance.Log(log);
        }

        public void LogCategory(object category = null,
                        [CallerMemberName] string memberName = "",
                        [CallerFilePath] string sourceFilePath = "",
                        [CallerLineNumber] int sourceLineNumber = 0)
        {
            Instance.LogCategory(category, memberName, sourceFilePath, sourceLineNumber);
        }
    }
}
