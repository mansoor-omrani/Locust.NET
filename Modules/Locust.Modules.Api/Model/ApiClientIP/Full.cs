using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Model;
using Locust.Modules.Api.Fields.ApiClientIP;

namespace Locust.Modules.Api.Model.ApiClientIP
{
    public class Full:BaseModel
    {
        private Fields.ApiClient.ApiClientId _ApiClientId;
        public Fields.ApiClient.ApiClientId ApiClientId
        {
            get
            {
                if (_ApiClientId == null)
                    _ApiClientId = new Fields.ApiClient.ApiClientId();
                return _ApiClientId;
            }
            set { _ApiClientId = value; }
        }
        private IsActive _IsActive;
        public IsActive IsActive
        {
            get
            {
                if (_IsActive == null)
                    _IsActive = new IsActive();
                return _IsActive;
            }
            set { _IsActive = value; }
        }
        private IP _IP;
        public IP IP
        {
            get
            {
                if (_IP == null)
                    _IP = new IP();
                return _IP;
            }
            set { _IP = value; }
        }
        protected override IEnumerable<KeyValuePair<string, object>> GetProperties()
        {
            var result = new List<KeyValuePair<string, object>>();

            result.Add(new KeyValuePair<string, object>("ApiClientId", ApiClientId.Value));
            result.Add(new KeyValuePair<string, object>("IsActive", IsActive.Value));
            result.Add(new KeyValuePair<string, object>("IP", IP.Value));

            return result;
        }
    }
}
