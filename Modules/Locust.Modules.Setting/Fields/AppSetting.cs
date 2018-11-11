using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.ModelField;

namespace Locust.Modules.Setting.Fields.AppSetting
{
    public class AppSettingID : TInt16 { }
    public class SettingSize : TInt32 { }
    public class Encrypted : TBoolean { }
    public class Sensitive : TBoolean { }
    public class SettingDir : TBoolean { }
    public class Key : TString { }
    public class SettingBaseTable : TString { }
    public class Title : TString { }
    public class Value : TString { }
    public class Description : TString { }
    public class SettingValues : TString { }
}
