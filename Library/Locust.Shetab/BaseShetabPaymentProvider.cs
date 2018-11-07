using Locust.Date;
using Locust.Shetab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Locust.Shetab
{
    public abstract class BaseShetabPaymentProvider: IPaymentProvider
    {
        protected ShetabBankConfig _config;
        public ShetabBankConfig Config
        {
            get { return _config; }
        }
        public INow Now { get; set; }
        protected abstract string BankCodeArgName { get; }
        protected abstract string BankStatusArgName { get; }
        protected BaseShetabPaymentProvider(ShetabBankConfig config, INow now, string type)
        {
            this._config = config;
            this.ProviderType = type;
            Now = now;
        }
        public string ProviderType
        {
            get; private set;
        }
        protected bool CanEnd(string givenUrl)
        {
            var uri1 = new Uri(givenUrl).AbsoluteUri;
            var uri2 = new Uri(Config.CallbackUrl).AbsoluteUri;
            var i = 0;

            i = uri1.IndexOf('?');
            if (i == -1)
                i = uri1.IndexOf('#');
            if (i == -1)
                i = uri1.Length;
            uri1 = uri1.Substring(0, i).TrimEnd('/');

            i = uri2.IndexOf('?');
            if (i == -1)
                i = uri2.IndexOf('#');
            if (i == -1)
                i = uri2.Length;
            uri2 = uri2.Substring(0, i).TrimEnd('/');

            return string.Compare(uri1, uri2, true) == 0;
        }
        public abstract PaymentProviderBeginPaymentResponse BeginPayment(BeginPaymentRequest request);
        public abstract Task<PaymentProviderBeginPaymentResponse> BeginPaymentAsync(BeginPaymentRequest request, System.Threading.CancellationToken cancellation);

        public abstract bool CanEnd(IDictionary<string, string> request);

        public abstract PaymentProviderReversalPaymentResponse ReversalPayment(ReversalRequest request);
        public abstract Task<PaymentProviderReversalPaymentResponse> ReversalPaymentAsync(ReversalRequest request, System.Threading.CancellationToken cancellation);
        protected abstract PaymentProviderEndPaymentResponse endPayment(IDictionary<string, string> request, string code, string status);
        protected abstract Task<PaymentProviderEndPaymentResponse> endPaymentAsync(IDictionary<string, string> request, string code, string status, CancellationToken cancellation);
        public virtual PaymentProviderEndPaymentResponse EndPayment(IDictionary<string, string> request)
        {
            var au = GetEndPaymentQuery(request);
            var rs = "";

            if (request.ContainsKey(BankStatusArgName))
                rs = request[BankStatusArgName];

            return endPayment(request, au, rs);
        }
        public virtual Task<PaymentProviderEndPaymentResponse> EndPaymentAsync(IDictionary<string, string> request, System.Threading.CancellationToken cancellation)
        {
            var au = GetEndPaymentQuery(request);
            var rs = "";

            if (request.ContainsKey(BankStatusArgName))
                rs = request[BankStatusArgName];

            return endPaymentAsync(request, au, rs, cancellation);
        }
        public virtual string GetEndPaymentQuery(IDictionary<string, string> request)
        {
            var au = "";

            if (request.ContainsKey(BankCodeArgName))
                au = request[BankCodeArgName];

            return au;
        }
    }
}
