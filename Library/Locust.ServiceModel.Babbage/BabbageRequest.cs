using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Locust.Base;

namespace Locust.ServiceModel.Babbage
{
    public abstract class BabbageRequest: BaseServiceRequest
    {
        [ScriptIgnore]
        public string Hash { get; set; }

        public virtual string GetHash()
        {
            var result = JsonConvert.SerializeObject(this);

            result = Cryptography.Cryptography.GetMD5(result);

            return result;
        }
    }
}
