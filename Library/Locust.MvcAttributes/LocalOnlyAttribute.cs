using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Locust.MvcAttributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class LocalOnlyAttribute : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsLocal)
            {
                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }
        }
    }
}
