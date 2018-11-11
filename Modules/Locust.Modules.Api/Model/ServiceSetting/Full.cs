using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Model;
using Locust.Modules.Api.Fields.ServiceSetting;

namespace Locust.Modules.Api.Model.ServiceSetting
{
    public class Full : BaseModel
    {
        private ServiceSettingId _ServiceSettingId;
        public ServiceSettingId SettingId
        {
            get
            {
                if (_ServiceSettingId == null)
                    _ServiceSettingId = new ServiceSettingId();
                return _ServiceSettingId;
            }
            set { _ServiceSettingId = value; }
        }
        private Fields.ServiceSetting.Service _Service;
        public Fields.ServiceSetting.Service Service
        {
            get
            {
                if (_Service == null)
                    _Service = new Fields.ServiceSetting.Service();
                return _Service;
            }
            set { _Service = value; }
        }
        private Key _Key;
        public Key Key
        {
            get
            {
                if (_Key == null)
                    _Key = new Key();
                return _Key;
            }
            set { _Key = value; }
        }
        private Value _Value;
        public Value Value
        {
            get
            {
                if (_Value == null)
                    _Value = new Value();
                return _Value;
            }
            set { _Value = value; }
        }
        protected override IEnumerable<KeyValuePair<string, object>> GetProperties()
        {
            var result = new List<KeyValuePair<string, object>>();

            result.Add(new KeyValuePair<string, object>("SettingId", SettingId.Value));
            result.Add(new KeyValuePair<string, object>("Service", Service.Value));
            result.Add(new KeyValuePair<string, object>("Key", Key.Value));
            result.Add(new KeyValuePair<string, object>("Value", Value.Value));

            return result;
        }
    }
}
