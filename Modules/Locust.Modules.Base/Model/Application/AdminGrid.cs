using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Calendar;
using Locust.Model;
using Locust.ModelField;
using Locust.Modules.Base.Fields.Application;

namespace Locust.Modules.Base.Model.Application
{
    public class AdminGrid : BaseModel
    {
        private AppId _AppId;
        public AppId AppId
        {
            get
            {
                if (_AppId == null)
                    _AppId = new AppId();
                return _AppId;
            }
            set { _AppId = value; }
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
        private AllowAnonymousHardwareRegistration _AllowAnonymousHardwareRegistration;
        public AllowAnonymousHardwareRegistration AllowAnonymousHardwareRegistration
        {
            get
            {
                if (_AllowAnonymousHardwareRegistration == null)
                    _AllowAnonymousHardwareRegistration = new AllowAnonymousHardwareRegistration();
                return _AllowAnonymousHardwareRegistration;
            }
            set { _AllowAnonymousHardwareRegistration = value; }
        }
        private AllowAnonymousIPRegistration _AllowAnonymousIPRegistration;
        public AllowAnonymousIPRegistration AllowAnonymousIPRegistration
        {
            get
            {
                if (_AllowAnonymousIPRegistration == null)
                    _AllowAnonymousIPRegistration = new AllowAnonymousIPRegistration();
                return _AllowAnonymousIPRegistration;
            }
            set { _AllowAnonymousIPRegistration = value; }
        }
        private RegisterBySerialNo _RegisterBySerialNo;
        public RegisterBySerialNo RegisterBySerialNo
        {
            get
            {
                if (_RegisterBySerialNo == null)
                    _RegisterBySerialNo = new RegisterBySerialNo();
                return _RegisterBySerialNo;
            }
            set { _RegisterBySerialNo = value; }
        }
        private RequiresImmediateApiCall _RequiresImmediateApiCall;
        public RequiresImmediateApiCall RequiresImmediateApiCall
        {
            get
            {
                if (_RequiresImmediateApiCall == null)
                    _RequiresImmediateApiCall = new RequiresImmediateApiCall();
                return _RequiresImmediateApiCall;
            }
            set { _RequiresImmediateApiCall = value; }
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
        private Code _Code;
        public Code Code
        {
            get
            {
                if (_Code == null)
                    _Code = new Code();
                return _Code;
            }
            set { _Code = value; }
        }
        private Version _Version;
        public Version Version
        {
            get
            {
                if (_Version == null)
                    _Version = new Version();
                return _Version;
            }
            set { _Version = value; }
        }
        private Host _Host;
        public Host Host
        {
            get
            {
                if (_Host == null)
                    _Host = new Host();
                return _Host;
            }
            set { _Host = value; }
        }
        private BaseAddress _BaseAddress;
        public BaseAddress BaseAddress
        {
            get
            {
                if (_BaseAddress == null)
                    _BaseAddress = new BaseAddress();
                return _BaseAddress;
            }
            set { _BaseAddress = value; }
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
        private TInt32 _DefaultCustomerId;
        public TInt32 DefaultCustomerId
        {
            get
            {
                if (_DefaultCustomerId == null)
                    _DefaultCustomerId = new TInt32();
                return _DefaultCustomerId;
            }
            set { _DefaultCustomerId = value; }
        }
        private ShortName _ShortName;
        public ShortName ShortName
        {
            get
            {
                if (_ShortName == null)
                    _ShortName = new ShortName();
                return _ShortName;
            }
            set { _ShortName = value; }
        }

        private MultipleActivationRoutes _MultipleActivationRoutes;
        public MultipleActivationRoutes MultipleActivationRoutes
        {
            get
            {
                if (_MultipleActivationRoutes == null)
                    _MultipleActivationRoutes = new MultipleActivationRoutes();
                return _MultipleActivationRoutes;
            }
            set { _MultipleActivationRoutes = value; }
        }
        private IList<Model.AppCrossOrigin.AdminGrid> _CrossOrigins;
        public IList<Model.AppCrossOrigin.AdminGrid> CrossOrigins
        {
            get
            {
                if (_CrossOrigins == null)
                    _CrossOrigins = new List<Model.AppCrossOrigin.AdminGrid>();
                return _CrossOrigins;
            }
            set { _CrossOrigins = value; }
        }

        public int ApiCount { get; set; }
        public int ClientCount { get; set; }
        public int OriginCount { get; set; }
        public int SettingCount { get; set; }
        protected override IEnumerable<KeyValuePair<string, object>> GetProperties()
        {
            var result = new List<KeyValuePair<string, object>>();

            result.Add(new KeyValuePair<string, object>("AppId", AppId.Value));
            result.Add(new KeyValuePair<string, object>("DefaultCustomerId", DefaultCustomerId.Value));
            result.Add(new KeyValuePair<string, object>("CreatedDate", CreatedDate.Gregorian.ToDateTime()));
            result.Add(new KeyValuePair<string, object>("AllowAnonymousHardwareRegistration", AllowAnonymousHardwareRegistration.Value));
            result.Add(new KeyValuePair<string, object>("AllowAnonymousIPRegistration", AllowAnonymousIPRegistration.Value));
            result.Add(new KeyValuePair<string, object>("RegisterBySerialNo", RegisterBySerialNo.Value));
            result.Add(new KeyValuePair<string, object>("RequiresImmediateApiCall", RequiresImmediateApiCall.Value));
            result.Add(new KeyValuePair<string, object>("IsActive", IsActive.Value));
            result.Add(new KeyValuePair<string, object>("Code", Code.Value));
            result.Add(new KeyValuePair<string, object>("Version", Version.Value));
            result.Add(new KeyValuePair<string, object>("Host", Host.Value));
            result.Add(new KeyValuePair<string, object>("BaseAddress", BaseAddress.Value));
            result.Add(new KeyValuePair<string, object>("ShortName", ShortName.Value));
            result.Add(new KeyValuePair<string, object>("Title", Title.Value));
            result.Add(new KeyValuePair<string, object>("Description", Description.Value));
            result.Add(new KeyValuePair<string, object>("MultipleActivationRoutes", MultipleActivationRoutes.Value));
            result.Add(new KeyValuePair<string, object>("CrossOrigins", CrossOrigins));
            result.Add(new KeyValuePair<string, object>("ApiCount", ApiCount));
            result.Add(new KeyValuePair<string, object>("ClientCount", ClientCount));
            result.Add(new KeyValuePair<string, object>("OriginCount", OriginCount));
            result.Add(new KeyValuePair<string, object>("SettingCount", SettingCount));

            return result;
        }
    }
}
