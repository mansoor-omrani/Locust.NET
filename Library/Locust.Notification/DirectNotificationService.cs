using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Mailing;
using Locust.SMS;

namespace Locust.Notification
{
    public class DirectNotificationService:INotificationService
    {
        public IMailManager MailService { get; }
        public ISMSService SmsService { get; }
        protected virtual EmailNotifyResponse NotifyMail(EmailNotifyRequest request)
        {
            var result = new EmailNotifyResponse();

            if (request != null)
            {
                try
                {
                    MailService.Send(request.Email, request.Subject, request.Body, request.IsHtml, null, null);
                    result.Succeeded();
                }
                catch (Exception e)
                {
                    result.Failed(e);
                }
            }
            else
            {
                result.Status = "NoRequest";
            }

            return result;
        }
        protected virtual async Task<EmailNotifyResponse> NotifyMailAsync(EmailNotifyRequest request)
        {
            var result = new EmailNotifyResponse();

            if (request != null)
            {
                try
                {
                    await MailService.SendAsync(request.Email, request.Subject, request.Body, request.IsHtml, null, null);
                    result.Succeeded();
                }
                catch (Exception e)
                {
                    result.Failed(e);
                }
            }
            else
            {
                result.Status = "NoRequest";
            }

            return result;
        }
        protected virtual SmsNotifyResponse NotifySms(SmsNotifyRequest request)
        {
            var result = new SmsNotifyResponse();

            if (request != null)
            {
                try
                {
                    result.Result = SmsService.Send(request.MobileNo, request.Message);
                    result.Succeeded();
                }
                catch (Exception e)
                {
                    result.Failed(e);
                }
            }
            else
            {
                result.Status = "NoRequest";
            }

            return result;
        }
        protected virtual async Task<SmsNotifyResponse> NotifySmsAsync(SmsNotifyRequest request)
        {
            var result = new SmsNotifyResponse();

            if (request != null)
            {
                try
                {
                    result.Result = await SmsService.SendAsync(request.MobileNo, request.Message);
                    result.Succeeded();
                }
                catch (Exception e)
                {
                    result.Failed(e);
                }
            }
            else
            {
                result.Status = "NoRequest";
            }

            return result;
        }
        protected virtual WebMessageNotifyResponse NotifyWebMessage(WebMessageNotifyRequest request)
        {
            return new WebMessageNotifyResponse { Status = "NotImplemented" };
        }
        protected virtual AppMessageNotifyResponse NotifyAppMessage(AppMessageNotifyRequest request)
        {
            return new AppMessageNotifyResponse { Status = "NotImplemented" };
        }
        protected virtual AppNotifyResponse NotifyApp(AppNotifyRequest request)
        {
            return new AppNotifyResponse { Status = "NotImplemented" };
        }
        protected virtual Task<WebMessageNotifyResponse> NotifyWebMessageAsync(WebMessageNotifyRequest request)
        {
            return Task.FromResult(NotifyWebMessage(request));
        }
        protected virtual Task<AppMessageNotifyResponse> NotifyAppMessageAsync(AppMessageNotifyRequest request)
        {
            return Task.FromResult(NotifyAppMessage(request));
        }
        protected virtual Task<AppNotifyResponse> NotifyAppAsync(AppNotifyRequest request)
        {
            return Task.FromResult(NotifyApp(request));
        }
        public NotifyResponse Notify(NotifyType type, NotifyRequest request)
        {
            NotifyResponse result = null;

            switch (type)
            {
                case NotifyType.Email:
                    result = NotifyMail(request as EmailNotifyRequest);
                    break;
                case NotifyType.SMS:
                    result = NotifySms(request as SmsNotifyRequest);
                    break;
                case NotifyType.WebMessage:
                    result = NotifyWebMessage(request as WebMessageNotifyRequest);
                    break;
                case NotifyType.AppMessage:
                    result = NotifyAppMessage(request as AppMessageNotifyRequest);
                    break;
                case NotifyType.AppNotify:
                    result = NotifyApp(request as AppNotifyRequest);
                    break;
                default:
                    // for other notification types we do nothing and deliver this to sub-classses to do it at their will
                    break;
            }

            return result;
        }

        public async Task<NotifyResponse> NotifyAsync(NotifyType type, NotifyRequest request)
        {
            NotifyResponse result = null;

            switch (type)
            {
                case NotifyType.Email:
                    result = await NotifyMailAsync(request as EmailNotifyRequest);
                    break;
                case NotifyType.SMS:
                    result = await NotifySmsAsync(request as SmsNotifyRequest);
                    break;
                case NotifyType.WebMessage:
                    result = await NotifyWebMessageAsync(request as WebMessageNotifyRequest);
                    break;
                case NotifyType.AppMessage:
                    result = await NotifyAppMessageAsync(request as AppMessageNotifyRequest);
                    break;
                case NotifyType.AppNotify:
                    result = await NotifyAppAsync(request as AppNotifyRequest);
                    break;
                default:
                    // for other notification types we do nothing and deliver this to sub-classses to do it at their will
                    break;
            }

            return result;
        }

        public DirectNotificationService(IMailManager mail, ISMSService sms)
        {
            MailService = mail;
            SmsService = sms;
        }
    }
}
