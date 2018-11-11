using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Model;
using Locust.Modules.Membership.Fields.User;

namespace Locust.Modules.Membership.Model.User
{
    public class Full:BaseModel
    {
        private Id _Id;
        public Id Id
        {
            get
            {
                if (_Id == null)
                    _Id = new Id();
                return _Id;
            }
            set { _Id = value; }
        }
        private AccessFailedCount _AccessFailedCount;
        public AccessFailedCount AccessFailedCount
        {
            get
            {
                if (_AccessFailedCount == null)
                    _AccessFailedCount = new AccessFailedCount();
                return _AccessFailedCount;
            }
            set { _AccessFailedCount = value; }
        }
        private LockoutEndDateUtc _LockoutEndDateUtc;
        public LockoutEndDateUtc LockoutEndDateUtc
        {
            get
            {
                if (_LockoutEndDateUtc == null)
                    _LockoutEndDateUtc = new LockoutEndDateUtc();
                return _LockoutEndDateUtc;
            }
            set { _LockoutEndDateUtc = value; }
        }
        private EmailConfirmed _EmailConfirmed;
        public EmailConfirmed EmailConfirmed
        {
            get
            {
                if (_EmailConfirmed == null)
                    _EmailConfirmed = new EmailConfirmed();
                return _EmailConfirmed;
            }
            set { _EmailConfirmed = value; }
        }
        private PhoneNumberConfirmed _PhoneNumberConfirmed;
        public PhoneNumberConfirmed PhoneNumberConfirmed
        {
            get
            {
                if (_PhoneNumberConfirmed == null)
                    _PhoneNumberConfirmed = new PhoneNumberConfirmed();
                return _PhoneNumberConfirmed;
            }
            set { _PhoneNumberConfirmed = value; }
        }
        private TwoFactorEnabled _TwoFactorEnabled;
        public TwoFactorEnabled TwoFactorEnabled
        {
            get
            {
                if (_TwoFactorEnabled == null)
                    _TwoFactorEnabled = new TwoFactorEnabled();
                return _TwoFactorEnabled;
            }
            set { _TwoFactorEnabled = value; }
        }
        private LockoutEnabled _LockoutEnabled;
        public LockoutEnabled LockoutEnabled
        {
            get
            {
                if (_LockoutEnabled == null)
                    _LockoutEnabled = new LockoutEnabled();
                return _LockoutEnabled;
            }
            set { _LockoutEnabled = value; }
        }
        private Email _Email;
        public Email Email
        {
            get
            {
                if (_Email == null)
                    _Email = new Email();
                return _Email;
            }
            set { _Email = value; }
        }
        private PasswordHash _PasswordHash;
        public PasswordHash PasswordHash
        {
            get
            {
                if (_PasswordHash == null)
                    _PasswordHash = new PasswordHash();
                return _PasswordHash;
            }
            set { _PasswordHash = value; }
        }
        private SecurityStamp _SecurityStamp;
        public SecurityStamp SecurityStamp
        {
            get
            {
                if (_SecurityStamp == null)
                    _SecurityStamp = new SecurityStamp();
                return _SecurityStamp;
            }
            set { _SecurityStamp = value; }
        }
        private PhoneNumber _PhoneNumber;
        public PhoneNumber PhoneNumber
        {
            get
            {
                if (_PhoneNumber == null)
                    _PhoneNumber = new PhoneNumber();
                return _PhoneNumber;
            }
            set { _PhoneNumber = value; }
        }
        private UserName _UserName;
        public UserName UserName
        {
            get
            {
                if (_UserName == null)
                    _UserName = new UserName();
                return _UserName;
            }
            set { _UserName = value; }
        }
        private IsBanned _IsBanned;
        public IsBanned IsBanned
        {
            get
            {
                if (_IsBanned == null)
                    _IsBanned = new IsBanned();
                return _IsBanned;
            }
            set { _IsBanned = value; }
        }
        protected override IEnumerable<KeyValuePair<string, object>> GetProperties()
        {
            var result = new List<KeyValuePair<string, object>>();

            result.Add(new KeyValuePair<string, object>("Id", Id.Value));
            result.Add(new KeyValuePair<string, object>("AccessFailedCount", AccessFailedCount.Value));
            result.Add(new KeyValuePair<string, object>("LockoutEndDateUtc", LockoutEndDateUtc.Persian.ToString()));
            result.Add(new KeyValuePair<string, object>("EmailConfirmed", EmailConfirmed.Value));
            result.Add(new KeyValuePair<string, object>("PhoneNumberConfirmed", PhoneNumberConfirmed.Value));
            result.Add(new KeyValuePair<string, object>("TwoFactorEnabled", TwoFactorEnabled.Value));
            result.Add(new KeyValuePair<string, object>("LockoutEnabled", LockoutEnabled.Value));
            result.Add(new KeyValuePair<string, object>("Email", Email.Value));
            result.Add(new KeyValuePair<string, object>("PasswordHash", PasswordHash.Value));
            result.Add(new KeyValuePair<string, object>("SecurityStamp", SecurityStamp.Value));
            result.Add(new KeyValuePair<string, object>("PhoneNumber", PhoneNumber.Value));
            result.Add(new KeyValuePair<string, object>("UserName", UserName.Value));
            result.Add(new KeyValuePair<string, object>("IsBanned", UserName.Value));

            return result;
        }
    }
}
