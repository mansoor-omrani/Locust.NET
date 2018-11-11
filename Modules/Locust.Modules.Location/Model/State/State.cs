using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Modules.Location.Fields.Country;
using Locust.Modules.Location.Fields.State;
using Locust.Model;
using Code = Locust.Modules.Location.Fields.State.Code;
using Title = Locust.Modules.Location.Fields.State.Title;

namespace Locust.Modules.Location.Model.State
{
  public  class Full :BaseModel
    {
        private StateId _StateId;
        public StateId StateId
        {
            get
            {
                if (_StateId == null)
                    _StateId = new StateId();
                return _StateId;
            }
            set { _StateId = value; }
        }
        private CountryId _CountryId;
        public CountryId CountryId
        {
            get
            {
                if (_CountryId == null)
                    _CountryId = new CountryId();
                return _CountryId;
            }
            set { _CountryId = value; }
        }
        private OldId _OldId;
        public OldId OldId
        {
            get
            {
                if (_OldId == null)
                    _OldId = new OldId();
                return _OldId;
            }
            set { _OldId = value; }
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
        private Name _Name;
        public Name Name
        {
            get
            {
                if (_Name == null)
                    _Name = new Name();
                return _Name;
            }
            set { _Name = value; }
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
        protected override IEnumerable<KeyValuePair<string, object>> GetProperties()
        {
            var result = new List<KeyValuePair<string, object>>();

            result.Add(new KeyValuePair<string, object>("StateId", StateId.Value));
            result.Add(new KeyValuePair<string, object>("CountryId", CountryId.Value));
            result.Add(new KeyValuePair<string, object>("Code", Code.Value));
            result.Add(new KeyValuePair<string, object>("Name", Name.Value));
            result.Add(new KeyValuePair<string, object>("Title", Title.Value));

            return result;
        }
    }
}
