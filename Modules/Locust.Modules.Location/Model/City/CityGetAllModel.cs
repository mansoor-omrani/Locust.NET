using Locust.Modules.Location.Fields.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Modules.Location.Fields.State;
using Locust.Model;
using Code = Locust.Modules.Location.Fields.City.Code;
using Name = Locust.Modules.Location.Fields.City.Name;
using Title = Locust.Modules.Location.Fields.City.Title;

namespace Locust.Modules.Location.Model.City
{
    public class CityGetAllModel: BaseModel
    {
        private CityId _CityId;
        public CityId CityId
        {
            get
            {
                if (_CityId == null)
                    _CityId = new CityId();
                return _CityId;
            }
            set { _CityId = value; }
        }
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
        private Fields.State.Title _State;
        public Fields.State.Title State
        {
            get
            {
                if (_State == null)
                    _State = new Fields.State.Title();
                return _State;
            }
            set { _State = value; }
        }
        private Fields.Country.CountryId _CountryId;
        public Fields.Country.CountryId CountryId
        {
            get
            {
                if (_CountryId == null)
                    _CountryId = new Fields.Country.CountryId();
                return _CountryId;
            }
            set { _CountryId = value; }
        }
        private Fields.Country.Title _Country;
        public Fields.Country.Title Country
        {
            get
            {
                if (_Country == null)
                    _Country = new Fields.Country.Title();
                return _Country;
            }
            set { _Country = value; }
        }
        protected override IEnumerable<KeyValuePair<string, object>> GetProperties()
        {
            var result = new List<KeyValuePair<string, object>>();

            result.Add(new KeyValuePair<string, object>("StateId", StateId.Value));
            result.Add(new KeyValuePair<string, object>("CityId", CityId.Value));
            result.Add(new KeyValuePair<string, object>("State", State.Value));
            result.Add(new KeyValuePair<string, object>("CountryId", CountryId.Value));
            result.Add(new KeyValuePair<string, object>("Country", Country.Value));
            result.Add(new KeyValuePair<string, object>("Title", Title.Value));
            result.Add(new KeyValuePair<string, object>("Name", Name.Value));
            result.Add(new KeyValuePair<string, object>("Code", Code.Value));

            return result;
        }
    }
}
