using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Setting
{
    public class AppSetting: ISetting
    {
        public dynamic Config
        {
            get { return Setting.Config; }
        }

        public dynamic Db
        {
            get { return Setting.Db; }
        }

        public dynamic Text
        {
            get { return Setting.Text; }
        }
    }
}
