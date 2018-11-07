using System.Web.Mvc;

namespace Locust.FileManager.Mvc.Areas.FileManager
{
    public class FileManagerAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "FileManager";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "FileManager_default",
                "FileManager/{controller}/{action}/{path}", new { path = UrlParameter.Optional });
        }
    }
}