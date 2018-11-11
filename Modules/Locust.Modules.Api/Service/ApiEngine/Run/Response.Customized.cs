using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
    public partial class ApiEngineRunResponse : BaseServiceResponse<object, ApiEngineRunStatus>
    {
        public bool EncryptedResult { get; set; }
        public string Result { get; set; }
    }
}
