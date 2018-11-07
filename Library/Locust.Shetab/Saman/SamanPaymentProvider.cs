using Locust.Conversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Locust.Shetab.ir.shaparak.pec;
using System.Threading;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using Locust.Shetab.ir.shaparak.sep;
using Locust.Shetab.Models;
using Locust.Date;

namespace Locust.Shetab.Saman
{
    public class SamanPaymentProvider : BaseShetabPaymentProvider
    {
        public SamanPaymentProvider(SamanBankConfig config, INow now)
            : base(config, now, "Saman")
        { }
        protected override string BankCodeArgName { get { return "RefNum"; } }
        protected override string BankStatusArgName { get { return "State"; } }
        protected bool EndPaymentSucceeded(string status)
        {
            return string.Compare(status, "ok", StringComparison.OrdinalIgnoreCase) == 0;
        }
        protected bool EndPaymentSucceeded(int status)
        {
            return status > 0;
        }
        public override PaymentProviderBeginPaymentResponse BeginPayment(BeginPaymentRequest request)
        {
            var result = new PaymentProviderBeginPaymentResponse<SamanBankTranStatus>(Now);

            result.ProviderType = this.ProviderType;
            result.Code = 0; // auth;
            //result.SendData.Add("sam", "lcc");
            result.SendData.Add("Amount", request.Amount.ToString());
            result.SendData.Add("MID", Config.Credentials.Pin);
            result.SendData.Add("ResNum", request.PaymentCode);
            result.SendData.Add("RedirectURL", string.IsNullOrEmpty(request.ReturnUrl)? Config.CallbackUrl: request.ReturnUrl);
            result.Status = 0;
            result.Succeeded = true;
            result.GatewayUrl = Config.GatewayUrl;
            result.SendMethod = Config.GatewayMethod;
            
            return result;
        }
        public override bool CanEnd(IDictionary<string, string> request)
        {
            var rn = GetEndPaymentQuery(request);

            return CanEnd(request["Url"]) && !string.IsNullOrEmpty(rn) && string.Compare(request["HttpMethod"], "post", StringComparison.OrdinalIgnoreCase) == 0;
        }
        public override Task<PaymentProviderBeginPaymentResponse> BeginPaymentAsync(BeginPaymentRequest request, System.Threading.CancellationToken cancellation)
        {
            var result = BeginPayment(request);

            return Task.FromResult(result);
        }
        protected override Task<PaymentProviderEndPaymentResponse> endPaymentAsync(IDictionary<string, string> request, string code, string status, CancellationToken cancellation)
        {
            var tcs = new TaskCompletionSource<PaymentProviderEndPaymentResponse>();
            var refnum = code;

            try
            {
                ServicePointManager.ServerCertificateValidationCallback =
                            delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                var eservice = new ir.shaparak.sep.PaymentIFBinding();

                eservice.verifyTransactionCompleted += new verifyTransactionCompletedEventHandler((sender, args) =>
                {
                    if (args.Error != null)
                    {
                        tcs.TrySetException(args.Error);
                    }
                    else
                        if (!args.Cancelled)
                        {
                            try
                            {
                                var result = new PaymentProviderEndPaymentResponse<SamanBankTranStatus>(Now);
                                var config = Config as SamanBankConfig;
                                var r = 0.0;

                                for (var i = 0; i < config.MaxFinishPaymentRetry; i++)
                                {
                                    r = eservice.verifyTransaction(refnum, Config.Credentials.Pin);
                                    var ri = SafeClrConvert.ToInt32(r);

                                    if (ri != 0)
                                    {
                                        result.Succeeded = EndPaymentSucceeded(ri);
                                        break;
                                    }
                                }

                                result.Query = code;
                                result.Code = "";
                                result.Status = r;
                                result.ProviderType = this.ProviderType;

                                tcs.SetResult(result);
                            }
                            catch (Exception ex)
                            {
                                tcs.TrySetException(ex);
                            }
                        }
                        else
                        {
                            tcs.SetCanceled();
                        }

                    eservice.Dispose();
                });

                if (string.IsNullOrEmpty(refnum) || !EndPaymentSucceeded(status))
                {
                    var result = new PaymentProviderEndPaymentResponse<SamanBankTranStatus>();
                    result.ProviderType = this.ProviderType;
                    result.Status = status;

                    SamanBankTranStatus strongStatus;

                    if (Enum.TryParse<SamanBankTranStatus>(status.Replace(" ", ""), out strongStatus))
                    {
                        result.StrongStatus = strongStatus;
                    }

                    tcs.SetResult(result);
                }
                else
                {
                    cancellation.Register(() => eservice.CancelAsync(refnum));

                    eservice.verifyTransactionAsync(refnum, Config.Credentials.Pin, refnum);
                }
            }
            catch (Exception e)
            {
                tcs.SetException(e);
            }

            return tcs.Task;
        }
        protected override PaymentProviderEndPaymentResponse endPayment(IDictionary<string, string> request, string code, string status)
        {
            var result = new PaymentProviderEndPaymentResponse<SamanBankTranStatus>(Now);
            var refnum = code;

            result.ProviderType = this.ProviderType;

            if (string.IsNullOrEmpty(refnum) || !EndPaymentSucceeded(status))
            {
                result.Status = status;
                SamanBankTranStatus strongStatus;
                if (Enum.TryParse<SamanBankTranStatus>(status.Replace(" ", ""), out strongStatus))
                {
                    result.StrongStatus = strongStatus;
                }
            }
            else
            {
                ServicePointManager.ServerCertificateValidationCallback =
                            delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };

                var eservice = new ir.shaparak.sep.PaymentIFBinding();
                var config = Config as SamanBankConfig;
                var r = 0.0;

                for (var i = 0; i < config.MaxFinishPaymentRetry; i++)
                {
                    r = eservice.verifyTransaction(refnum, Config.Credentials.Pin);
                    var ri = SafeClrConvert.ToInt32(r);

                    if (ri != 0)
                    {
                        result.Succeeded = EndPaymentSucceeded(ri);
                        break;
                    }
                }

                result.Query = code;
                result.Code = "";
                result.Status = r;
                
            }

