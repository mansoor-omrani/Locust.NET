using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Locust.Test.Mvc;
using Locust.Test.Models;
using Locust.Test.Service;
using Locust.WebTools;
using Locust.Translation;

namespace Locust.Test.Mvc.Areas.Test.Controllers
{
    public class HomeController : ClientAwareController
    {
        IAuthenticationService authService;
        public HomeController(IAuthenticationService authService, ITranslator translator) : base(translator)
        {
            this.authService = authService;
        }
        [TestAction]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(string returnurl)
        {
            ViewBag.ReturnUrl = returnurl;

            return View(new LoginViewModel());
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnurl)
        {
            var message = "";

            if (authService.Login(model.UserName, model.Password, out message))
            {
                if (Url.IsLocalUrl(returnurl))
                {
                    return Redirect(returnurl);
                }

                if (WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.Both || WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.OnlyLanguageBased)
                {
                    return Redirect(Lang.ShortName + "/test/home");
                }

                return Redirect("/test/home");
            }

            ViewBag.ReturnUrl = returnurl;
            ViewBag.Message = message;

            return View(model);
        }
        public ActionResult Logout()
        {
            authService.Logout();

            if (WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.Both || WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.OnlyLanguageBased)
            {
                return Redirect(Lang.ShortName + "/test/home");
            }

            return Redirect("/test/home");
        }
    }
}