using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Conversion;
using Locust.Model;
using Locust.Modules.Api.Fields.ApiClientCustomer;
using Locust.Modules.Api.Fields.ApiClientCustomerHub;
using UserFields = Locust.Modules.Membership.Fields.User;

namespace Locust.Modules.Api.Model.ApiClientCustomer
{
    public class Full:BaseModel
    {
        private AccessToken _AccessToken;
        public AccessToken AccessToken
        {
            get
            {
                if (_AccessToken == null)
                    _AccessToken = new AccessToken();
                return _AccessToken;
            }
            set { _AccessToken = value; }
        }
        private RefreshToken _RefreshToken;
        public RefreshToken RefreshToken
        {
            get
            {
                if (_RefreshToken == null)
                    _RefreshToken = new RefreshToken();
                return _RefreshToken;
            }
            set { _RefreshToken = value; }
        }
        private NewAccessToken _NewAccessToken;
        public NewAccessToken NewAccessToken
        {
            get
            {
                if (_NewAccessToken == null)
                    _NewAccessToken = new NewAccessToken();
                return _NewAccessToken;
            }
            set { _NewAccessToken = value; }
        }
        private NewRefreshToken _NewRefreshToken;
        public NewRefreshToken NewRefreshToken
        {
            get
            {
                if (_NewRefreshToken == null)
                    _NewRefreshToken = new NewRefreshToken();
                return _NewRefreshToken;
            }
            set { _NewRefreshToken = value; }
        }
        private ApiClientCustomerId _ApiClientCustomerId;
        public ApiClientCustomerId ApiClientCustomerId
        {
            get
            {
                if (_ApiClientCustomerId == null)
                    _ApiClientCustomerId = new ApiClientCustomerId();
                return _ApiClientCustomerId;
            }
            set { _ApiClientCustomerId = value; }
        }
        private Fields.ApiClientCustomerHub.ApiClientCustomerHubId _ApiClientCustomerHubId;
        public Fields.ApiClientCustomerHub.ApiClientCustomerHubId ApiClientCustomerHubId
        {
            get
            {
                if (_ApiClientCustomerHubId == null)
                    _ApiClientCustomerHubId = new Fields.ApiClientCustomerHub.ApiClientCustomerHubId();
                return _ApiClientCustomerHubId;
            }
            set { _ApiClientCustomerHubId = value; }
        }
        private ApiClientCustomerHub.Full _hub;

        public ApiClientCustomerHub.Full Hub
        {
            get
            {
                if (_hub == null)
                    _hub = new ApiClientCustomerHub.Full();
                return _hub;
            }
        }

