using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Locust.MvcAttributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class RestrictHeaderAttribute: ActionFilterAttribute, IActionFilter
    {
        public string Name { get; set; }
        public string Value { get; set; }
        private string _key;
        public string Key
        {
            get { return _key; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    AppValue = ConfigurationManager.AppSettings[value];
                }

                _key = value;
            }
        }
        public static string AppValue { get; set; }
        private void NotAuthorized(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            filterContext.HttpContext.Response.StatusDescription = "Error 401; Unauthorized access denied";
            filterContext.HttpContext.Response.End();
        }
        private void Forbidden(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            filterContext.HttpContext.Response.StatusDescription = "Error 403; Forbidden.";
            filterContext.HttpContext.Response.End();
        }
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (string.IsNullOrEmpty(Name))
            {
                return;
            }

            var header = filterContext.HttpContext.Request.Headers[Name];
            
            if (string.IsNullOrEmpty(header))
            {
                NotAuthorized(filterContext);
                return;
            }

            if (!string.IsNullOrEmpty(Value))
            {
                if (string.Compare(header, Value, StringComparison.CurrentCulture) != 0)
                {
                    Forbidden(filterContext);
                    return;
                }
            }

            if (!string.IsNullOrEmpty(AppValue))
            {
                if (string.Compare(header, AppValue, StringComparison.CurrentCulture) != 0)
                {
                    Forbidden(filterContext);
                    return;
                }
            }
        }
    }
}
