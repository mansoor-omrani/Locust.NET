using Locust.Conversion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Locust.MvcAttributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class RequestBodyAttribute: ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            var skip = SafeClrConvert.ToBoolean(filterContext.HttpContext.Items["x_request_body_read"]);

            if (!skip)
            {
                var data = "";

                using (var reader = new StreamReader(filterContext.HttpContext.Request.InputStream))
                {
                    data = reader.ReadToEnd();
                }

                filterContext.HttpContext.Items.Add("x_request_body_read", true);
                filterContext.HttpContext.Items.Add("x_request_body", data);
            }
        }
    }
}
