using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Setting;

namespace Locust.SMS.Farapayamak
{
    public class FarapayamakSmsAppConfig : ISMSConfiguration
    {
        private dynamic config;
        public FarapayamakSmsAppConfig()
        {
            config = new AppConfigSettings();
        }
        public string Username
        {
            get { return config.FarapayamakUserName; }
        }

        public string Password
        {
            get { return config.FarapayamakPassword; }
        }

        public string Number
        {
            get { return config.FarapayamakPhone; }
        }
    }
}
