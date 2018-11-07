using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Locust.Conversion;
using Locust.Extensions;
using Locust.WebExtensions;
using Locust.WebTools;
using Locust.ConnectionString;
using System.Runtime.CompilerServices;

namespace Locust.Logging.Web
{
    public class SqlServerWebExceptionLogger: BaseExceptionLogger, IWebExceptionLogger
    {
        public IConnectionStringProvider ConnectionStringProvider { get; set; }
        public string LogTableName { get; set; }
        public SqlServerWebExceptionLogger()
        {
            Init(new AppConfigConnectionStringProvider());
        }
        public SqlServerWebExceptionLogger(BaseExceptionLogger next) : base(next)
        {
            Init(new AppConfigConnectionStringProvider());
        }
        public SqlServerWebExceptionLogger(IConnectionStringProvider constrProvider)
        {
            Init(constrProvider);
        }
        public SqlServerWebExceptionLogger(IConnectionStringProvider constrProvider, BaseExceptionLogger next):base(next)
        {
            Init(constrProvider);
        }
        private void Init(IConnectionStringProvider constrProvider)
        {
            if (constrProvider == null)
            {
                throw new ArgumentNullException("constrProvider");
            }

            ConnectionStringProvider = constrProvider;

            LogTableName = "[dbo].[WebExceptionLog]";
        }
        private void LogInternal(LogItem log, string info)
        {
            var query =
$@"  INSERT INTO {LogTableName}
	(
		 [Username]
		,[RoleName]
        ,[SessionId]
		,[Url]
		,[FormData]
		,[Headers]
		,[Message]
		,[StackTrace]
		,[IP]
		,[Cookies]
		,[HostName]
		,[Method]
		,[Referer]
		,[Info]
		,[Browser]
        ,[Member]
        ,[FilePath]
        ,[Line]
	 )
     VALUES
	 (
		@Username,
        @RoleName,
        @SessionId,
        @Url,
        @FormData,
        @Headers,
        @Message,
        @StackTrace,
        @IP,
        @Cookies,
        @HostName,
        @Method,
        @Referer,
        @Info,
        @Browser,
        @Member,
        @FilePath,
        @Line)
	)";
            if (ConnectionStringProvider != null)
            {
                var constr = ConnectionStringProvider.GetConnectionString();

                if (!string.IsNullOrEmpty(constr))
                {
                    using (var con = new SqlConnection(constr))
                    {
                        using (var cmd = new SqlCommand(query, con))
                        {
                            cmd.CommandType = CommandType.Text;

                            cmd.Parameters.AddWithValue("@Username", SafeClrConvert.ToString(log.Username).Left(50));
                            cmd.Parameters.AddWithValue("@RoleName", SafeClrConvert.ToString(log.RoleNames).Left(50));
                            cmd.Parameters.AddWithValue("@SessionId", SafeClrConvert.ToString(log.SessionId).Left(100));
                            cmd.Parameters.AddWithValue("@Url", SafeClrConvert.ToString(log.Url).Left(500));
                            cmd.Parameters.AddWithValue("@FormData", SafeClrConvert.ToString(log.FormData).Left(4000));
                            cmd.Parameters.AddWithValue("@Headers", SafeClrConvert.ToString(log.Headers).Left(500));
                            cmd.Parameters.AddWithValue("@Message", SafeClrConvert.ToString(log.Message).Left(4000));
                            cmd.Parameters.AddWithValue("@StackTrace", SafeClrConvert.ToString(log.StackTrace));
                            cmd.Parameters.AddWithValue("@IP", SafeClrConvert.ToString(log.IP).Left(40));
                            cmd.Parameters.AddWithValue("@Cookies", SafeClrConvert.ToString(log.Cookies).Left(4000));
                            cmd.Parameters.AddWithValue("@HostName", SafeClrConvert.ToString(log.HostName).Left(30));
                            cmd.Parameters.AddWithValue("@Method", log.Method);
                            cmd.Parameters.AddWithValue("@Referer", log.Referer);
                            cmd.Parameters.AddWithValue("@Info", SafeClrConvert.ToString(info).Left(4000));
                            cmd.Parameters.AddWithValue("@Browser", log.Browser);
                            cmd.Parameters.AddWithValue("@Member", log.Member);
                            cmd.Parameters.AddWithValue("@FilePath", log.FilePath);
                            cmd.Parameters.AddWithValue("@Line", log.Line);

                            con.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                else
                {
                    Throw($"No ConnectionString: Provider = {ConnectionStringProvider.GetType().Name}");
                }
            }
            else
            {
                Throw($"No ConnectionString Provider");
            }
        }
        private bool LogExceptionInternal(HttpContextBase context, Exception ex, string info = "", string memberName = "", string sourceFilePath = "", int sourceLineNumber = 0)
        {
            var log = new LogItem();

            log.StackTrace = ex.StackTrace;
            log.Message = ex.ToString(" --> ");

            if (context != null)
            {
                var req = context.Request;
                log.IP = req.GetClientIpAddress();

                if (req.UrlReferrer != null)
                {
                    log.Referer = req.UrlReferrer.OriginalString;
                }

                log.Headers = context.Request.Headers.Join();
                log.Cookies = req.Cookies.Join();
                log.Method = req.HttpMethod;
                log.HostName = req.UserHostName;
                log.Url = req.Url.ToString();
                log.FormData = req.Form.Join();

                if (string.IsNullOrEmpty(log.FormData) && string.Compare(req.HttpMethod, "post", true) == 0)
                {
                    try
                    {
                        using (var receiveStream = req.InputStream)
                        {
                            using (var readStream = new StreamReader(receiveStream, Encoding.UTF8))
                            {
                                log.FormData = readStream.ReadToEnd();
                            }
                        }

                        if (string.IsNullOrEmpty(log.FormData))
                        {
                            log.FormData = SafeClrConvert.ToString(context.Items["x_request_body"]);

                            if (!string.IsNullOrEmpty(log.FormData))
                            {
                                log.FormData = "body: " + log.FormData;
                            }
                        }
                    }
                    catch (Exception ex2)
                    {
                        log.FormData = "Logger.LogException: " + ex2.Message;
                    }

                }

                if (req.Browser != null)
                {
                    log.Browser = req.Browser.Type + " " + req.Browser.Version;
                }
                if (context.User != null && context.User.Identity != null)
                {
                    log.Username = context.User.Identity.Name;
                    log.RoleNames = context.User.Identity.GetRoleName();
                }

                if (context.Session != null)
                {
                    log.SessionId = context.Session.SessionID;
                }
            }
            else
            {
                Throw("No HttpContext");
            }

            LogInternal(log, info);

            return true;
        }
        public void LogException(HttpContextBase context, Exception ex, string info = "", [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            LogExceptionInternal(context, ex, info, memberName, sourceFilePath, sourceLineNumber);
        }

        protected override bool LogExceptionInternal(Exception ex, string info = "", string memberName = "", string sourceFilePath = "", int sourceLineNumber = 0)
        {
            var httpContext = new HttpContextWrapper(HttpContext.Current);

            return LogExceptionInternal(httpContext, ex, info, memberName, sourceFilePath, sourceLineNumber);
        }
    }
}
