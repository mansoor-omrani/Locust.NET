using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Extensions;
using Locust.Mailing;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
using Locust.Modules.Api.Service;
using Locust.Notification;
using Locust.SMS;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerRegisterStrategy : ApiClientCustomerRegisterStrategyBase
    {
		public ApiClientCustomerRegisterStrategy(INotificationService notification) : base(notification)
		{
            Init();
		}
        
		public override void Run(ApiClientCustomerRegisterContext context)
        {
            var store = this.Store as ApiClientCustomerStrategyStore;
            var ctx = store.Enrol.Invoke(new ApiClientCustomerEnrolRequest
            {
                AppId = context.Request.CallContext.App.AppId,
                ApiClientId = context.Request.CallContext.Client?.ApiClientId,
                IP = context.Request.CallContext.ClientIP,
                UserName = context.Request.CallContext.HttpContext.User.Identity.Name,
                Role = context.Request.CallContext.HttpContext.User.Identity.GetRole(),
                Email = context.Request.Email,
                MobileNo = context.Request.MobileNo,
                ActivationMethod = context.Request.ActivationMethod,
                HardwareCode = context.Request.HardwareCode,
                SerialNo = context.Request.SerialNo,
                CustomerType = context.Request.CustomerType
            });

            if (ctx.Response.Success)
            {
                context.Response.Succeeded();

                var activationCode = ctx.Response.ActivationCode;

                switch (context.Request.ActivationMethod.ToLower())
                {
                    case "sms":
                        var smsNotifyRequest = new SmsNotifyRequest { Message = activationCode, MobileNo = context.Request.MobileNo };
                        _notification.Notify(NotifyType.SMS, smsNotifyRequest);
                        break;
                    case "email":
                        var emailNotifyRequest = new EmailNotifyRequest { Email = context.Request.Email, Subject = "Activation Code", Body = string.Format("Your activation code is {0}", activationCode) };
                        _notification.Notify(NotifyType.Email, emailNotifyRequest);
                        break;
                    case "mixed":
                        var index = activationCode.Length / 2;
                        var part1 = activationCode.Substring(0, index);
                        var part2 = activationCode.Substring(index);

                        smsNotifyRequest = new SmsNotifyRequest { Message = part1, MobileNo = context.Request.MobileNo };
                        emailNotifyRequest = new EmailNotifyRequest { Email = context.Request.Email, Subject = "Activation Code", Body = string.Format("The email-part of your activation code is {0}", part2) };

                        _notification.Notify(NotifyType.SMS, smsNotifyRequest);
                        _notification.Notify(NotifyType.Email, emailNotifyRequest);

                        break;
                }
            }
            else
            {
                context.Response.SetStatus(ctx.Response.Status.ToString());
            }
        }

        public override async Task RunAsync(ApiClientCustomerRegisterContext context)
        {
            var store = this.Store as ApiClientCustomerStrategyStore;
            var ctx = await store.Enrol.InvokeAsync(new ApiClientCustomerEnrolRequest
            {
                AppId = context.Request.CallContext.App.AppId,
                ApiClientId = context.Request.CallContext.Client?.ApiClientId,
                IP = context.Request.CallContext.ClientIP,
                UserName = context.Request.CallContext.HttpContext.User.Identity.Name,
                Role = context.Request.CallContext.HttpContext.User.Identity.GetRole(),
                Email = context.Request.Email,
                MobileNo = context.Request.MobileNo,
                ActivationMethod = context.Request.ActivationMethod,
                HardwareCode = context.Request.HardwareCode,
                SerialNo = context.Request.SerialNo,
                CustomerType = context.Request.CustomerType
            });

            if (ctx.Response.Success)
            {
                context.Response.Succeeded();

                var activationCode = ctx.Response.ActivationCode;

                switch (context.Request.ActivationMethod.ToLower())
                {
                    case "sms":
                        var smsNotifyRequest = new SmsNotifyRequest { Message = activationCode, MobileNo = context.Request.MobileNo };
                        await _notification.NotifyAsync(NotifyType.SMS, smsNotifyRequest);
                        break;
                    case "email":
                        var emailNotifyRequest = new EmailNotifyRequest { Email = context.Request.Email, Subject = "Activation Code", Body = string.Format("Your activation code is {0}", activationCode) };
                        await _notification.NotifyAsync(NotifyType.Email, emailNotifyRequest);
                        break;
                    case "mixed":
                        var index = activationCode.Length / 2;
                        var part1 = activationCode.Substring(0, index);
                        var part2 = activationCode.Substring(index);

                        smsNotifyRequest = new SmsNotifyRequest { Message = part1, MobileNo = context.Request.MobileNo };
                        emailNotifyRequest = new EmailNotifyRequest { Email = context.Request.Email, Subject = "Activation Code", Body = string.Format("The email-part of your activation code is {0}", part2) };

                        await _notification.NotifyAsync(NotifyType.SMS, smsNotifyRequest);
                        await _notification.NotifyAsync(NotifyType.Email, emailNotifyRequest);

                        break;
                }
            }
            else
            {
                context.Response.SetStatus(ctx.Response.Status.ToString());
            }
        }
    }
}