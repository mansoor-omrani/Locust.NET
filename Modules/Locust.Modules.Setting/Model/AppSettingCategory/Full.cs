using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Model;
using Locust.Modules.Setting.Fields.AppSettingCategory;
using AppFields = Locust.Modules.Base.Fields.Application;

namespace Locust.Modules.Setting.Model.AppSettingCategory
{
    public class Full : BaseModel
    {
        private AppSettingCategoryID _AppSettingCategoryID;
        public AppSettingCategoryID AppSettingCategoryID
        {
            get
            {
                if (_AppSettingCategoryID == null)
                    _AppSettingCategoryID = new AppSettingCategoryID();
                return _AppSettingCategoryID;
            }
            set { _AppSettingCategoryID = value; }
        }
        private AppFields.AppId _AppId;
        public AppFields.AppId AppId
        {
            get
            {
                if (_AppId == null)
                    _AppId = new AppFields.AppId();
                return _AppId;
            }
            set { _AppId = value; }
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

            result.Add(new KeyValuePair<string, object>("Id", AppSettingCategoryID.Value));
            result.Add(new KeyValuePair<string, object>("AppId", AppId.Value));
            result.Add(new KeyValuePair<string, object>("Code", Code.Value));
            result.Add(new KeyValuePair<string, object>("Title", Title.Value));
            result.Add(new KeyValuePair<string, object>("Description", Description.Value));

            return result;
        }
    }
}
