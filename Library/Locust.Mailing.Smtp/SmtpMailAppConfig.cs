using Locust.Configuration;
using Locust.Conversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Mailing.Smtp
{
    public class SmtpMailAppConfig: IMailConfig
    {
        public SmtpMailAppConfig()
        {
        }
        public string Username
        {
            get
            {
                return SafeClrConvert.ToString(Config.AppSettings.SmtpUser);
            }
        }

        public string Password
        {
            get
            {
                return SafeClrConvert.ToString(Config.AppSettings.SmtpPass);
            }
        }

        public string DefaultMail
        {
            get
            {
                return SafeClrConvert.ToString(Config.AppSettings.SmtpDefaultMail);
            }
        }

        public int Port
        {
            get
            {
                return SafeClrConvert.ToInt32(Config.AppSettings.SmtpPort);
            }
        }

        public string Host
        {
            get
            {
                return SafeClrConvert.ToString(Config.AppSettings.SmtpHost);
            }
        }

        public bool EnableSSL
        {
            get
            {
                return SafeClrConvert.ToBoolean(Config.AppSettings.SmtpEnableSSL);
            }
        }

        public bool UseDefaultCredentials
        {
            get
            {
                return SafeClrConvert.ToBoolean(Config.AppSettings.SmtpUseDefaultCredentials);
            }
        }
    }
}
