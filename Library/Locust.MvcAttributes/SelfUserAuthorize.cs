using Locust.Extensions;
using Locust.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Locust.MvcAttributes
{
    public class SelfUserAuthorizeAttribute : ActionFilterAttribute, IActionFilter
    {
        public string Key { get; set; }
        public SelfUserAuthorizeAttribute()
        {
        }
        public SelfUserAuthorizeAttribute(string key)
        {
            Key = key;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var _key = string.IsNullOrEmpty(Key) ? "username" : Key;
            var username = filterContext.Controller.ControllerContext.RouteData.Values[_key]?.ToString();

            if (!filterContext.HttpContext.Request.IsAuthenticated)
            {
                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Unauthorized);

                return;
            }

            if (string.Compare(username, filterContext.HttpContext.User.Identity.Name, true) != 0)
            {
                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
        }
    }
    public class JsonSelfUserAuthorizeAttribute : JsonAuthorize
    {
        public string Key { get; set; }
        public JsonSelfUserAuthorizeAttribute()
        {
        }
        public JsonSelfUserAuthorizeAttribute(string key)
        {
            Key = key;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (filterContext.Result == null)
            {
                var _key = string.IsNullOrEmpty(Key) ? "username" : Key;
                var username = filterContext.Controller.ControllerContext.RouteData.Values[_key]?.ToString();

                if (!filterContext.HttpContext.Request.IsAuthenticated)
                {
                    var data = new ServiceResponse { Status = "NotAuthenticated" };
                    var response = data.ToJson();
                    var result = new ContentResult();

                    result.ContentType = "application/json";
                    result.ContentEncoding = Encoding.UTF8;
                    result.Content = response;

                    filterContext.Result = result;

                    return;
                }

                if (string.Compare(username, filterContext.HttpContext.User.Identity.Name, true) != 0)
                {
                    var data = new ServiceResponse { Status = "CrossAccessDenied" };
                    var response = data.ToJson();
                    var result = new ContentResult();

                    result.ContentType = "application/json";
                    result.ContentEncoding = Encoding.UTF8;
                    result.Content = response;

                    filterContext.Result = result;
                }
            }
        }
    }
}
