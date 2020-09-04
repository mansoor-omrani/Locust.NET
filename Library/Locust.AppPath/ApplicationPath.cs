using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Locust.AppPath
{
    public class ApplicationPath
    {
        public static String Root
        {
            get
            {
                var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);

                if (!string.IsNullOrEmpty(path))
                {
                    if (path.StartsWith("file:\\", StringComparison.InvariantCultureIgnoreCase))
                    {
                        path = path.Substring(6);
                    }
                    if (path[path.Length - 1] == '\\')
                    {
                        path = path.Substring(0, path.Length - 1);
                    }
                    if (path.EndsWith("\\debug", StringComparison.CurrentCultureIgnoreCase))
                    {
                        path = path.Substring(0, path.Length - 6);
                    }
                    if (path.EndsWith("\\release", StringComparison.CurrentCultureIgnoreCase))
                    {
                        path = path.Substring(0, path.Length - 8);
                    }
                    if (path.EndsWith("\\bin", StringComparison.CurrentCultureIgnoreCase))
                    {
                        path = path.Substring(0, path.Length - 4);
                    }
                }

                return path;
            }
        }
        public static Dictionary<string, string> GetAll()
        {
            var result = new Dictionary<string, string>();
            var context = HttpContext.Current;

            result.Add("System.Environment.CurrentDirectory", System.Environment.CurrentDirectory);
            result.Add("AppDomain.CurrentDomain.BaseDirectory", AppDomain.CurrentDomain.BaseDirectory);

            try
            {
                result.Add("HttpRuntime.AppDomainAppPath", HttpRuntime.AppDomainAppPath);
            }
            catch (Exception e)
            {
                result.Add("HttpRuntime.AppDomainAppPath", e.Message);
            }
            if (context != null)
            {
                result.Add("HttpRequest.ApplicationPath:", context.Request.ApplicationPath);
            }
            else
            {
                result.Add("HttpRequest.ApplicationPath", "HttpContext IS NULL");
            }
            if (context != null)
            {
                result.Add("Server.MapPath('~/')", context.Server.MapPath("~/"));
            }
            else
            {
                result.Add("Server.MapPath('~/')", "HttpContext IS NULL");
            }
            result.Add("System.Windows.Forms.Application.StartupPath", System.Windows.Forms.Application.StartupPath);
            result.Add("System.Windows.Forms.Application.ExecutablePath ", System.Windows.Forms.Application.ExecutablePath);
            result.Add("System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            result.Add("System.IO.Directory.GetCurrentDirectory()", System.IO.Directory.GetCurrentDirectory());
            result.Add("Environment.CurrentDirectory", Environment.CurrentDirectory);
            result.Add("System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase))", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase));

            return result;
        }
        public static void WriteAll()
        {
            var x = GetAll();
            foreach (var item in x)
            {
                System.Console.WriteLine(item.Key + ": " + item.Value);
            }
        }
        public static void OutputAll()
        {
            var x = GetAll();
            foreach (var item in x)
            {
                Debug.WriteLine(item.Key + ": " + item.Value);
            }
        }
        public static string HtmlAll()
        {
            var sb = new StringBuilder();
            var x = GetAll();

            sb.Append("<table><thead><tr><th>Item</th><th>Value</th></tr></thead><tbody>");
            foreach (var item in x)
            {
                sb.Append("<tr><td><b>" + item.Key + "</b></td><td>" + item.Value + "</td></td></tr>");
            }
            sb.Append("</tbody></table>");
            return sb.ToString();
        }
    }
}
