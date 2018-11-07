using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Shetab.ZarinPal
{
    public class ZarinPalBankConfig : ShetabBankConfig
    {
        public ZarinPalBankConfig()
        {
            this.GatewayUrl = ConfigurationManager.AppSettings["BankZarinPalGateway"];
            if (string.IsNullOrEmpty(GatewayUrl))
            {
                GatewayUrl = "https://www.zarinpal.com/pg/StartPay";
            }

            this.GatewayMethod = HttpMethod.Get;

            var c = new ShetabBankMerchantIdCredentials();
            c.MerchantId = ConfigurationManager.AppSettings["BankZarinPalMerchantId"];
            this.Credentials = c;
        }
    }
}
