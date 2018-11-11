using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.ModelField;

namespace Locust.Modules.Api.Fields.Api
{

    public class ApiId : TInt32 { }
    public class Enabled : TBoolean { }
    public class Service : TString { }
    public class Strategy : TString { }
    public class EncryptResponse : TBoolean { }
    public class Async : TBoolean { }
    public class RequiresEncryptedRequest : TBoolean { }
    public class AllowExpiredAccessToken : TBoolean { }
    public class CompressedRequest : TBoolean { }
    public class CompressedResponse : TBoolean { }
    public class Path : TString { }
    public class ApiPath : TString { }
    public class UseArrayForJsonSerialization : TBoolean { }
    public class Namespace : TString { }
    public class Version : TString { }
}
