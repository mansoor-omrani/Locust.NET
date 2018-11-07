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

namespace Locust.Logging.Web
{
    public class DefaultRequestLogger: IRequestLogger
    {
        private IMemoryLogger _memoryLogger;

        public DefaultRequestLogger(IMemoryLogger memoryLogger)
        {
            _memoryLogger = memoryLogger;
        }
        public void Log(HttpRequest request, string info = "", long executionTime = 0)
        {
            var httpRequestBase = new HttpRequestWrapper(request);

            Log(httpRequestBase, info, executionTime);
        }
        public void Log(HttpRequestBase request, string info = "", long executionTime = 0)
        {
            var log = new LogItem();
            var req = request;

            if (req != null)
            {
                log.IP = req.GetClientIpAddress();

                if (req.UrlReferrer != null)
                {
                    log.Referer = req.UrlReferrer.OriginalString;
                }

                var sb = new StringBuilder();
                var count = 0;

                foreach (var name in req.Cookies)
                {
                    var cookie = req.Cookies[name.ToString()];

                    if (cookie != null)
                    {
                        sb.Append((count == 0 ? "" : ",") + SafeClrConvert.ToString(cookie.Name) + "=" + cookie.Value);

                        count++;
                    }
                }

                log.Cookies = sb.ToString();
                log.Method = req.HttpMethod;
                log.HostName = req.UserHostName;
                
                if (req.Url != null)
                {
                    log.Url = req.Url.ToString();
                }

                log.FormData = req.Form.Join();
                log.Headers = req.Headers.Join(new List<string> { "cookie" });

                if (string.Compare(req.HttpMethod, "post", true) == 0)
                {
                    try
                    {
                        using (var receiveStream = req.InputStream)
                        {
                            using (var readStream = new StreamReader(receiveStream, Encoding.UTF8))
                            {
                                log.Body = readStream.ReadToEnd();
                            }

                            if (string.IsNullOrEmpty(log.Body))
                            {
                                //body = req.
                            }
                        }
                    }
                    catch (Exception ex2)
                    {
                        log.Body = "DefaultRequestLogger.Log: " + ex2.Message;
                    }

                }

                if (req.Browser != null)
                {
                    log.Browser = req.Browser.Type + " " + req.Browser.Version;
                }

                try
                {
                    var constrKey = ConfigurationManager.AppSettings["ActiveCnn"] ?? "ConStr";
                    var constr = ConfigurationManager.ConnectionStrings[constrKey].ConnectionString;

                    if (!string.IsNullOrEmpty(constr))
                    {
                        using (var con = new SqlConnection(constr))
                        {
                            using (var cmd = new SqlCommand("usp1_log_request", con))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;

                                cmd.Parameters.AddWithValue("@Browser", log.Browser);
                                cmd.Parameters.AddWithValue("@IP", log.IP);
                                cmd.Parameters.AddWithValue("@HostName", log.HostName);
                                cmd.Parameters.AddWithValue("@Method", log.Method);
                                cmd.Parameters.AddWithValue("@Url", log.Url);
                                cmd.Parameters.AddWithValue("@Body", log.Body);
                                cmd.Parameters.AddWithValue("@FormData", log.FormData);
                                cmd.Parameters.AddWithValue("@Cookies", log.Cookies);
                                cmd.Parameters.AddWithValue("@Headers", log.Headers);
                                cmd.Parameters.AddWithValue("@Referer", log.Headers);
                                cmd.Parameters.AddWithValue("@Info", SafeConvert.ToString(info).Left(500));
                                cmd.Parameters.AddWithValue("@ExecutionTime", executionTime);

                                con.Open();
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    else
                    {
                        _memoryLogger.Log(JsonConvert.SerializeObject(log));
                    }
                }
                catch (Exception _ex)
                {
                    _memoryLogger.Log(_ex.Message + ": " + JsonConvert.SerializeObject(log));
                }
            }
        }
        public void Log(HttpContext context, string info = "", long executionTime = 0)
        {
            if (context != null)
            {
                Log(context.Request, info, executionTime);
            }
        }
    }
}
