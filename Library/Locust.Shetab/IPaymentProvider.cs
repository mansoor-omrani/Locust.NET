using Locust.Shetab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Locust.Shetab
{
    public interface IPaymentProvider
    {
        bool CanEnd(IDictionary<string, string> request);
        string ProviderType { get; }

        PaymentProviderBeginPaymentResponse BeginPayment(BeginPaymentRequest request);
        Task<PaymentProviderBeginPaymentResponse> BeginPaymentAsync(BeginPaymentRequest request, CancellationToken cancellation);

        PaymentProviderEndPaymentResponse EndPayment(IDictionary<string, string> request);
        Task<PaymentProviderEndPaymentResponse> EndPaymentAsync(IDictionary<string, string> request, CancellationToken cancellation);
        
        PaymentProviderReversalPaymentResponse ReversalPayment(ReversalRequest request);
        Task<PaymentProviderReversalPaymentResponse> ReversalPaymentAsync(ReversalRequest request, CancellationToken cancellation);

        string GetEndPaymentQuery(IDictionary<string, string> request);
    }
}
