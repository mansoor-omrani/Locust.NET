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
    public enum ExceptionLoggerType
    {
        Null,
        Console,
        Debug,
        File,
        Memory,
        SqlServer,
        FileNull,
        FileConsoleNull,
        FileDebugNull,
        SqlServerNull,
        SqlServerConsoleNull,
        SqlServerDebugNull,
        SqlServerFileConsoleNull,
        SqlServerFileDebugNull,
        SqlServerFileMemoryConsoleNull,
        SqlServerFileMemoryDebugNull
    }
    public class DynamicExceptionLogger : IExceptionLogger
    {
        protected virtual string SqlServerEceptionLoggerType
        {
            get { return "Locust.Logging.SqlServer.SqlServerExceptionLogger"; }
        }
        public IExceptionLogger Instance { get; protected set; }
        protected virtual FileExceptionLogger CreateFileExceptionLogger(BaseExceptionLogger next = null)
        {
            FileExceptionLogger result;

            var filename = ConfigurationManager.AppSettings["ExceptionLogger.File"];

            if (string.IsNullOrEmpty(filename))
            {
                filename = ApplicationPath.Root + "\\exceptions.log";
            }

            if (next == null)
                result = new FileExceptionLogger(filename);
            else
                result = new FileExceptionLogger(filename, next);

            return result;
        }
        protected virtual void CreateSqlServerExceptionLogger(params object[] args)
        {
            var _type = Type.GetType(SqlServerEceptionLoggerType);

            if (_type == null)
            {
                foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
                {
                    _type = asm.GetType(SqlServerEceptionLoggerType);

                    if (_type != null)
                        break;
                }
            }

            if (_type != null)
            {
                Instance = (Activator.CreateInstance(_type, args)) as IExceptionLogger;
            }
            else
            {
                throw new Exception($"{SqlServerEceptionLoggerType} was not found");
            }
        }
        protected virtual IMemoryLogger CreateMemoryLogger()
        {
            return new DefaultMemoryLogger();
        }
        public DynamicExceptionLogger()
        {
            var type = ConfigHelper.AppSetting("ExceptionLogger.Type", ExceptionLoggerType.Null);
            
            switch (type)
            {
                case ExceptionLoggerType.Null:
                    Instance = new NullExceptionLogger();
                    break;
                case ExceptionLoggerType.Console:
                    Instance = new ConsoleExceptionLogger();
                    break;
                case ExceptionLoggerType.Debug:
                    Instance = new DebugExceptionLogger();
                    break;
                case ExceptionLoggerType.File:
                    Instance = CreateFileExceptionLogger();
                    break;
                case ExceptionLoggerType.Memory:
                    Instance = new MemoryExceptionLogger(CreateMemoryLogger());
                    break;
                case ExceptionLoggerType.SqlServer:
                    CreateSqlServerExceptionLogger();
                    break;
                case ExceptionLoggerType.SqlServerNull:
                    CreateSqlServerExceptionLogger(new NullExceptionLogger());
                    break;
                case ExceptionLoggerType.SqlServerConsoleNull:
                    CreateSqlServerExceptionLogger(new ConsoleExceptionLogger(new NullExceptionLogger()));
                    break;
                case ExceptionLoggerType.SqlServerDebugNull:
                    CreateSqlServerExceptionLogger(new DebugExceptionLogger(new NullExceptionLogger()));
                    break;
                case ExceptionLoggerType.SqlServerFileConsoleNull:
                    CreateSqlServerExceptionLogger(CreateFileExceptionLogger(new ConsoleExceptionLogger(new NullExceptionLogger())));
                    break;
                case ExceptionLoggerType.SqlServerFileDebugNull:
                    CreateSqlServerExceptionLogger(CreateFileExceptionLogger(new DebugExceptionLogger(new NullExceptionLogger())));
                    break;
                case ExceptionLoggerType.SqlServerFileMemoryConsoleNull:
                    CreateSqlServerExceptionLogger(CreateFileExceptionLogger(new MemoryExceptionLogger(CreateMemoryLogger(), new ConsoleExceptionLogger(new NullExceptionLogger()))));
                    break;
                case ExceptionLoggerType.SqlServerFileMemoryDebugNull:
                    CreateSqlServerExceptionLogger(CreateFileExceptionLogger(new MemoryExceptionLogger(CreateMemoryLogger(), new DebugExceptionLogger(new NullExceptionLogger()))));
                    break;
                case ExceptionLoggerType.FileNull:
                    Instance = CreateFileExceptionLogger(new NullExceptionLogger());
                    break;
                case ExceptionLoggerType.FileConsoleNull:
                    Instance = CreateFileExceptionLogger(new ConsoleExceptionLogger(new NullExceptionLogger()));
                    break;
                case ExceptionLoggerType.FileDebugNull:
                    Instance = CreateFileExceptionLogger(new DebugExceptionLogger(new NullExceptionLogger()));
                    break;
                default:
                    throw new Exception("invalid exception logger type: " + type);
            }
        }
        public void LogException(Exception ex, string info = "", [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            Instance.LogException(ex, info, memberName, sourceFilePath, sourceLineNumber);
        }
    }
}
