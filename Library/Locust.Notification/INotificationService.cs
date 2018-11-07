using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Mailing;
using Locust.SMS;
using Locust.Service;

namespace Locust.Notification
{
    public interface INotificationService
    {
        IMailManager MailService { get; }
        ISMSService SmsService { get; }
        NotifyResponse Notify(NotifyType type, NotifyRequest request);
        Task<NotifyResponse> NotifyAsync(NotifyType type, NotifyRequest request);
    }

    public enum NotifyType
    {
        None, Email, SMS, WebMessage, AppMessage, AppNotify
    }
    public class NotifyResponse: ServiceResponse
    { }
    public class NotifyRequest: ServiceRequest
    { }

    public class EmailNotifyRequest: NotifyRequest
    {
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHtml { get; set; }
    }

    public class EmailNotifyResponse : NotifyResponse
    {
    }
    public class SmsNotifyRequest : NotifyRequest
    {
        public string MobileNo { get; set; }
        public string Message { get; set; }
    }

    public class SmsNotifyResponse : NotifyResponse
    {
        public string Result { get; set; }
    }
    public static class WebMessageType
    {
        public static string Info => "Info";
        public static string Warning => "Warning";
        public static string Success => "Success";
        public static string Primary => "Primary";
        public static string Danger => "Danger";
    }
    public static class WebMessageTargetType
    {
        public static string User => "User";
        public static string Role => "Role";
    }
    public class WebMessageNotifyRequest:NotifyRequest
    {
        public string Target { get; set; }
        public string TargetType { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
    }
    public class WebMessageNotifyResponse : NotifyResponse { }
    public class AppMessageNotifyRequest : WebMessageNotifyRequest { }
    public class AppMessageNotifyResponse : WebMessageNotifyResponse { }
    public class AppNotifyRequest : WebMessageNotifyRequest { }
    public class AppNotifyResponse : WebMessageNotifyResponse { }
}
