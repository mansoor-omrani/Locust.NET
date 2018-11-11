using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Model;
using Locust.Modules.Api.Fields.ApiClientCustomerHub;
using Locust.BaseInfo;
using Locust.Calendar;

namespace Locust.Modules.Api.Model.ApiClientCustomerHub
{
    public class Full:BaseModel
    {
        private BasicData<ApiClientCustomerHubType> _ApiClientCustomerHubType;
        public BasicData<ApiClientCustomerHubType> ApiClientCustomerHubType
        {
            get
            {
                if (_ApiClientCustomerHubType == null)
                    _ApiClientCustomerHubType = new BasicData<ApiClientCustomerHubType>();
                return _ApiClientCustomerHubType;
            }
            set { _ApiClientCustomerHubType = value; }
        }
        private ApiClientCustomerHubId _ApiClientCustomerHubId;
        public ApiClientCustomerHubId ApiClientCustomerHubId
        {
            get
            {
                if (_ApiClientCustomerHubId == null)
                    _ApiClientCustomerHubId = new ApiClientCustomerHubId();
                return _ApiClientCustomerHubId;
            }
            set { _ApiClientCustomerHubId = value; }
        }
        private DateTimeField _CreatedDate;
        public DateTimeField CreatedDate
        {
            get
            {
                if (_CreatedDate == null)
                    _CreatedDate = new DateTimeField();
                return _CreatedDate;
            }
            set { _CreatedDate = value; }
        }
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

        private ApiClient.Full _client;
        public ApiClient.Full Client
        {
            get
            {
                if (_client == null)
                    _client = new ApiClient.Full();
                return _client;
            }
        }
        private MaxCustomer _MaxCustomer;
        public MaxCustomer MaxCustomer
        {
            get
            {
                if (_MaxCustomer == null)
                    _MaxCustomer = new MaxCustomer();
                return _MaxCustomer;
            }
            set { _MaxCustomer = value; }
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
        private HubUniqueCode _HubUniqueCode;
        public HubUniqueCode HubUniqueCode
        {
            get
            {
                if (_HubUniqueCode == null)
                    _HubUniqueCode = new HubUniqueCode();
                return _HubUniqueCode;
            }
            set { _HubUniqueCode = value; }
        }
        private Fields.ApiClient.Title _Title;
        public Fields.ApiClient.Title ApiClientTitle
        {
            get
            {
                if (_Title == null)
                    _Title = new Fields.ApiClient.Title();
                return _Title;
            }
            set { _Title = value; }
        }
        protected override IEnumerable<KeyValuePair<string, object>> GetProperties()
        {
            var result = new List<KeyValuePair<string, object>>();

            result.Add(new KeyValuePair<string, object>("ApiClientCustomerHubId", ApiClientCustomerHubId.Value));
            result.Add(new KeyValuePair<string, object>("ApiClientCustomerHubType", ApiClientCustomerHubType));
            result.Add(new KeyValuePair<string, object>("ApiClientTitle", ApiClientTitle.Value));
            if (CreatedDate.HasValue)
            {
                result.Add(new KeyValuePair<string, object>("CreatedDate", CreatedDate.Gregorian.ToString()));
            }
            else
            {
                result.Add(new KeyValuePair<string, object>("CreatedDate", ""));
            }
            result.Add(new KeyValuePair<string, object>("ApiClientId", ApiClientId.Value));
            result.Add(new KeyValuePair<string, object>("MaxCustomer", MaxCustomer.Value));
            result.Add(new KeyValuePair<string, object>("IsActive", IsActive.Value));
            result.Add(new KeyValuePair<string, object>("HubUniqueCode", HubUniqueCode.Value));

            return result;
        }
    }
}