            return result;
        }
        public override PaymentProviderReversalPaymentResponse ReversalPayment(ReversalRequest request)
        {
            var result = new PaymentProviderReversalPaymentResponse(Now);
            result.ProviderType = this.ProviderType;

            var eservice = new ir.shaparak.sep.PaymentIFBinding();
            var r = eservice.reverseTransaction(request.PaymentCode, Config.Credentials.Pin, Config.Credentials.Username, Config.Credentials.Password);

            result.Status = 0;
            result.Succeeded = (r == 1);

            return result;
        }
        public override Task<PaymentProviderReversalPaymentResponse> ReversalPaymentAsync(ReversalRequest request, CancellationToken cancellation)
        {
            var tcs = new TaskCompletionSource<PaymentProviderReversalPaymentResponse>();

            try
            {
                var pec = new ir.shaparak.sep.PaymentIFBinding();

                pec.reverseTransactionCompleted +=new reverseTransactionCompletedEventHandler((sender, args) =>
                {
                    if (args.Error != null)
                    {
                        tcs.TrySetException(args.Error);
                    }
                    else
                        if (!args.Cancelled)
                        {
                            try
                            {
                                var result = new PaymentProviderReversalPaymentResponse(Now);

                                result.Status = 0;
                                result.Succeeded = (args.Result == 1);
                                result.ProviderType = this.ProviderType;

                                tcs.SetResult(result);
                            }
                            catch (Exception ex)
                            {
                                tcs.TrySetException(ex);
                            }
                            
                        }
                        else
                        {
                            tcs.SetCanceled();
                        }

                    pec.Dispose();
                });

                cancellation.Register(() => pec.CancelAsync(request.PaymentCode));

                pec.reverseTransactionAsync(request.PaymentCode, Config.Credentials.Pin, Config.Credentials.Username, Config.Credentials.Password, request.PaymentCode);
            }
            catch (Exception e)
            {
                tcs.SetException(e);
            }

            return tcs.Task;
        }
    }
}
