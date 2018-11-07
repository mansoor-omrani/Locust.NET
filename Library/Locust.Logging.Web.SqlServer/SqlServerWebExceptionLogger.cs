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
using Locust.Conversion;
using Locust.Extensions;
using Locust.WebExtensions;
using Locust.ConnectionString;
using System.Runtime.CompilerServices;
using Locust.Logging;
using Locust.Logging.Web;
using System.Collections;

namespace Locust.Logging.Web.SqlServer
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
        private void FinishLoggingException(LogItem log, string info)
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
        ,[Source]
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
        ,[Data]
	 )
     VALUES
	 (
		case when len(rtrim(ltrim(isnull(@Username, '')))) = 0 then null else @Username end,
        case when len(rtrim(ltrim(isnull(@RoleName, '')))) = 0 then null else @RoleName end,
        case when len(rtrim(ltrim(isnull(@SessionId, '')))) = 0 then null else @SessionId end,
        case when len(rtrim(ltrim(isnull(@Url, '')))) = 0 then null else @Url end,
        case when len(rtrim(ltrim(isnull(@FormData, '')))) = 0 then null else @FormData end,
        case when len(rtrim(ltrim(isnull(@Headers, '')))) = 0 then null else @Headers end,
        case when len(rtrim(ltrim(isnull(@Message, '')))) = 0 then null else @Message end,
        case when len(rtrim(ltrim(isnull(@Source, '')))) = 0 then null else @Source end,
        case when len(rtrim(ltrim(isnull(@StackTrace, '')))) = 0 then null else @StackTrace end,
        case when len(rtrim(ltrim(isnull(@IP, '')))) = 0 then null else @IP end,
        case when len(rtrim(ltrim(isnull(@Cookies, '')))) = 0 then null else @Cookies end,
        case when len(rtrim(ltrim(isnull(@HostName, '')))) = 0 then null else @HostName end,
        case when len(rtrim(ltrim(isnull(@Method, '')))) = 0 then null else @Method end,
        case when len(rtrim(ltrim(isnull(@Referer, '')))) = 0 then null else @Referer end,
        case when len(rtrim(ltrim(isnull(@Info, '')))) = 0 then null else @Info end,
        case when len(rtrim(ltrim(isnull(@Browser, '')))) = 0 then null else @Browser end,
        case when len(rtrim(ltrim(isnull(@Member, '')))) = 0 then null else @Member end,
        case when len(rtrim(ltrim(isnull(@FilePath, '')))) = 0 then null else @FilePath end,
        case when len(rtrim(ltrim(isnull(@Line, '')))) = 0 then null else @Line end,
        case when len(rtrim(ltrim(isnull(@Data, '')))) = 0 then null else @Data end
	)";
            if (ConnectionStringProvider != null)
            {
                var constr = ConnectionStringProvider.GetConnectionString();

                if (!string.IsNullOrEmpty(constr))
                {
                    var data = "";

                    if (log.Exception.Data != null)
                    {
                        foreach (DictionaryEntry de in log.Exception.Data)
                        {
                            data += $"{(data == "" ? "" : ", ")}{de.Key}={de.Value}";
                        }
                    }

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
                            cmd.Parameters.AddWithValue("@Source", log.Exception.Source);
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
                            cmd.Parameters.AddWithValue("@Data", data);

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
        private bool StartLoggingException(HttpContextBase context, Exception ex, string info = "", string memberName = "", string sourceFilePath = "", int sourceLineNumber = 0)
        {
            var log = new LogItem();

            log.Exception = ex;
            log.StackTrace = ex.StackTrace;
            log.Message = ex.ToString(" --> ");
            log.Member = memberName;
            log.FilePath = sourceFilePath;
            log.Line = sourceLineNumber;

            if (context != null)
            {
                var req = context.Request;
                log.IP = req.GetClientIpAddress();

                if (req.UrlReferrer != null)
                {
                    log.Referer = req.UrlReferrer.OriginalString;
                }

                log.Headers = req.Headers?.Join("\n");
                log.Cookies = req.Cookies?.Join("\n");
                log.Method = req.HttpMethod;
                log.HostName = req.UserHostName;
                log.Url = req.Url?.ToString();
                log.FormData = req.Form?.Join("\n");

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
                    log.RoleNames = context.User.Identity.GetRoleNames();
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

            FinishLoggingException(log, info);

            return true;
        }
        public void LogException(HttpContextBase context, Exception ex, string info = "", [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            StartLoggingException(context, ex, info, memberName, sourceFilePath, sourceLineNumber);
        }

        protected override bool LogExceptionInternal(Exception ex, string info = "", string memberName = "", string sourceFilePath = "", int sourceLineNumber = 0)
        {
            var context = new HttpContextWrapper(HttpContext.Current);

            return StartLoggingException(context, ex, info, memberName, sourceFilePath, sourceLineNumber);
        }
    }
}
