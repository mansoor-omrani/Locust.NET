using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Modules.Location.Fields.City;
using Locust.Model;

namespace Locust.Modules.Location.Model.City
{
    public class CityState:BaseModel
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

            result.Add(new KeyValuePair<string, object>("CityId", CityId.Value));
            result.Add(new KeyValuePair<string, object>("Title", Title.Value));
            result.Add(new KeyValuePair<string, object>("Name", Name.Value));
            result.Add(new KeyValuePair<string, object>("Code", Code.Value));

            return result;
        }
    }
}
