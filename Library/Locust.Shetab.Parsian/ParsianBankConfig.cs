using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Shetab.Parsian
{
    public class ParsianBankConfig : ShetabBankConfig
    {
        public ParsianBankConfig()
        {
            this.GatewayUrl = ConfigurationManager.AppSettings["BankParsianGateway"];
            this.GatewayMethod = HttpMethod.Get;

            var c = new ShetabBankPinCredentials();
            c.Pin = ConfigurationManager.AppSettings["BankParsianPin"];
            this.Credentials = c;
        }
    }
}
