using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Configuration;

namespace Locust.SMS.Farapayamak
{
    public class FarapayamakSmsIniConfig:ISMSConfiguration
    {
        public string Username
        {
            get { return Config.IniSettings.Sms.FarapayamakUserName; }
        }

        public string Password
        {
            get { return Config.IniSettings.Sms.FarapayamakPassword; }
        }

        public string Number
        {
            get { return Config.IniSettings.Sms.FarapayamakPhone; }
        }
    }
}
