using System;

namespace Locust.Configuration
{
    public class Config
    {
        private static dynamic _appConfig;
        public static dynamic AppSettings { get { return _appConfig; } }
        private static dynamic _iniSettings;
        public static dynamic IniSettings { get { return _iniSettings;} }
        static Config()
        {
            _appConfig = new AppConfig();
            _iniSettings = new IniSetting();
        }
    }
}
