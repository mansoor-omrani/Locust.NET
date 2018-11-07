using Locust.WebExtensions;
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
    public static class ShetabPaymentManagerExtensions
    {
        // --------------------------- IPaymentManager Extensions -----------------------
        public static Task<PaymentManagerBeginPaymentResponse> BeginPaymentAsync(this IPaymentManager Manager, BeginPaymentRequest request)
        {
            return Manager.BeginPaymentAsync(request, CancellationToken.None);
        }
        public static PaymentManagerEndPaymentResponse EndPayment(this IPaymentManager Manager, System.Web.HttpRequestBase request, string paymentCode)
        {
            var data = request.ToDictionary(RequestRead.QueryAndForm);

            data.Add("HttpMethod", request.HttpMethod);
            data.Add("Url", request.Url.AbsoluteUri);

            return Manager.EndPayment(data, paymentCode);
        }
        public static PaymentManagerEndPaymentResponse EndPayment(this IPaymentManager Manager, System.Web.HttpRequest request, string paymentCode)
        {
            var req = new HttpRequestWrapper(request);
            
            return Manager.EndPayment(req, paymentCode);
        }
        public static Task<PaymentManagerEndPaymentResponse> EndPaymentAsync(this IPaymentManager Manager, System.Web.HttpRequestBase request, string paymentCode)
        {
            var data = request.ToDictionary(RequestRead.QueryAndForm);

            data.Add("HttpMethod", request.HttpMethod);
            data.Add("Url", request.Url.AbsoluteUri);

            return Manager.EndPaymentAsync(data, paymentCode, CancellationToken.None);
        }
        public static Task<PaymentManagerEndPaymentResponse> EndPaymentAsync(this IPaymentManager Manager, System.Web.HttpRequest request, string paymentCode)
        {
            var req = new HttpRequestWrapper(request);

            return Manager.EndPaymentAsync(req, paymentCode);
        }
        public static Task<PaymentManagerEndPaymentResponse> EndPaymentAsync(this IPaymentManager Manager, IDictionary<string, string> request, string paymentCode)
        {
            return Manager.EndPaymentAsync(request, paymentCode, CancellationToken.None);
        }
        public static Task<PaymentManagerReversalPaymentResponse> ReversalAsync(this IPaymentManager Manager, string bankType, ReversalRequest request)
        {
            return Manager.ReversalPaymentAsync(bankType, request, CancellationToken.None);
        }
        public static Task<PaymentManagerReversalPaymentResponse> ReversalAsync(this IPaymentManager Manager, string bankType, string paymentCode)
        {
            return Manager.ReversalPaymentAsync(bankType, new ReversalRequest { PaymentCode = paymentCode }, CancellationToken.None);
        }
        public static PaymentManagerReversalPaymentResponse Reversal(this IPaymentManager Manager, string bankType, string paymentCode)
        {
            return Manager.ReversalPayment(bankType, new ReversalRequest { PaymentCode = paymentCode });
        }
    }
}
