using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Logging.Web
{
    public class LogItem
    {
        public string StackTrace { get; set; }
        public Exception Exception { get; set; }
        public string IP { get; set; }
        public string Referer { get; set; }
        public string Cookies { get; set; }
        public string Headers { get; set; }
        public string Message { get; set; }
        public string Method { get; set; }
        public string Url { get; set; }
        public string HostName { get; set; }
        public string FormData { get; set; }
        public string Body { get; set; }
        public string Browser { get; set; }
        public string Username { get; set; }
        public string RoleNames { get; set; }
        public string SessionId { get; set; }
        public string Member { get; set; }
        public string FilePath { get; set; }
        public int Line { get; set; }
        public LogItem()
        {
            StackTrace = "";
            IP = "";
            Referer = "";
            Cookies = "";
            Headers = "";
            Message = "";
            Method = "";
            Url = "";
            HostName = "";
            FormData = "";
            Body = "";
            Browser = "";
            Username = "";
            RoleNames = "";
            SessionId = "";
            Member = "";
            FilePath = "";
        }
        public LogItem(LogItem log)
        {
            StackTrace = log.StackTrace;
            Exception = log.Exception;
            IP = log.IP;
            Referer = log.Referer;
            Cookies = log.Cookies;
            Headers = log.Headers;
            Message = log.Message;
            Method = log.Method;
            Url = log.Url;
            HostName = log.HostName;
            FormData = log.FormData;
            Body = log.Body;
            Browser = log.Browser;
            Username = log.Username;
            RoleNames = log.RoleNames;
            SessionId = log.SessionId;
            Member = log.Member;
            FilePath = log.FilePath;
            Line = log.Line;
        }
    }
}
