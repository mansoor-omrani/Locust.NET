using Locust.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Logging
{
    [Flags]
    public enum LogMode
    {
        None = 0,
        App = 1,
        Debug = 2,
        Trace = 4,
        Sys = 8,

        AppDebug = 3,
        DebugApp = 3,

        AppTrace = 5,
        TraceApp = 5,

        DebugTrace = 6,
        TraceDebug = 6,

        AppDebugTrace = 7,
        AppTraceDebug = 7,
        DebugAppTrace = 7,
        DebugTraceApp = 7,
        TraceDebugApp = 7,
        TraceAppDebug = 7,
        AllButSys = 7,

        AppSys = 9,
        SysApp = 9,

        DebugSys = 10,
        SysDebug = 10,

        AppDebugSys = 11,
        AppSysDebug = 11,
        DebugAppSys = 11,
        DebugSysApp = 11,
        SysDebugApp = 11,
        SysAppDebug = 11,
        AllButTrace = 11,

        TraceSys = 12,
        SysTrace = 12,

        AppTraceSys = 13,
        AppSysTrace = 13,
        TraceAppSys = 13,
        TraceSysApp = 13,
        SysTraceApp = 13,
        SysAppTrace = 13,
        AllButDebug = 13,

        DebugTraceSys = 14,
        DebugSysTrace = 14,
        TraceDebugSys = 14,
        TraceSysDebug = 14,
        SysTraceDebug = 14,
        SysDebugTrace = 14,
        AllButApp = 14,

        All = 15
    }
    public interface ILogger
    {
        LogMode Mode { get; set; }
        void LogCategory(object category = null,
                        [CallerMemberName] string memberName = "",
                        [CallerFilePath] string sourceFilePath = "",
                        [CallerLineNumber] int sourceLineNumber = 0);
        void Log(object log);
        void App(object log);
        void Debug(object log);
        void Trace(object log);
        void Sys(object log);
        void Log(object category, object log);
        void App(object category, object log);
        void Debug(object category, object log);
        void Trace(object category, object log);
        void Sys(object category, object log);
    }
    public class LogItem
    {
        public long Row { get; set; }
        public int Id { get; set; }
        public DateTime LogDate { get; set; }
        public int? Line { get; set; }
        public string Member { get; set; }
        public string FilePath { get; set; }
        public string Category { get; set; }
        public string Message { get; set; }
    }
    public class LoggerGetPageRequest : ServiceRequest
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string Member { get; set; }
        public string Category { get; set; }
        public string Message { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string OrderBy { get; set; }
        public string OrderDir { get; set; }
    }
    public class LoggerGetPageResponse : ServicePagingResponse<LogItem>
    {
    }
    public class LoggerPurgeRequest : ServiceRequest
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
    public class LoggerPurgeResponse : ServiceResponse
    {
    }
    public interface ILogManager
    {
        LoggerPurgeResponse Purge(LoggerPurgeRequest request);
        LoggerGetPageResponse GetPage(LoggerGetPageRequest request);
    }
}
