using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.ModelField;

namespace Locust.Modules.Api.Fields.ServiceSetting
{
    public class ServiceSettingId : TInt32 { }
    public class Service : TString { }
    public class Key : TString { }
    public class Value : TString { }
}
