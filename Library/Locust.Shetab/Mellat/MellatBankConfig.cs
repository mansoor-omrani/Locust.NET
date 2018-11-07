using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Shetab.Mellat
{
    public class MellatBankConfig : ShetabBankConfig
    {
        public MellatBankConfig()
        {
            this.GatewayUrl = ConfigurationManager.AppSettings["BankMellatGateway"];
            this.GatewayMethod = HttpMethod.Post;

            var c = new ShetabBankUserPassPinCredentials();

            c.Pin = ConfigurationManager.AppSettings["BankMellatPin"];
            c.Username = ConfigurationManager.AppSettings["BankMellatUser"];
            c.Password = ConfigurationManager.AppSettings["BankMellatPass"];

            this.Credentials = c;
        }
    }
}
