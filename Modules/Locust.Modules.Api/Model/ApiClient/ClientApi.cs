using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ModelField;

namespace Locust.Modules.Api.Model.ApiClient
{
    public class ClientApi:BaseModel
    {
        private Fields.Api.ApiId _ApiId;
        public Fields.Api.ApiId ApiId
        {
            get
            {
                if (_ApiId == null)
                    _ApiId = new Fields.Api.ApiId();
                return _ApiId;
            }
            set { _ApiId = value; }
        }
        private Fields.Api.ApiPath _ApiPath;
        public Fields.Api.ApiPath ApiPath
        {
            get
            {
                if (_ApiPath == null)
                    _ApiPath = new Fields.Api.ApiPath();
                return _ApiPath;
            }
            set { _ApiPath = value; }
        }
        private TBoolean _Exists;
        public TBoolean Exists
        {
            get
            {
                if (_Exists == null)
                    _Exists = new TBoolean();
                return _Exists;
            }
            set { _Exists = value; }
        }
        private TBoolean _Enabled;
        public TBoolean Enabled
        {
            get
            {
                if (_Enabled == null)
                    _Enabled = new TBoolean();
                return _Enabled;
            }
            set { _Enabled = value; }
        }
        protected override IEnumerable<KeyValuePair<string, object>> GetProperties()
        {
            var result = new List<KeyValuePair<string, object>>();

            result.Add(new KeyValuePair<string, object>("ApiId", ApiId.Value));
            result.Add(new KeyValuePair<string, object>("ApiPath", ApiPath.Value));
            result.Add(new KeyValuePair<string, object>("Exists", Exists.Value));
            result.Add(new KeyValuePair<string, object>("Enabled", Enabled.Value));

            return result;
        }
    }
}
