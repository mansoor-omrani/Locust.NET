using Locust.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.SMS.Payamtak
{
    public class PayamtakSmsAppConfig: ISMSConfiguration
    {
        public PayamtakSmsAppConfig()
        {
        }
        public string Username
        {
            get { return Config.AppSettings.PayamtakUserName; }
        }

        public string Password
        {
            get { return Config.AppSettings.PayamtakPassword; }
        }

        public string Number
        {
            get { return Config.AppSettings.PayamtakPhone; }
        }
    }
}
