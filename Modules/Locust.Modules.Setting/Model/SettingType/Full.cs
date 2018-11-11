using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Model;
using Locust.Modules.Setting.Fields.SettingType;

namespace Locust.Modules.Setting.Model.SettingType
{
    public class Full:BaseModel
    {
        private SettingTypeId _SettingTypeId;
        public SettingTypeId SettingTypeId
        {
            get
            {
                if (_SettingTypeId == null)
                    _SettingTypeId = new SettingTypeId();
                return _SettingTypeId;
            }
            set { _SettingTypeId = value; }
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
        protected override IEnumerable<KeyValuePair<string, object>> GetProperties()
        {
            var result = new List<KeyValuePair<string, object>>();

            result.Add(new KeyValuePair<string, object>("SettingTypeId", SettingTypeId.Value));
            result.Add(new KeyValuePair<string, object>("Name", Name.Value));
            result.Add(new KeyValuePair<string, object>("Code", Code.Value));
            result.Add(new KeyValuePair<string, object>("Title", Title.Value));
            result.Add(new KeyValuePair<string, object>("Description", Description.Value));

            return result;
        }
    }
}
