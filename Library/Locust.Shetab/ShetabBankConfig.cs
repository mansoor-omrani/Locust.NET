using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Shetab
{
    public class ShetabBankUserPassCredentials
    {
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
    }
    public class ShetabBankUserPassPinCredentials
    {
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual string Pin { get; set; }
    }
    public class ShetabBankPinCredentials
    {
        public virtual string Pin { get; set; }
    }
    public class ShetabBankMerchantIdCredentials
    {
        public virtual string MerchantId { get; set; }
    }
    public class ShetabBankConfig
    {
        public HttpMethod GatewayMethod { get; set; }
        public virtual string GatewayUrl { get; set; }
        public virtual string CallbackUrl { get; set; }
        public virtual dynamic Credentials { get; set; }
    }
    
}
