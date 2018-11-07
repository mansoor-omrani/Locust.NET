using Locust.FileManager.Client;
using Locust.Logging;
using Locust.Notification;
using Locust.Service;
using Locust.Translation;
using Locust.WebTools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Locust.FileManager.CKEditor.Areas.CKManager.Controllers
{
    public class CKManagerBaseController: ClientAwareController
    {
        protected IFileManagerClient client;
        protected ILogger logger;
        protected IExceptionLogger exceptionLogger;
        protected INotificationService notification;
        private string exceptionNotificationTargetType;
        protected string ExceptionNotificationTargetType
        {
            get
            {
                if (string.IsNullOrEmpty(exceptionNotificationTargetType))
                {
                    exceptionNotificationTargetType = ConfigurationManager.AppSettings["CKManager.ExceptionNotificationTargetType"];
                }

                return exceptionNotificationTargetType;
            }
        }
        private string exceptionNotificationTarget;
        protected string ExceptionNotificationTarget
        {
            get
            {
                if (string.IsNullOrEmpty(exceptionNotificationTarget))
                {
                    exceptionNotificationTarget = ConfigurationManager.AppSettings["CKManager.ExceptionNotificationTarget"];
                }

                return exceptionNotificationTarget;
            }
        }
        private string errorNotificationTargetType;
        protected string ErrorNotificationTargetType
        {
            get
            {
                if (string.IsNullOrEmpty(errorNotificationTargetType))
                {
                    errorNotificationTargetType = ConfigurationManager.AppSettings["CKManager.ErrorNotificationTargetType"];
                }

                return errorNotificationTargetType;
            }
        }
        private string errorNotificationTarget;
        protected string ErrorNotificationTarget
        {
            get
            {
                if (string.IsNullOrEmpty(errorNotificationTarget))
                {
                    errorNotificationTarget = ConfigurationManager.AppSettings["CKManager.ErrorNotificationTarget"];
                }

                return errorNotificationTarget;
            }
        }
        public CKManagerBaseController(IFileManagerClient client, ITranslator translator, ILogger logger, IExceptionLogger exceptionLogger, INotificationService notification) : base(translator)
        {
            this.client = client;
            this.logger = logger;
            this.exceptionLogger = exceptionLogger;
            this.notification = notification;
        }
        private void FinalizeResponse(ServiceResponse result, string action, bool overrideMessage)
        {
#if !DEBUG
            result.Exception = null;
#endif
            if (string.IsNullOrEmpty(result.Message))
            {
                if (result.Status == "ForbiddenPath")
                {
                    result.MessageKey = "FileManager";
                }

                Translator.Translate(result, Lang.ShortName, true);

                if (string.IsNullOrEmpty(result.Message) || overrideMessage)
                {
                    var temp = result.Message;
                    var name = this.GetType().Name.Replace("Controller", "");

                    result.MessageKey = $"CKManager-{name}-{action}";

                    Translator.Translate(result, Lang.ShortName, true);

                    if (string.IsNullOrEmpty(result.Message))
                    {
                        result.Message = temp;
                    }
                }
            }
        }
        protected async Task<ActionResult> SendJsonAsync(ServiceResponse result, object info, string errorMessage, bool overrideMessage = false, [CallerMemberName] string action = "")
        {
            await CheckServiceResponseAsync(result, info, errorMessage);

            FinalizeResponse(result, action, overrideMessage);

            var response = result.ToJson();

            return Content(response, "application/json");
        }
        protected ActionResult SendJson(ServiceResponse result, bool overrideMessage = false, [CallerMemberName] string action = "")
        {
            FinalizeResponse(result, action, overrideMessage);

            var response = result.ToJson();

            return Content(response, "application/json");
        }
        protected async Task CheckServiceResponseAsync(ServiceResponse response, object info, string message)
        {
            if (response.Exception != null)
            {
                exceptionLogger?.LogException(response.Exception);

                await notification?.NotifyAsync(NotifyType.WebMessage, new WebMessageNotifyRequest
                {
                    TargetType = ExceptionNotificationTargetType,
                    Target = ExceptionNotificationTarget,
                    Subject = message,
                    Message = info == null ? "null": JsonConvert.SerializeObject(info, Formatting.Indented),
                    Type = WebMessageType.Danger
                });
            }

            if (!response.Success)
            {
                logger?.Log($"CKManager: {message}. Status ={response.Status} BasePath = {client.BasePath}");

                await notification?.NotifyAsync(NotifyType.WebMessage, new WebMessageNotifyRequest
                {
                    TargetType = ErrorNotificationTargetType,
                    Target = ErrorNotificationTarget,
                    Subject = message,
                    Message = info == null ? "null" : JsonConvert.SerializeObject(info, Formatting.Indented),
                    Type = WebMessageType.Warning
                });
            }
        }
    }
}
