using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Configuration;
using Locust.Conversion;

namespace Locust.Mailing.Smtp
{
    public class SmtpMailIniConfig : IMailConfig
    {
        public string Username
        {
            get
            {
                return SafeClrConvert.ToString(Config.IniSettings.Email.SmtpUser);
            }
        }

        public string Password
        {
            get
            {
                return SafeClrConvert.ToString(Config.IniSettings.Email.SmtpPass);
            }
        }

        public string DefaultMail
        {
            get
            {
                return SafeClrConvert.ToString(Config.IniSettings.Email.SmtpDefaultMail);
            }
        }

        public int Port
        {
            get
            {
                return SafeClrConvert.ToInt32(Config.IniSettings.Email.SmtpPort);
            }
        }

        public string Host
        {
            get
            {
                return SafeClrConvert.ToString(Config.IniSettings.Email.SmtpHost);
            }
        }

        public bool EnableSSL
        {
            get
            {
                return SafeClrConvert.ToBoolean(Config.IniSettings.Email.SmtpEnableSSL);
            }
        }

        public bool UseDefaultCredentials
        {
            get
            {
                return SafeClrConvert.ToBoolean(Config.IniSettings.Email.SmtpUseDefaultCredentials);
            }
        }
    }
}
