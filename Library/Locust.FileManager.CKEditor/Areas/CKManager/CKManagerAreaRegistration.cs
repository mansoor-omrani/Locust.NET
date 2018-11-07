using Locust.WebTools;
using System.Web.Mvc;

namespace Locust.FileManager.CKEditor.Areas.CKManager
{
    public class CKManagerAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "CKManager";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            var namespaces = new string[] { "Locust.FileManager.CKEditor.Areas.CKManager.Controllers" };

            context.RegisterClientAwareRoutes(namespaces: namespaces);

            context.RegisterRoutes(
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Files", action = "Index", id = UrlParameter.Optional },
                namespaces: namespaces
            );
        }
    }
}