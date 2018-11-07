using Locust.Conversion;
using Locust.Notification;
using Locust.Service;
using Locust.Test.Models;
using Locust.Translation;
using Locust.WebTools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Locust.Test.Mvc.Areas.Test.Controllers
{
    [TestAction]
    public class NotificationController : ClientAwareController
    {
        private INotificationService notificationService;
        public NotificationController(INotificationService notificationService, ITranslator translator) : base(translator)
        {
            this.notificationService = notificationService;
        }
        public virtual ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Send(NotifyType notifyType)
        {
            var result = new ServiceResponse<object>();
            var request = null as NotifyRequest;

            switch (notifyType)
            {
                case NotifyType.Email:
                    request = new EmailNotifyRequest
                    {
                        Body = Request.Form["Body"],
                        Email = Request.Form["To"],
                        Subject = Request.Form["Subject"],
                        IsHtml = SafeClrConvert.ToBoolean(Request.Form["IsHtml"])
                    };
                    break;
                case NotifyType.SMS:
                    request = new SmsNotifyRequest
                    {
                        Message = Request.Form["Message"],
                        MobileNo = Request.Form["targetNumber"]
                    };
                    break;
                default:
                    result.Status = "InvalidOrUnsupportedNotifyType";
                    result.Message = "Specified notify type is not supported or valid";
                    break;
            }

            if (request != null)
            {
                try
                {
                    result.Data = notificationService.Notify(notifyType, request);
                    result.Success = true;
                }
                catch (Exception e)
                {
                    result.Exception = e;
                }
            }

            return Content(JsonConvert.SerializeObject(result), "application/javascript");
        }
    }
}
