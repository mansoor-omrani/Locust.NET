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
    public static class ShetabPaymentProviderExtensions
    {
        // --------------------------- IPaymentProvider Extensions -----------------------
        public static Task<PaymentProviderBeginPaymentResponse> BeginPaymentAsync(this IPaymentProvider provider, BeginPaymentRequest request)
        {
            return provider.BeginPaymentAsync(request, CancellationToken.None);
        }
        public static PaymentProviderEndPaymentResponse EndPayment(this IPaymentProvider provider, System.Web.HttpRequestBase request)
        {
            var data = request.ToDictionary(RequestRead.QueryAndForm);

            data.Add("HttpMethod", request.HttpMethod);
            data.Add("Url", request.Url.AbsoluteUri);

            return provider.EndPayment(data);
        }
        public static PaymentProviderEndPaymentResponse EndPayment(this IPaymentProvider provider, System.Web.HttpRequest request)
        {
            var req = new HttpRequestWrapper(request);
            
            return provider.EndPayment(req);
        }
        public static Task<PaymentProviderEndPaymentResponse> EndPaymentAsync(this IPaymentProvider provider, System.Web.HttpRequestBase request)
        {
            var data = request.ToDictionary(RequestRead.QueryAndForm);

            data.Add("HttpMethod", request.HttpMethod);
            data.Add("Url", request.Url.AbsoluteUri);

            return provider.EndPaymentAsync(data, CancellationToken.None);
        }
        public static Task<PaymentProviderEndPaymentResponse> EndPaymentAsync(this IPaymentProvider provider, System.Web.HttpRequest request)
        {
            var req = new HttpRequestWrapper(request);

            return provider.EndPaymentAsync(req);
        }
        public static Task<PaymentProviderEndPaymentResponse> EndPaymentAsync(this IPaymentProvider provider, IDictionary<string, string> request)
        {
            return provider.EndPaymentAsync(request, CancellationToken.None);
        }
        public static Task<PaymentProviderReversalPaymentResponse> ReversalAsync(this IPaymentProvider provider, ReversalRequest request)
        {
            return provider.ReversalPaymentAsync(request, CancellationToken.None);
        }
        public static Task<PaymentProviderReversalPaymentResponse> ReversalAsync(this IPaymentProvider provider, string paymentCode)
        {
            return provider.ReversalPaymentAsync(new ReversalRequest { PaymentCode = paymentCode }, CancellationToken.None);
        }
        public static PaymentProviderReversalPaymentResponse Reversal(this IPaymentProvider provider, string paymentCode)
        {
            return provider.ReversalPayment(new ReversalRequest { PaymentCode = paymentCode });
        }
        public static string GetEndPaymentCode(this IPaymentProvider provider, System.Web.HttpRequestBase request)
        {
            var data = request.ToDictionary(RequestRead.QueryAndForm);

            return provider.GetEndPaymentQuery(data);
        }
        public static string GetEndPaymentCode(this IPaymentProvider provider, System.Web.HttpRequest request)
        {
            var req = new HttpRequestWrapper(request);
            
            return provider.GetEndPaymentCode(req);
        }
        public static bool CanEnd(this IPaymentProvider provider, System.Web.HttpRequestBase request)
        {
            var data = request.ToDictionary(RequestRead.QueryAndForm);

            data.Add("HttpMethod", request.HttpMethod);
            data.Add("Url", request.Url.AbsoluteUri);
            
            return provider.CanEnd(data);
        }
        public static bool CanEnd(this IPaymentProvider provider, System.Web.HttpRequest request)
        {
            var req = new HttpRequestWrapper(request);
            
            return provider.CanEnd(req);
        }
    }
}
