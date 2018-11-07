using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IniParser;
using IniParser.Model;
using Locust.Conversion;

namespace Locust.Configuration
{

    public class IniSetting : DynamicObject
    {
        protected IniData data;
        protected string configPath;

        public string ConfigPath
        {
            get { return configPath; }
            set { configPath = value; }
        }

        private void loadFile(string path, bool setConfigPathBefore, bool setConfigPathAfter)
        {
            if (setConfigPathBefore)
            {
                configPath = path;
            }

            try
            {
                var fileIniData = new FileIniDataParser();

                fileIniData.Parser.Configuration.CaseInsensitive = true;
                data = fileIniData.ReadFile(path);

                if (setConfigPathAfter)
                {
                    configPath = path;
                }
            }
            catch
            {
                data = null;
            }
        }
        public void Configure(string path)
        {
            loadFile(path, true, false);
        }

        public void Load(string path)
        {
            loadFile(path, false, true);
        }

        public void Reload()
        {
            loadFile(ConfigPath, false, false);
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            KeyDataCollection keys = null;

            if (data != null)
            {
                keys = data[binder.Name];
            }

            if (keys == null)
            {
                keys = new KeyDataCollection(StringComparer.OrdinalIgnoreCase);
            }

            result = new IniSettingKeys(keys);

            return true;
        }
        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {
            KeyDataCollection keys = null;

            if (indexes.Length > 0)
            {
                var key = SafeClrConvert.ToString(indexes[0]);

                if (data != null)
                {
                    keys = data[key];
                }
            }

            if (keys == null)
            {
                keys = new KeyDataCollection(StringComparer.OrdinalIgnoreCase);
            }

            result = new IniSettingKeys(keys);

            return true;
        }
        public bool Exists(string key)
        {
            return data[key] != null;
        }
    }

    public class IniSettingKeys : DynamicObject
    {
        private KeyDataCollection _keys;
        public IniSettingKeys(KeyDataCollection keys)
        {
            _keys = keys;
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (_keys != null)
            {
                result = _keys[binder.Name];
            }
            else
            {
                result = null;
            }

            if (result == null)
            {
                result = "";
            }
            else
            {
                
            }

            return true;
        }

        private string ParseValue(string value)
        {
            var result = "";
            var state = 1;

            return result;
        }
        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {
            if (indexes.Length > 0)
            {
                var key = SafeClrConvert.ToString(indexes[0]);

                if (_keys != null)
                {
                    result = _keys[key];
                }
                else
                {
                    result = "";
                }
            }
            else
            {
                result = "";
            }

            if (result == null)
            {
                result = "";
            }

            return true;
        }
        public bool Exists(string key)
        {
            return _keys[key] != null;
        }
    }
}
