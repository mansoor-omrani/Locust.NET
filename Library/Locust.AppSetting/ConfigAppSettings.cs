using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.AppSetting
{
    public class ConfigAppSettings : IAppSettings
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
                return ConfigurationManager.AppSettings[index];
            }

            set
            {
                throw new NotSupportedException();
            }
        }

        public string Get(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public void Set(string key, string value)
        {
            ConfigurationManager.AppSettings[key] = value;
        }
    }
}
