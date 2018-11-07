using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Locust.StateProvider.Mvc
{
    public class StateProviderFilterAttribute: ActionFilterAttribute
    {
        private readonly string[] _plainCookies;
        private readonly string[] _secureCookies;
        public StateProviderFilterAttribute(string[] plainCookies, string[] secureCookies)
        {
            this._plainCookies = plainCookies;
            this._secureCookies = secureCookies;
        }
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            //StateProvider.PlainCookie.Restore(_plainCookies);
            //StateProvider.SecureCookie.Restore(_secureCookies);
            //StateProvider.Session.Restore();

            base.OnActionExecuting(actionContext);
        }
        public override void OnResultExecuted(ResultExecutedContext actionContext)
        {
            //StateProvider.PlainCookie.Store();
            //StateProvider.SecureCookie.Store();
            //StateProvider.Session.Store();

            base.OnResultExecuted(actionContext);
        }
    }
}
