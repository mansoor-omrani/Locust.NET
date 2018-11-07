using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Locust.MvcAttributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class CORSAttribute : ActionFilterAttribute, IActionFilter
    {
        static string[] allowedOrigins;
        static CORSAttribute()
        {
            var origins = ConfigurationManager.AppSettings["CORS-ORIGINS"] ?? "";

            try
            {
                allowedOrigins = JsonConvert.DeserializeObject<string[]>(origins);
            }
            catch { }

            if (allowedOrigins == null)
            {
                allowedOrigins = new string[0];
            }
        }
        void IActionFilter.OnActionExecuted(ActionExecutedContext filterContext)
        {
            var request = filterContext.RequestContext.HttpContext.Request;
            var response = filterContext.RequestContext.HttpContext.Response;
            var origin = request.Headers["origin"] ?? "";

            if (!string.IsNullOrEmpty(origin))
            {
                Uri uri;
                string host = "";

                if (Uri.TryCreate(origin, UriKind.Absolute, out uri))
                {
                    try
                    {
                        host = uri.Host;
                    }
                    catch
                    {
                        host = uri.ToString();
                    }

                    if (allowedOrigins.Any(x => x == "*" || x.ToLower().Contains(host.ToLower())))
                    {
                        response.Headers["access-control-allow-origin"] = origin;
                    }
                }
                else
                {
                    if (Uri.TryCreate(origin, UriKind.Relative, out uri))
                    {
                        try
                        {
                            host = uri.Host;
                        }
                        catch
                        {
                            host = uri.ToString();
                        }

                        if (allowedOrigins.Any(x => x == "*" || x.ToLower().Contains(host.ToLower())))
                        {
                            response.Headers["access-control-allow-origin"] = origin;
                        }
                    }
                }
            }
        }
    }
}