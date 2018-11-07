using Hangfire;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Locust.Mailing;
using Locust.SMS;
using Locust.Notification;

namespace Locust.Notification.HangFire
{
    public class HangFireNotificationService : INotificationService
    {
        public IMailManager MailService { get; set; }
        public ISMSService SmsService { get; set; }
        public static IMailManager Mail { get; set; }
        public static ISMSService SMS { get; set; }

        public HangFireNotificationService(IMailManager mail, ISMSService sms)
        {
            MailService = mail;
            SmsService = sms;
        }
        public static void NotifyBySms(SmsNotifyRequest sms)
        {
            SMS.Send(sms.MobileNo, sms.Message);
        }

        public static void NotifyByEmail(EmailNotifyRequest mail)
        {
            Mail.Send(mail.Email, mail.Subject, mail.Body, mail.IsHtml);
        }
        protected virtual EmailNotifyResponse NotifyMail(EmailNotifyRequest request)
        {
            var result = new EmailNotifyResponse();

            if (request != null)
            {
                BackgroundJob.Enqueue(() => NotifyByEmail(request));
                result.Succeeded();
            }
            else
            {
                result.Status = "NoRequest";
            }

            return result;
        }
        protected virtual Task<EmailNotifyResponse> NotifyMailAsync(EmailNotifyRequest request)
        {
            return Task.FromResult(NotifyMail(request));
        }
        protected virtual SmsNotifyResponse NotifySms(SmsNotifyRequest request)
        {
            var result = new SmsNotifyResponse();

            if (request != null)
            {
                BackgroundJob.Enqueue(() => NotifyBySms(request));
                result.Succeeded();
            }
            else
            {
                result.Status = "NoRequest";
            }

            return result;
        }
        protected virtual Task<SmsNotifyResponse> NotifySmsAsync(SmsNotifyRequest request)
        {
            return Task.FromResult(NotifySms(request));
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
        public virtual NotifyResponse Notify(NotifyType type, NotifyRequest request)
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

        public virtual async Task<NotifyResponse> NotifyAsync(NotifyType type, NotifyRequest request)
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
    }
}
