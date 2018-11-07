using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Shetab.Ayandeh
{
    public class AyandehBankConfig : ShetabBankConfig
    {
        public AyandehBankConfig()
        {
            this.GatewayUrl = ConfigurationManager.AppSettings["BankAyandehGateway"];
            if (string.IsNullOrEmpty(this.GatewayUrl))
            {
                this.GatewayUrl = "https://pec.shaparak.ir/pecpaymentgateway";
            }
            this.CallbackUrl = ConfigurationManager.AppSettings["BankAyandehCallbackUrl"];
            this.GatewayMethod = HttpMethod.Get;

            var c = new ShetabBankPinCredentials();
            c.Pin = ConfigurationManager.AppSettings["BankAyandehPin"];
            this.Credentials = c;
        }
    }
}
