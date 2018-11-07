using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Mailing;
using Locust.SMS;

namespace Locust.Notification
{
    public class NullNotificationService:INotificationService
    {
        public IMailManager MailService { get; }
        public ISMSService SmsService { get; }
        public NotifyResponse Notify(NotifyType type, NotifyRequest request)
        {
            return new NotifyResponse();
        }

        public Task<NotifyResponse> NotifyAsync(NotifyType type, NotifyRequest request)
        {
            return Task.FromResult(new NotifyResponse());
        }
    }
}
