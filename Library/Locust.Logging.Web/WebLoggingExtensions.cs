using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Locust.Logging.Web
{
    public static class WebLoggingExtensions
    {
        public static void LogException(this IWebExceptionLogger logger, HttpContext context, Exception ex, string info = "")
        {
            var httpContext = new HttpContextWrapper(context);

            logger.LogException(httpContext, ex, info);
        }
    }
}
