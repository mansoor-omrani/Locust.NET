using Locust.Language;
using Locust.Service;
using Locust.Test.Models;
using Locust.Test.Service;
using Locust.WebTools;
using System;
using System.Configuration;
using System.Text;
using System.Web.Mvc;

namespace Locust.Test.Mvc
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class TestActionAttribute : ActionFilterAttribute, IActionFilter
    {
        private IAuthenticationService authService;
        public TestActionAttribute()
        {
            this.authService = new AuthenticationService(new DefaultHttpContextProvider());
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var disableAuthentication = ConfigurationManager.AppSettings["Locust.Test.DisableAuthentication"]?.ToLower();

            if (disableAuthentication != "true" && !authService.IsAuthenticated())
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new JsonResult
                    {
                        Data = new ServiceResponse { Message = "You are not authenticated. Please login first." },
                        ContentType = "application/javascript",
                        ContentEncoding = Encoding.UTF8
                    };
                }
                else
                {
                    if (WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.Both || WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.OnlyLanguageBased)
                    {
                        Lang lang;

                        var clientAwareController = filterContext.Controller as ClientAwareControllerBase;

                        if (clientAwareController != null)
                        {
                            lang = clientAwareController.Lang;
                        }
                        else
                        {
                            lang = Lang.En;
                        }

                        filterContext.Result = new RedirectResult($"/{lang.ShortName}/test/home/login?returnurl=" +
                            filterContext.HttpContext.Server.UrlEncode(filterContext.HttpContext.Request.Url.ToString()));
                    }
                    else
                    {
                        filterContext.Result = new RedirectResult("/test/home/login?returnurl=" +
                            filterContext.HttpContext.Server.UrlEncode(filterContext.HttpContext.Request.Url.ToString()));
                    }
                }
            }
        }
    }
}