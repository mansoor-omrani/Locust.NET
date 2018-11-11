using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Model;
using Locust.Modules.Base.Fields.Application;
using Locust.Modules.ACL.Fields.RoleCategory;

namespace Locust.Modules.ACL.Model
{
    public class RoleCategory: BaseModel
    {
        private RoleCategoryId _RoleCategoryId;
        public RoleCategoryId RoleCategoryId {
            get
            {
                if (_RoleCategoryId == null)
                    _RoleCategoryId = new RoleCategoryId();
                return _RoleCategoryId;
            }
            set { _RoleCategoryId = value; }
        }
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
        private Fields.RoleCategory.Title _Title;
        public Fields.RoleCategory.Title Title
        {
            get
            {
                if (_Title == null)
                    _Title = new Fields.RoleCategory.Title();
                return _Title;
            }
            set { _Title = value; }
        }
        protected override IEnumerable<KeyValuePair<string, object>> GetProperties()
        {
            var result = new List<KeyValuePair<string, object>>();

            result.Add(new KeyValuePair<string, object>("RoleCategoryId", RoleCategoryId.Value));
            result.Add(new KeyValuePair<string, object>("AppId", AppId.Value));
            result.Add(new KeyValuePair<string, object>("Title", Title.Value));

            return result;
        }
    }
}
