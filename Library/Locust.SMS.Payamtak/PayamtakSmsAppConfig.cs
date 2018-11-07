using Locust.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.SMS.Payamtak
{
    public class PayamtakSmsAppConfig: ISMSConfiguration
    {
        private dynamic config;
        public PayamtakSmsAppConfig()
        {
            config = new AppConfigSettings();
        }
        public string Username
        {
            get { return config.PayamtakUserName; }
        }

        public string Password
        {
            get { return config.PayamtakPassword; }
        }

        public string Number
        {
            get { return config.PayamtakPhone; }
        }
    }
}
