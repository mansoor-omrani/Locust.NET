using Locust.Conversion;
using Locust.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Mailing.Smtp
{
    public class SmtpMailAppConfig: IMailConfig
    {
        private dynamic config;
        public SmtpMailAppConfig()
        {
            config = new AppConfigSettings();
        }
        public string Username
        {
            get
            {
                return SafeClrConvert.ToString(config.SmtpUser);
            }
        }

        public string Password
        {
            get
            {
                return SafeClrConvert.ToString(config.SmtpPass);
            }
        }

        public string DefaultMail
        {
            get
            {
                return SafeClrConvert.ToString(config.SmtpDefaultMail);
            }
        }

        public int Port
        {
            get
            {
                return SafeClrConvert.ToInt32(config.SmtpPort);
            }
        }

        public string Host
        {
            get
            {
                return SafeClrConvert.ToString(config.SmtpHost);
            }
        }

        public bool EnableSSL
        {
            get
            {
                return SafeClrConvert.ToBoolean(config.SmtpEnableSSL);
            }
        }

        public bool UseDefaultCredentials
        {
            get
            {
                return SafeClrConvert.ToBoolean(config.SmtpUseDefaultCredentials);
            }
        }
    }
}
