using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Locust.Shetab.Models;
using Locust.Db;

namespace Locust.Shetab
{
    public interface IPaymentManager
    {
        PaymentManagerConfig Config { get; }
        PaymentManagerBeginPaymentResponse BeginPayment(BeginPaymentRequest request);
        Task<PaymentManagerBeginPaymentResponse> BeginPaymentAsync(BeginPaymentRequest request, CancellationToken cancellation);

        PaymentManagerEndPaymentResponse EndPayment(IDictionary<string, string> request, string paymentCode);
        Task<PaymentManagerEndPaymentResponse> EndPaymentAsync(IDictionary<string, string> request, string paymentCode, CancellationToken cancellation);

        PaymentManagerReversalPaymentResponse ReversalPayment(string bankType, ReversalRequest request);
        Task<PaymentManagerReversalPaymentResponse> ReversalPaymentAsync(string bankType, ReversalRequest request, CancellationToken cancellation);

        Payment GetPayment(string bankType, string paymentCode);
        Task<Payment> GetPaymentAsync(string bankType, string paymentCode, CancellationToken cancellation);
    }
}
