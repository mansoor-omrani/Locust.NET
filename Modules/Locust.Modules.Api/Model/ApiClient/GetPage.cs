using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Modules.Api.Fields.ApiClient;
using Locust.Model;
using Locust.ModelField;

namespace Locust.Modules.Api.Model.ApiClient
{
    public class GetPage : BaseModel
    {
        private TInt _Row;
        public TInt Row
        {
            get
            {
                if (_Row == null)
                    _Row = new TInt();
                return _Row;
            }
            set { _Row = value; }
        }
        private ClientKey _ClientKey;
        public ClientKey ClientKey
        {
            get
            {
                if (_ClientKey == null)
                    _ClientKey = new ClientKey();
                return _ClientKey;
            }
            set { _ClientKey = value; }
        }
        private ApiClientId _ApiClientId;
        public ApiClientId ApiClientId
        {
            get
            {
                if (_ApiClientId == null)
                    _ApiClientId = new ApiClientId();
                return _ApiClientId;
            }
            set { _ApiClientId = value; }
        }
        private Base.Fields.Application.AppId _AppId;
        public Base.Fields.Application.AppId AppId
        {
            get
            {
                if (_AppId == null)
                    _AppId = new Base.Fields.Application.AppId();
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
        private AllowAnyIPAddress _AllowAnyIPAddress;
        public AllowAnyIPAddress AllowAnyIPAddress
        {
            get
            {
                if (_AllowAnyIPAddress == null)
                    _AllowAnyIPAddress = new AllowAnyIPAddress();
                return _AllowAnyIPAddress;
            }
            set { _AllowAnyIPAddress = value; }
        }
        private ClientSecret _ClientSecret;
        public ClientSecret ClientSecret
        {
            get
            {
                if (_ClientSecret == null)
                    _ClientSecret = new ClientSecret();
                return _ClientSecret;
            }
            set { _ClientSecret = value; }
        }
        private HardwareCode _HardwareCode;
        public HardwareCode HardwareCode
        {
            get
            {
                if (_HardwareCode == null)
                    _HardwareCode = new HardwareCode();
                return _HardwareCode;
            }
            set { _HardwareCode = value; }
        }
        private FinishPaymentReturnUrl _FinishPaymentReturnUrl;
        public FinishPaymentReturnUrl FinishPaymentReturnUrl
        {
            get
            {
                if (_FinishPaymentReturnUrl == null)
                    _FinishPaymentReturnUrl = new FinishPaymentReturnUrl();
                return _FinishPaymentReturnUrl;
            }
            set { _FinishPaymentReturnUrl = value; }
        }
        private Title _Title;
        public Title Title
        {
            get
            {
                if (_Title == null)
                    _Title = new Title();
                return _Title;
            }
            set { _Title = value; }
        }
        private Description _Description;
        public Description Description
        {
            get
            {
                if (_Description == null)
                    _Description = new Description();
                return _Description;
            }
            set { _Description = value; }
        }
        private Website _Website;
        public Website Website
        {
            get
            {
                if (_Website == null)
                    _Website = new Website();
                return _Website;
            }
            set { _Website = value; }
        }
        private Photo _Photo;
        public Photo Photo
        {
            get
            {
                if (_Photo == null)
                    _Photo = new Photo();
                return _Photo;
            }
            set { _Photo = value; }
        }
        private TheaterCode _TheaterCode;
        public TheaterCode TheaterCode
        {
            get
            {
                if (_TheaterCode == null)
                    _TheaterCode = new TheaterCode();
                return _TheaterCode;
            }
            set { _TheaterCode = value; }
        }
        private TString _TheaterName;
        public TString TheaterName
        {
            get
            {
                if (_TheaterName == null)
                    _TheaterName = new TString();
                return _TheaterName;
            }
            set { _TheaterName = value; }
        }
        protected override IEnumerable<KeyValuePair<string, object>> GetProperties()
        {
            var result = new List<KeyValuePair<string, object>>();

            result.Add(new KeyValuePair<string, object>("Row", Row.Value));
            result.Add(new KeyValuePair<string, object>("AppId", AppId.Value));
            result.Add(new KeyValuePair<string, object>("ApiClientId", ApiClientId.Value));
            result.Add(new KeyValuePair<string, object>("ClientKey", ClientKey.Value));
            result.Add(new KeyValuePair<string, object>("Enabled", Enabled.Value));
            result.Add(new KeyValuePair<string, object>("AllowAnyIPAddress", AllowAnyIPAddress.Value));
            result.Add(new KeyValuePair<string, object>("ClientSecret", ClientSecret.Value));
            result.Add(new KeyValuePair<string, object>("HardwareCode", HardwareCode.Value));
            result.Add(new KeyValuePair<string, object>("FinishPaymentReturnUrl", FinishPaymentReturnUrl.Value));
            result.Add(new KeyValuePair<string, object>("Title", Title.Value));
            result.Add(new KeyValuePair<string, object>("Description", Description.Value));
            result.Add(new KeyValuePair<string, object>("Website", Website.Value));
            result.Add(new KeyValuePair<string, object>("Photo", Photo.Value));
            result.Add(new KeyValuePair<string, object>("TheaterCode", TheaterCode.Value));
            result.Add(new KeyValuePair<string, object>("TheaterName", TheaterName.Value));

            return result;
        }
    }
}
