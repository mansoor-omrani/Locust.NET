using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Configuration;

namespace Locust.SMS.Farapayamak
{
    public class FarapayamakSmsAppConfig : ISMSConfiguration
    {
        public FarapayamakSmsAppConfig()
        {
        }
        public string Username
        {
            get { return Config.AppSettings.FarapayamakUserName; }
        }

        public string Password
        {
            get { return Config.AppSettings.FarapayamakPassword; }
        }

        public string Number
        {
            get { return Config.AppSettings.FarapayamakPhone; }
        }
    }
}
