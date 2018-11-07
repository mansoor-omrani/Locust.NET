using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Locust.WebTools
{
    public class SetCORS
    {
        static string[] allowedOrigins;
        static SetCORS()
        {
            var origins = ConfigurationManager.AppSettings["CORS-ORIGINS"] ?? "";

            if (!string.IsNullOrEmpty(origins))
            {
                try
                {
                    allowedOrigins = JsonConvert.DeserializeObject<string[]>(origins);
                }
                catch { }
            }

            if (allowedOrigins == null)
            {
                allowedOrigins = new string[0];
            }
        }
        public static void Execute()
        {
            var request =  HttpContext.Current.Request;
            var response = HttpContext.Current.Response;
            var origin = request.Headers["origin"] ?? "";

            if (!string.IsNullOrEmpty(origin))
            {
                Uri uri;
                string host = "";

                if (!Uri.TryCreate(origin, UriKind.Absolute, out uri))
                {
                    if (!Uri.TryCreate(origin, UriKind.Relative, out uri))
                    {
                        
                    }
                }

                if (uri != null)
                {
                    try
                    {
                        host = uri.Host;
                    }
                    catch
                    {
                        host = uri.ToString();
                    }

                    host = host.ToLower();

                    if (allowedOrigins.Any(x => x == "*" || x.ToLower().Contains(host)))
                    {
                        response.Headers["access-control-allow-origin"] = origin;
                    }
                }
            }
        }
    }
}
