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
        DebugTraceSys = 14,
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