        private UserFields.Id _Id;
        public UserFields.Id UserId
        {
            get
            {
                if (_Id == null)
                    _Id = new UserFields.Id();
                return _Id;
            }
            set { _Id = value; }
        }
        private UserFields.UserName _UserName;
        public UserFields.UserName UserUserName
        {
            get
            {
                if (_UserName == null)
                    _UserName = new UserFields.UserName();
                return _UserName;
            }
            set { _UserName = value; }
        }
        private LifeLength _LifeLength;
        public LifeLength LifeLength
        {
            get
            {
                if (_LifeLength == null)
                    _LifeLength = new LifeLength();
                return _LifeLength;
            }
            set { _LifeLength = value; }
        }
        private CreatedDate _CreatedDate;
        public CreatedDate CreatedDate
        {
            get
            {
                if (_CreatedDate == null)
                    _CreatedDate = new CreatedDate();
                return _CreatedDate;
            }
            set { _CreatedDate = value; }
        }
        private LastRefreshDate _LastRefreshDate;
        public LastRefreshDate LastRefreshDate
        {
            get
            {
                if (_LastRefreshDate == null)
                    _LastRefreshDate = new LastRefreshDate();
                return _LastRefreshDate;
            }
            set { _LastRefreshDate = value; }
        }
        private RegisterDate _RegisterDate;
        public RegisterDate RegisterDate
        {
            get
            {
                if (_RegisterDate == null)
                    _RegisterDate = new RegisterDate();
                return _RegisterDate;
            }
            set { _RegisterDate = value; }
        }
        private ActivationDate _ActivationDate;
        public ActivationDate ActivationDate
        {
            get
            {
                if (_ActivationDate == null)
                    _ActivationDate = new ActivationDate();
                return _ActivationDate;
            }
            set { _ActivationDate = value; }
        }
        private NewLastRefreshDate _NewLastRefreshDate;
        public NewLastRefreshDate NewLastRefreshDate
        {
            get
            {
                if (_NewLastRefreshDate == null)
                    _NewLastRefreshDate = new NewLastRefreshDate();
                return _NewLastRefreshDate;
            }
            set { _NewLastRefreshDate = value; }
        }
        private Activated _Activated;
        public Activated Activated
        {
            get
            {
                if (_Activated == null)
                    _Activated = new Activated();
                return _Activated;
            }
            set { _Activated = value; }
        }
        private Disabled _Disabled;
        public Disabled Disabled
        {
            get
            {
                if (_Disabled == null)
                    _Disabled = new Disabled();
                return _Disabled;
            }
            set { _Disabled = value; }
        }
        private IsLocked _IsLocked;
        public IsLocked IsLocked
        {
            get
            {
                if (_IsLocked == null)
                    _IsLocked = new IsLocked();
                return _IsLocked;
            }
            set { _IsLocked = value; }
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
        private ActivationCode _ActivationCode;
        public ActivationCode ActivationCode
        {
            get
            {
                if (_ActivationCode == null)
                    _ActivationCode = new ActivationCode();
                return _ActivationCode;
            }
            set { _ActivationCode = value; }
        }
        private EncryptionCode _EncryptionCode;
        public EncryptionCode EncryptionCode
        {
            get
            {
                if (_EncryptionCode == null)
                    _EncryptionCode = new EncryptionCode();
                return _EncryptionCode;
            }
            set { _EncryptionCode = value; }
        }
        private HashCode _HashCode;
        public HashCode HashCode
        {
            get
            {
                if (_HashCode == null)
                    _HashCode = new HashCode();
                return _HashCode;
            }
            set { _HashCode = value; }
        }
        private ActivationRequestCode _ActivationRequestCode;
        public ActivationRequestCode ActivationRequestCode
        {
            get
            {
                if (_ActivationRequestCode == null)
                    _ActivationRequestCode = new ActivationRequestCode();
                return _ActivationRequestCode;
            }
            set { _ActivationRequestCode = value; }
        }
        private NewEncryptionCode _NewEncryptionCode;
        public NewEncryptionCode NewEncryptionCode
        {
            get
            {
                if (_NewEncryptionCode == null)
                    _NewEncryptionCode = new NewEncryptionCode();
                return _NewEncryptionCode;
            }
            set { _NewEncryptionCode = value; }
        }
        private Validity _Validity;
        public Validity Validity
        {
            get
            {
                if (_Validity == null)
                    _Validity = new Validity();
                return _Validity;
            }
            set { _Validity = value; }
        }
        private CustomerType _CustomerType;
        public CustomerType CustomerType
        {
            get
            {
                if (_CustomerType == null)
                    _CustomerType = new CustomerType();
                return _CustomerType;
            }
            set { _CustomerType = value; }
        }
        public bool HasValidToken
        {
            get
            {
                var result = Validity == "Valid";
                //var now = DateTime.Now;

                //if (!LastRefreshDate.HasValue)
                //{
                //    if (!RegisterDate.HasValue)
                //        result = false;
                //    else
                //    {
                //        var registerDate = RegisterDate.Gregorian.ToDateTime();
                        
                //        if (registerDate > now)
                //            result = false;
                //        else if ((now - registerDate).TotalMinutes < 0)
                //            result = false;
                //        else if ((now - registerDate).TotalMinutes > LifeLength)
                //            result = false;
                //    }
                //}
                //else
                //{
                //    var lastRefresh = LastRefreshDate.Gregorian.ToDateTime();
                //    if (lastRefresh > now)
                //        result = false;
                //    else if ((now - lastRefresh).TotalMinutes > LifeLength)
                //        result = false;
                //}

                return result;
            }
        }
        private RemainingLife _RemainingLife;
        public RemainingLife RemainingLife
        {
            get
            {
                if (_RemainingLife == null)
                    _RemainingLife = new RemainingLife();
                return _RemainingLife;
            }
        }
        //public int RemainingLife
        //{
        //    get
        //    {
        //        var result = 0;

        //        if (LastRefreshDate == null)
        //        {
        //            if (RegisterDate.HasValue)
        //            {
        //                result = SafeClrConvert.ToInt32(LifeLength - (DateTime.Now - RegisterDate.Gregorian.ToDateTime()).TotalMinutes);
        //            }
        //        }
        //        else
        //        {
        //            result = SafeClrConvert.ToInt32(LifeLength - (DateTime.Now - LastRefreshDate.Gregorian.ToDateTime()).TotalMinutes);
        //        }

        //        if (result < 0)
        //            result = 0;

        //        return result;
        //    }
        //}
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
        protected override IEnumerable<KeyValuePair<string, object>> GetProperties()
        {
            var result = new List<KeyValuePair<string, object>>();

            result.Add(new KeyValuePair<string, object>("AccessToken", AccessToken.Value));
            result.Add(new KeyValuePair<string, object>("RefreshToken", RefreshToken.Value));
            result.Add(new KeyValuePair<string, object>("NewAccessToken", NewAccessToken.Value));
            result.Add(new KeyValuePair<string, object>("NewRefreshToken", NewRefreshToken.Value));
            result.Add(new KeyValuePair<string, object>("ApiClientCustomerId", ApiClientCustomerId.Value));
            result.Add(new KeyValuePair<string, object>("ApiClientCustomerHubId", ApiClientCustomerHubId.Value));
            result.Add(new KeyValuePair<string, object>("UserId", UserId.Value));
            result.Add(new KeyValuePair<string, object>("LifeLength", LifeLength.Value));
            result.Add(new KeyValuePair<string, object>("CreatedDate", CreatedDate.Gregorian.ToDateTime()));
            result.Add(new KeyValuePair<string, object>("LastRefreshDate", LastRefreshDate.Gregorian.ToDateTime()));
            result.Add(new KeyValuePair<string, object>("RegisterDate", RegisterDate.Gregorian.ToDateTime()));
            result.Add(new KeyValuePair<string, object>("ActivationDate", ActivationDate.Gregorian.ToDateTime()));
            result.Add(new KeyValuePair<string, object>("NewLastRefreshDate", NewLastRefreshDate.Gregorian.ToDateTime()));
            result.Add(new KeyValuePair<string, object>("Activated", Activated.Value));
            result.Add(new KeyValuePair<string, object>("Disabled", Disabled.Value));
            result.Add(new KeyValuePair<string, object>("HardwareCode", HardwareCode.Value));
            result.Add(new KeyValuePair<string, object>("ActivationCode", ActivationCode.Value));
            result.Add(new KeyValuePair<string, object>("EncryptionCode", EncryptionCode.Value));
            result.Add(new KeyValuePair<string, object>("HashCode", HashCode.Value));
            result.Add(new KeyValuePair<string, object>("ActivationRequestCode", ActivationRequestCode.Value));
            result.Add(new KeyValuePair<string, object>("NewEncryptionCode", NewEncryptionCode.Value));
            result.Add(new KeyValuePair<string, object>("Validity", Validity.Value));
            result.Add(new KeyValuePair<string, object>("CustomerType", CustomerType.Value));
            result.Add(new KeyValuePair<string, object>("RemainingLife", RemainingLife.Value));
            result.Add(new KeyValuePair<string, object>("HubUniqueCode", HubUniqueCode.Value));

            return result;
        }
    }
}
