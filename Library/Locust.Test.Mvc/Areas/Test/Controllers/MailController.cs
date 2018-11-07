using Locust.WebTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Locust.Mailing.Smtp;
using Locust.Mailing;
using Locust.Test.Models;
using Newtonsoft.Json;
using Locust.Service;
using Locust.Translation;

namespace Locust.Test.Mvc.Areas.Test.Controllers
{
    [TestAction]
    public class MailController : ClientAwareController
    {
        public MailController(ITranslator translator) : base(translator)
        {
        }

        public virtual ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Send(BaseMailConfig config, bool isHtml, string mailmanagertype, string to, string subject, string body)
        {
            var result = new ServiceResponse();

            mailmanagertype = mailmanagertype?.ToLower();

            if (string.IsNullOrEmpty(mailmanagertype))
            {
                result.Status = "NoType";
                result.Message = "Please specify mail manager";
            }
            else
            {
                switch (mailmanagertype)
                {
                    case "smtp":
                        try
                        {
                            var smtp = new SmtpMailManager(config);

                            smtp.Send(to, subject, body, isHtml);

                            result.Success = true;
                        }
                        catch (Exception e)
                        {
                            result.Exception = e;
                        }
                        break;
                    default:
                        result.Status = "InvalidType";
                        result.Message = "Specified mail manager is not valid";
                        break;
                }
            }

            return Content(JsonConvert.SerializeObject(result), "application/javascript");
        }
    }
}
