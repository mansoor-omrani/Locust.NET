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
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class JsonAuthorize : ActionFilterAttribute, IActionFilter
    {
        public string Roles { get; set; }
        public string Users { get; set; }
        public bool IgnoreNonAjaxRequests { get; set; }
        public JsonAuthorize(bool ignoreNonAjaxRequests = false)
        {
            IgnoreNonAjaxRequests = ignoreNonAjaxRequests;
        }
        public JsonAuthorize(string roles, string users, bool ignoreNonAjaxs = false)
        {
            Roles = roles;
            Users = users;
            IgnoreNonAjaxRequests = ignoreNonAjaxs;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var authorized = true;
            var status = "Unauthorized";

            if (!filterContext.HttpContext.Request.IsAuthenticated)
            {
                authorized = false;
                status = "NotAuthenticated";
            }
            else
            {
                if (!string.IsNullOrEmpty(Users))
                {
                    authorized = filterContext.HttpContext.User.Identity.Name.In(Users);

                    if (!authorized)
                    {
                        status = "UserForbidden";
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(Roles))
                    {
                        var role = filterContext.HttpContext.User.Identity.GetRoleName();

                        authorized = role.In(Roles);

                        if (!authorized)
                        {
                            status = "RoleForbidden";
                        }
                    }
                }
            }

            if (!authorized)
            {
                if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
                {
                    var data = new ServiceResponse { Status = status };
                    data.MessageKey = this.GetType().Name;
                    var response = data.ToJson();
                    var result = new ContentResult();

                    result.ContentType = "application/json";
                    result.ContentEncoding = Encoding.UTF8;
                    result.Content = response;

                    filterContext.Result = result;
                }
                else
                {
                    if (!IgnoreNonAjaxRequests)
                    {
                        filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
                    }
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
