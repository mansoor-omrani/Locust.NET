using Locust.Logging;
using Locust.Service;
using Locust.SMS;
using Locust.SMS.Payamtak;
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
    public class SmsController : ClientAwareController
    {
        public ILogger Logger { get; set; }
        public IExceptionLogger ExceptionLogger { get; set; }
        public SmsController(ILogger logger, IExceptionLogger exceptionLogger, ITranslator translator) : base(translator)
        {
            this.Logger = logger;
            this.ExceptionLogger = exceptionLogger;
        }
        public virtual ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Send(BaseSMSConfiguration config, string smsservicetype, string targetNumber, string message)
        {
            var result = new ServiceResponse();

            smsservicetype = smsservicetype?.ToLower();

            if (string.IsNullOrEmpty(smsservicetype))
            {
                result.Status = "NoType";
                result.Message = "Please specify SMS service";
            }
            else
            {
                switch (smsservicetype)
                {
                    case "payamtak":
                        try
                        {
                            var sms = new PayamtakSmsService(config, Logger, ExceptionLogger);
                            result.Message = sms.Send(targetNumber, message);
                            result.Success = true;
                        }
                        catch (Exception e)
                        {
                            result.Exception = e;
                        }
                        break;
                    default:
                        result.Status = "InvalidType";
                        result.Message = "Specified SMS service is not valid";
                        break;
                }
            }

            return Content(JsonConvert.SerializeObject(result), "application/javascript");
        }
    }
}
