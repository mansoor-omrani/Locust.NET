using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Conversion;

namespace Locust.Shetab.Saman
{
    public class SamanBankConfig : ShetabBankConfig
    {
        public int MaxFinishPaymentRetry { get; protected set; }
        public SamanBankConfig()
        {
            this.GatewayUrl =  ConfigurationManager.AppSettings["BankSamanGatewayUrl"];
            if (string.IsNullOrEmpty(this.GatewayUrl))
            {
                this.GatewayUrl = "https://sep.shaparak.ir/payment.aspx";
            }
            this.CallbackUrl = ConfigurationManager.AppSettings["BankSamanCallbackUrl"];
            this.GatewayMethod = HttpMethod.Post;
            this.MaxFinishPaymentRetry = SafeClrConvert.ToInt32(ConfigurationManager.AppSettings["BankSamanMaxFinishPaymentRetry"]);

            var c = new ShetabBankUserPassPinCredentials();

            c.Pin = SafeClrConvert.ToString(ConfigurationManager.AppSettings["BankSamanMerchantID"]);
            c.Username = c.Pin;
            c.Password = SafeClrConvert.ToString(ConfigurationManager.AppSettings["BankSamanMerchantPass"]);

            this.Credentials = c;
        }
    }
}
