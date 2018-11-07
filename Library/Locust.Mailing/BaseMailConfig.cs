using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Mailing
{
    public class BaseMailConfig: IMailConfig
    {
        public string Username
        {
            get; set;
        }

        public string Password
        {
            get; set;
        }

        public string DefaultMail
        {
            get; set;
        }

        public int Port
        {
            get; set;
        }

        public string Host
        {
            get; set;
        }

        public bool EnableSSL
        {
            get; set;
        }

        public bool UseDefaultCredentials
        {
            get; set;
        }
    }
}
