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
        File,
        SqlServer,
        ConsoleDebug,
        FileConsole,
        FileDebug,
        FileConsoleDebug,
        FileSqlServer,
        SqlServerFile,
        SqlServerFileConsole,
        SqlServerFileDebug,
        SqlServerFileConsoleDebug,
        ConsoleSqlServer,
        DebugSqlServer,
        ConsoleDebugSqlServer,
        ConsoleFileSqlServer,
        DebugFileSqlServer,
        ConsoleDebugFileSqlServer
    }
    public class DynamicLogger : ILogger
    {
        public ILogger Instance { get; protected set; }
        protected virtual LoggerType GetLogType()
        {
            var value = ConfigurationManager.AppSettings["Logger.Type"];

            LoggerType result;

            if (!Enum.TryParse(value, out result))
            {
                result = LoggerType.Null;
            }

            return result;
        }
        public DynamicLogger()
        {
            var type = GetLogType();

            switch (type)
            {
                case LoggerType.Null:
                    Instance = new NullLogger();
                    break;
                case LoggerType.Console:
                    Instance = new ConsoleLogger();
                    break;
                case LoggerType.Debug:
                    Instance = new DebugLogger();
                    break;
                case LoggerType.Trace:
                    Instance = new TraceLogger();
                    break;
                case LoggerType.String:
                    Instance = new StringLogger();
                    break;
                case LoggerType.File:
                    Instance = CreateFileLogger();
                    break;
                case LoggerType.SqlServer:
                    Instance = CreateSqlServerLogger();
                    break;
                case LoggerType.FileSqlServer:
                    Instance = CreateFileLogger(CreateSqlServerLogger());
                    break;
                case LoggerType.ConsoleDebug:
                    Instance = new ConsoleLogger(new DebugLogger());
                    break;
                case LoggerType.FileConsole:
                    Instance = CreateFileLogger(new ConsoleLogger());
                    break;
                case LoggerType.FileDebug:
                    Instance = CreateFileLogger(new DebugLogger());
                    break;
                case LoggerType.FileConsoleDebug:
                    Instance = CreateFileLogger(new ConsoleLogger(new DebugLogger()));
                    break;
                case LoggerType.SqlServerFile:
                    Instance = CreateSqlServerLogger(CreateFileLogger());
                    break;
                case LoggerType.SqlServerFileConsole:
                    Instance = CreateSqlServerLogger(CreateFileLogger(new ConsoleLogger()));
                    break;
                case LoggerType.SqlServerFileDebug:
                    Instance = CreateSqlServerLogger(CreateFileLogger(new DebugLogger()));
                    break;
                case LoggerType.SqlServerFileConsoleDebug:
                    Instance = CreateSqlServerLogger(CreateFileLogger(new ConsoleLogger(new DebugLogger())));
                    break;
                case LoggerType.ConsoleSqlServer:
                    Instance = new ConsoleLogger(CreateSqlServerLogger());
                    break;
                case LoggerType.DebugSqlServer:
                    Instance = new DebugLogger(CreateSqlServerLogger());
                    break;
                case LoggerType.ConsoleDebugSqlServer:
                    Instance = new ConsoleLogger(new DebugLogger(CreateSqlServerLogger()));
                    break;
                case LoggerType.ConsoleFileSqlServer:
                    Instance = new ConsoleLogger(CreateFileLogger(CreateSqlServerLogger()));
                    break;
                case LoggerType.DebugFileSqlServer:
                    Instance = new DebugLogger(CreateFileLogger(CreateSqlServerLogger()));
                    break;
                case LoggerType.ConsoleDebugFileSqlServer:
                    Instance = new ConsoleLogger(new DebugLogger(CreateFileLogger(CreateSqlServerLogger())));
                    break;
                default:
                    throw new Exception("invalid logger type: " + type);
            }
        }
        protected virtual string SqlServerLoggerType
        {
            get { return "Locust.Logging.SqlServer.SqlServerLogger"; }
        }

        public LogMode Mode
        {
            get
            {
                return Instance.Mode;
            }
            set
            {
                Instance.Mode = value;
            }
        }

        protected virtual BaseLogger CreateFileLogger(BaseLogger next = null)
        {
            BaseLogger result;

            var filename = ConfigurationManager.AppSettings["Logger.File"];

            if (string.IsNullOrEmpty(filename))
            {
                filename = ApplicationPath.Root + "\\logs.log";
            }

            if (next == null)
                result = new FileLogger(filename);
            else
                result = new FileLogger(filename, next);

            return result;
        }
        protected virtual BaseLogger CreateSqlServerLogger(params object[] args)
        {
            BaseLogger result = null;
            var _type = Type.GetType(SqlServerLoggerType);

            if (_type == null)
            {
                foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
                {
                    _type = asm.GetType(SqlServerLoggerType);

                    if (_type != null)
                        break;
                }
            }

            if (_type != null)
            {
                result = (Activator.CreateInstance(_type, args)) as BaseLogger;
            }
            else
            {
                throw new Exception($"{SqlServerLoggerType} was not found");
            }

            return result;
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

        public void Log(object category, object log)
        {
            Instance.Log(category, log);
        }

        public void Debug(object log)
        {
            Instance.Debug(log);
        }

        public void Trace(object log)
        {
            Instance.Trace(log);
        }

        public void Sys(object log)
        {
            Instance.Sys(log);
        }

        public void Debug(object category, object log)
        {
            Instance.Debug(category, log);
        }

        public void Trace(object category, object log)
        {
            Instance.Trace(category, log);
        }

        public void Sys(object category, object log)
        {
            Instance.Sys(category, log);
        }

        public void App(object log)
        {
            Instance.App(log);
        }

        public void App(object category, object log)
        {
            Instance.App(category, log);
        }
    }
}
