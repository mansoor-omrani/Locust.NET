using Locust.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Locust.SMS
{
    public enum FakeSmsServiceType
    {
        None, File, Debug, Console, Trace
    }
    public class FakeDynamicSmsService : ISMSService
    {
        private ISMSService sender;
        public ISMSConfiguration Config
        {
            get { return sender.Config; }
            set
            {
                if (sender != null)
                    sender.Config = value;
            }
        }
        public ISMSService Instance { get { return sender; } }
        public FakeDynamicSmsService()
        {
            var type = ConfigHelper.AppSetting("FakeSmsServiceType", FakeSmsServiceType.File);

            switch (type)
            {
                case FakeSmsServiceType.Console: sender = new FakeConsoleSmsService(); break;
                case FakeSmsServiceType.Debug: sender = new FakeDebugSmsService(); break;
                case FakeSmsServiceType.Trace: sender = new FakeTraceSmsService(); break;
                case FakeSmsServiceType.File: sender = new FakeFileSmsService(); break;
                case FakeSmsServiceType.None: sender = null; break;
                default:
                    throw new Exception("invalid fake sms service type: " + type);
            }
        }
        public string Send(string targetNumber, string message)
        {
            return sender?.Send(targetNumber, message);
        }

        public Task<string> SendAsync(string targetNumber, string message)
        {
            return sender?.SendAsync(targetNumber, message);
        }

        public Task<string> SendAsync(string targetNumber, string message, CancellationToken cancellation)
        {
            return sender?.SendAsync(targetNumber, message, cancellation);
        }
    }
}
