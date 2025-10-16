using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Locust.MvcAttributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class RestrictMethodAttribute : ActionFilterAttribute, IActionFilter
    {
        public string Name { get; set; }
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (string.Compare(filterContext.HttpContext.Request.HttpMethod, Name.ToString(), true) != 0)
            {
                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return;
            }
        }
    }
}
