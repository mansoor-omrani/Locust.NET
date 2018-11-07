using System.Web.Mvc;

namespace Locust.AspNet.Identity.Areas.Api
{
    public class ApiAreaRegistration: AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Api";
            }
        }
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "apiDefault",
                AreaName + "/{controller}/{action}/{id}/{no}",
                new { action = "Index", id = UrlParameter.Optional, no = UrlParameter.Optional },
                new[] { "Locust.AspNet.Identity.Areas.Api.Controllers" }
            );
        }
    }
}
