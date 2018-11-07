using Locust.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.SMS.Payamtak
{
    public class PayamtakSmsIniConfig : ISMSConfiguration
    {
        public string Username
        {
            get { return Config.IniSettings.Sms.PayamtakUserName; }
        }

        public string Password
        {
            get { return Config.IniSettings.Sms.PayamtakPassword; }
        }

        public string Number
        {
            get { return Config.IniSettings.Sms.PayamtakPhone; }
        }
    }
}
