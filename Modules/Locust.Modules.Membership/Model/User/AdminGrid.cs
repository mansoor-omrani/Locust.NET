using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ModelField;
using Locust.Modules.Membership.Fields.User;

namespace Locust.Modules.Membership.Model.User
{
    public class AdminGrid:BaseModel
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
        private TInt32 _Row;
        public TInt32 Row
        {
            get
            {
                if (_Row == null)
                    _Row = new TInt32();
                return _Row;
            }
            set { _Row = value; }
        }
        private TString _Name;
        public TString Name
        {
            get
            {
                if (_Name == null)
                    _Name = new TString();
                return _Name;
            }
            set { _Name = value; }
        }
        private TBoolean _IsLegalUser;
        public TBoolean IsLegalUser
        {
            get
            {
                if (_IsLegalUser == null)
                    _IsLegalUser = new TBoolean();
                return _IsLegalUser;
            }
            set { _IsLegalUser = value; }
        }
        protected override IEnumerable<KeyValuePair<string, object>> GetProperties()
        {
            var result = new List<KeyValuePair<string, object>>();

            result.Add(new KeyValuePair<string, object>("Row", Row.Value));
            result.Add(new KeyValuePair<string, object>("Id", Id.Value));
            result.Add(new KeyValuePair<string, object>("UserName", UserName.Value));
            result.Add(new KeyValuePair<string, object>("Email", Email.Value));
            result.Add(new KeyValuePair<string, object>("Name", Name.Value));
            result.Add(new KeyValuePair<string, object>("PhoneNumber", PhoneNumber.Value));
            result.Add(new KeyValuePair<string, object>("EmailConfirmed", EmailConfirmed.Value));
            result.Add(new KeyValuePair<string, object>("PhoneNumberConfirmed", PhoneNumberConfirmed.Value));
            result.Add(new KeyValuePair<string, object>("IsBanned", UserName.Value));
            result.Add(new KeyValuePair<string, object>("IsLegalUser", IsLegalUser.Value));

            return result;
        }
    }
}
