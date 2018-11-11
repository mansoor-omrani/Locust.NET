using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Model;
using Locust.Modules.Api.Fields.Api;
using AppFields = Locust.Modules.Base.Fields.Application;

namespace Locust.Modules.Api.Model.Api
{
    public class AdminGrid: BaseModel
    {
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
        private AppFields.AppId _AppId;
        public AppFields.AppId AppId
        {
            get
            {
                if (_AppId == null)
                    _AppId = new AppFields.AppId();
                return _AppId;
            }
            set { _AppId = value; }
        }
        private Enabled _Enabled;
        public Enabled Enabled
        {
            get
            {
                if (_Enabled == null)
                    _Enabled = new Enabled();
                return _Enabled;
            }
            set { _Enabled = value; }
        }
        private Fields.Api.Service _Service;
        public Fields.Api.Service Service
        {
            get
            {
                if (_Service == null)
                    _Service = new Fields.Api.Service();
                return _Service;
            }
            set { _Service = value; }
        }
        private Strategy _Strategy;
        public Strategy Strategy
        {
            get
            {
                if (_Strategy == null)
                    _Strategy = new Strategy();
                return _Strategy;
            }
            set { _Strategy = value; }
        }
        private EncryptResponse _EncryptResponse;
        public EncryptResponse EncryptResponse
        {
            get
            {
                if (_EncryptResponse == null)
                    _EncryptResponse = new EncryptResponse();
                return _EncryptResponse;
            }
            set { _EncryptResponse = value; }
        }
        private Async _Async;
        public Async Async
        {
            get
            {
                if (_Async == null)
                    _Async = new Async();
                return _Async;
            }
            set { _Async = value; }
        }
        private RequiresEncryptedRequest _RequiresEncryptedRequest;
        public RequiresEncryptedRequest RequiresEncryptedRequest
        {
            get
            {
                if (_RequiresEncryptedRequest == null)
                    _RequiresEncryptedRequest = new RequiresEncryptedRequest();
                return _RequiresEncryptedRequest;
            }
            set { _RequiresEncryptedRequest = value; }
        }
        private CompressedRequest _CompressedRequest;
        public CompressedRequest CompressedRequest
        {
            get
            {
                if (_CompressedRequest == null)
                    _CompressedRequest = new CompressedRequest();
                return _CompressedRequest;
            }
            set { _CompressedRequest = value; }
        }
        private CompressedResponse _CompressedResponse;
        public CompressedResponse CompressedResponse
        {
            get
            {
                if (_CompressedResponse == null)
                    _CompressedResponse = new CompressedResponse();
                return _CompressedResponse;
            }
            set { _CompressedResponse = value; }
        }
        public string ServicePath
        {
            get { return "/" + Service + "/" + Strategy; }
        }
        private AllowExpiredAccessToken _AllowExpiredAccessToken;
        public AllowExpiredAccessToken AllowExpiredAccessToken
        {
            get
            {
                if (_AllowExpiredAccessToken == null)
                    _AllowExpiredAccessToken = new AllowExpiredAccessToken();
                return _AllowExpiredAccessToken;
            }
            set { _AllowExpiredAccessToken = value; }
        }
        private Path _Path;
        public Path Path
        {
            get
            {
                if (_Path == null)
                    _Path = new Path();
                return _Path;
            }
            set { _Path = value; }
        }
        private ApiPath _ApiPath;
        public ApiPath ApiPath
        {
            get
            {
                if (_ApiPath == null)
                    _ApiPath = new ApiPath();
                return _ApiPath;
            }
            set { _ApiPath = value; }
        }
        private UseArrayForJsonSerialization _UseArrayForJsonSerialization;
        public UseArrayForJsonSerialization UseArrayForJsonSerialization
        {
            get
            {
                if (_UseArrayForJsonSerialization == null)
                    _UseArrayForJsonSerialization = new UseArrayForJsonSerialization();
                return _UseArrayForJsonSerialization;
            }
            set { _UseArrayForJsonSerialization = value; }
        }
        private AppFields.ShortName _AppShortName;
        public AppFields.ShortName AppShortName
        {
            get
            {
                if (_AppShortName == null)
                    _AppShortName = new AppFields.ShortName();
                return _AppShortName;
            }
            set { _AppShortName = value; }
        }
        private AppFields.Title _AppTitle;
        public AppFields.Title AppTitle
        {
            get
            {
                if (_AppTitle == null)
                    _AppTitle = new AppFields.Title();
                return _AppTitle;
            }
            set { _AppTitle = value; }
        }
        private Namespace _Namespace;
        public Namespace Namespace
        {
            get
            {
                if (_Namespace == null)
                    _Namespace = new Namespace();
                return _Namespace;
            }
            set { _Namespace = value; }
        }
        private Fields.Api.Version _Version;
        public Fields.Api.Version Version
        {
            get
            {
                if (_Version == null)
                    _Version = new Fields.Api.Version();
                return _Version;
            }
            set { _Version = value; }
        }
        protected override IEnumerable<KeyValuePair<string, object>> GetProperties()
        {
            var result = new List<KeyValuePair<string, object>>();

            result.Add(new KeyValuePair<string, object>("ApiId", ApiId.Value));
            result.Add(new KeyValuePair<string, object>("AppId", AppId.Value));
            result.Add(new KeyValuePair<string, object>("Enabled", Enabled.Value));
            result.Add(new KeyValuePair<string, object>("EncryptResponse", EncryptResponse.Value));
            result.Add(new KeyValuePair<string, object>("Async", Async.Value));
            result.Add(new KeyValuePair<string, object>("Service", Service.Value));
            result.Add(new KeyValuePair<string, object>("Strategy", Strategy.Value));
            result.Add(new KeyValuePair<string, object>("RequiresEncryptedRequest", RequiresEncryptedRequest.Value));
            result.Add(new KeyValuePair<string, object>("CompressedRequest", CompressedRequest.Value));
            result.Add(new KeyValuePair<string, object>("CompressedResponse", CompressedResponse.Value));
            result.Add(new KeyValuePair<string, object>("AllowExpiredAccessToken", AllowExpiredAccessToken.Value));
            result.Add(new KeyValuePair<string, object>("UseArrayForJsonSerialization", UseArrayForJsonSerialization.Value));
            result.Add(new KeyValuePair<string, object>("Path", Path.Value));
            result.Add(new KeyValuePair<string, object>("ApiPath", ApiPath.Value));
            result.Add(new KeyValuePair<string, object>("AppShortName", AppShortName.Value));
            result.Add(new KeyValuePair<string, object>("AppTitle", AppTitle.Value));
            result.Add(new KeyValuePair<string, object>("Namespace", Namespace.Value));
            result.Add(new KeyValuePair<string, object>("Version", Version.Value));

            return result;
        }
    }
}
