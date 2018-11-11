using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Model;
using Locust.Modules.Api.Fields.Api;
using Locust.Modules.Api.Fields.ApiSetting;

namespace Locust.Modules.Api.Model.ApiSetting
{
    public class Full:BaseModel
    {
        private ApiSettingId _ApiSettingId;
        public ApiSettingId ApiSettingId
        {
            get
            {
                if (_ApiSettingId == null)
                    _ApiSettingId = new ApiSettingId();
                return _ApiSettingId;
            }
            set { _ApiSettingId = value; }
        }
        private ApiId _ApiId;
        public ApiId ApiId
        {
            get
            {
                if (_ApiId == null)
                    _ApiId = new ApiId();
                return _ApiId;
            }
            set { _ApiId = value; }
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

            result.Add(new KeyValuePair<string, object>("ApiSettingId", ApiSettingId.Value));
            result.Add(new KeyValuePair<string, object>("ApiId", ApiId.Value));
            result.Add(new KeyValuePair<string, object>("Key", Key.Value));
            result.Add(new KeyValuePair<string, object>("Value", Value.Value));

            return result;
        }
    }
}
