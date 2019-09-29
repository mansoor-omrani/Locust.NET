using Locust.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Logging
{
    public interface ILogger
    {
        void LogCategory(object category = null,
                        [CallerMemberName] string memberName = "",
                        [CallerFilePath] string sourceFilePath = "",
                        [CallerLineNumber] int sourceLineNumber = 0);
        void Log(object log);
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
