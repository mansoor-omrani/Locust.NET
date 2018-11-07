using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Locust.SMS
{
    public class FakeSmsConfig : ISMSConfiguration
    {
        public string Number { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
    }
    public abstract class FakeSmsService<TSmsConfig> : ISMSService where TSmsConfig: class, ISMSConfiguration, new()
    {
        private ISMSConfiguration _config;
        public ISMSConfiguration Config
        {
            get
            {
                if (_config == null)
                    _config = new TSmsConfig();

                return _config;
            }
            set
            {
                if (value is TSmsConfig)
                {
                    _config = value;
                }
                else
                {
                    throw new ApplicationException("Invalid sms config type");
                }
            }
        }
        public TSmsConfig StrongConfig
        {
            get { return Config as TSmsConfig; }
        }
        protected abstract string LogInternal(string data);
        protected virtual string Log(string data, [CallerMemberName] string memberName = "")
        {
            var _data = "Method: " + memberName + "\r\n" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fffff") + "\r\n" + data + "\r\n" + new string('-', 50) + "\r\n";

            return LogInternal(_data);
        }
        public virtual string Send(string targetNumber, string message)
        {
            var data = $"targetNumber: {targetNumber}\r\nmessage:{message}";

            return Log(data);
        }

        public virtual Task<string> SendAsync(string targetNumber, string message)
        {
            return Task.Run(() => {
                var data = $"targetNumber: {targetNumber}\r\nmessage:{message}";

                return Log(data);
            });
        }

        public virtual Task<string> SendAsync(string targetNumber, string message, CancellationToken cancellation)
        {
            return Task.Run(() => {
                var data = $"targetNumber: {targetNumber}\r\nmessage:{message}";

                return Log(data);
            }, cancellation);
        }
    }
}
