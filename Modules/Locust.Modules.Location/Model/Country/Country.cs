using Locust.Modules.Location.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Model;
using Locust.Modules.Location.Fields.Country;

namespace Locust.Modules.Location.Model.Country
{
  public  class Full: BaseModel
    {
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

            result.Add(new KeyValuePair<string, object>("CountryId", CountryId.Value));
            result.Add(new KeyValuePair<string, object>("Title", Title.Value));
            result.Add(new KeyValuePair<string, object>("Code", Code.Value));

            return result;
        }
    }
}
