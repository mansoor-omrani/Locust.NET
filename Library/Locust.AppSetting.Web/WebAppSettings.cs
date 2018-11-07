using Locust.AppSetting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Locust.AppSetting.Web
{
    public class WebAppSettings : IAppSettings
    {
        public string this[string key]
        {
            get
            {
                return Get(key);
            }

            set
            {
                Set(key, value);
            }
        }

        public string this[int index]
        {
            get
            {
                return WebConfigurationManager.AppSettings[index];
            }

            set
            {
                throw new NotSupportedException();
            }
        }
        public string Get(string key)
        {
            return WebConfigurationManager.AppSettings[key];
        }

        public void Set(string key, string value)
        {
            WebConfigurationManager.AppSettings[key] = value;
        }
    }
}
