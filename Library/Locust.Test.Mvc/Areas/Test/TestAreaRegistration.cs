using Locust.WebTools;
using System.Web.Mvc;

namespace Locust.Test.Mvc.Areas.Test
{
    public class TestAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Test";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            var namespaces = new string[] { "Locust.Test.Mvc.Areas.Test.Controllers" };

            context.RegisterClientAwareRoutes(namespaces: namespaces);

            context.RegisterRoutes(
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: namespaces
            );
        }
    }
}