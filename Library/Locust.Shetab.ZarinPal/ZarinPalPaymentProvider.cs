using Locust.Conversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Threading;
using Locust.Date;
using Locust.Shetab.Models;
using Locust.Shetab.ZarinPal.com.zarinpal.www;
using Locust.Extensions;

namespace Locust.Shetab.ZarinPal
{
    public class ZarinPalPaymentProvider : BaseShetabPaymentProvider
    {
        public ZarinPalPaymentProvider(ZarinPalBankConfig config, INow now)
            : base(config, now, "ZarinPal")
        { }
        protected override string BankCodeArgName { get { return "RefId"; } }
        protected override string BankStatusArgName { get { return "Status"; } }
        protected bool EndPaymentSucceeded(string status)
        {
            return status == "OK";
        }
        public override PaymentProviderBeginPaymentResponse BeginPayment(BeginPaymentRequest request)
        {
            var result = new PaymentProviderBeginPaymentResponse<ZarinPalBankTranStatus>(Now);
            result.ProviderType = this.ProviderType;

            var service = new com.zarinpal.www.PaymentGatewayImplementationService();
            var amount = SafeClrConvert.ToInt32(request.Amount);
            string auth = "";

            var status = service.PaymentRequest(Config.Credentials.MerchantId, amount, request.Info, "", "", (string.IsNullOrEmpty(request.ReturnUrl) ? Config.CallbackUrl : request.ReturnUrl), out auth);
            
            result.Code = SafeClrConvert.ToLong(auth);
            result.Status = status;
            result.Succeeded = status == 100;
            result.GatewayUrl = Config.GatewayUrl + $"/{result.Code}";
            result.SendMethod = Config.GatewayMethod;
            result.StrongStatus = ((int)status).ToEnum<ZarinPalBankTranStatus>();

            return result;
        }
        public override bool CanEnd(IDictionary<string, string> request)
        {
            var au = GetEndPaymentQuery(request);

            return CanEnd(request["Url"]) && !string.IsNullOrEmpty(au);
        }
        public override Task<PaymentProviderBeginPaymentResponse> BeginPaymentAsync(BeginPaymentRequest request, System.Threading.CancellationToken cancellation)
        {
            var tcs = new TaskCompletionSource<PaymentProviderBeginPaymentResponse>();

            try
            {
                var service = new com.zarinpal.www.PaymentGatewayImplementationService();

                service.PaymentRequestCompleted +=  new PaymentRequestCompletedEventHandler((object sender, PaymentRequestCompletedEventArgs args) =>
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
                            var result = new PaymentProviderBeginPaymentResponse<ZarinPalBankTranStatus>(Now);
                            result.ProviderType = this.ProviderType;
                            result.Code = SafeClrConvert.ToLong(args.Authority);
                            result.Status = args.Result;
                            result.Succeeded = (args.Result == 100);
                            result.GatewayUrl = Config.GatewayUrl + $"/{result.Code}";
                            result.SendMethod = Config.GatewayMethod;
                            result.StrongStatus = args.Result.ToEnum<ZarinPalBankTranStatus>();

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

                    service.Dispose();
                });

                var amount = SafeClrConvert.ToInt32(request.Amount);
                
                cancellation.Register(() => service.CancelAsync(request.PaymentCode));

                service.PaymentRequestAsync(Config.Credentials.MerchantId, amount, request.Info, "", "", (string.IsNullOrEmpty(request.ReturnUrl) ? Config.CallbackUrl : request.ReturnUrl));
            }
            catch (Exception e)
            {
                tcs.SetException(e);
            }

            return tcs.Task;
        }

        protected override Task<PaymentProviderEndPaymentResponse> endPaymentAsync(IDictionary<string, string> request, string code, string status, CancellationToken cancellation)
        {
            var tcs = new TaskCompletionSource<PaymentProviderEndPaymentResponse>();

            try
            {
                var service = new com.zarinpal.www.PaymentGatewayImplementationService();

                service.PaymentVerificationCompleted += new PaymentVerificationCompletedEventHandler((object sender, PaymentVerificationCompletedEventArgs args) =>
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
                            var result = new PaymentProviderEndPaymentResponse<ZarinPalBankTranStatus>(Now);
                            
                            result.Query = code;
                            result.Code = args.RefID;
                            result.Status = args.Result;
                            result.Succeeded = result.Status.ToString() == "100";
                            result.StrongStatus = args.Result.ToEnum<ZarinPalBankTranStatus>();
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

                    service.Dispose();
                });

                var authority = code;
                var amount = SafeClrConvert.ToInt32(request["Amount"]);

                if (!EndPaymentSucceeded(status))
                {
                    var result = new PaymentProviderEndPaymentResponse<ZarinPalBankTranStatus>();

                    result.Query = authority;
                    result.Status = status;
                    result.Succeeded = false;
                    result.ProviderType = this.ProviderType;

                    tcs.SetResult(result);
                }
                else
                {
                    cancellation.Register(() => service.CancelAsync(authority));

                    service.PaymentVerificationAsync(Config.Credentials.MerchantId, authority, amount, authority);
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
            var result = new PaymentProviderEndPaymentResponse<ZarinPalBankTranStatus>(Now);
            var _status = SafeClrConvert.ToInt32(status);

            result.ProviderType = this.ProviderType;
            result.StrongStatus = _status.ToEnum<ZarinPalBankTranStatus>();

            string authority = code;
            
            if (!EndPaymentSucceeded(status))
            {
                result.Status = status;
            }
            else
            {
                var service = new com.zarinpal.www.PaymentGatewayImplementationService();
                long refId = 0;
                var amount = SafeClrConvert.ToInt32(request["Amount"]);
                _status = service.PaymentVerification(Config.Credentials.MerchantId, authority, amount, out refId);

                result.Query = authority;
                result.Code = refId;
                result.StrongStatus = _status.ToEnum<ZarinPalBankTranStatus>();
                result.Status = _status.ToString();
                result.Succeeded = _status == 100;
            }

            return result;
        }
        public override PaymentProviderReversalPaymentResponse ReversalPayment(ReversalRequest request)
        {
            /*
            var result = new PaymentProviderReversalPaymentResponse(Now);
            result.ProviderType = this.ProviderType;

            int orderid;

            if (!int.TryParse(request.PaymentCode, out orderid))
            {
                var pec = new ir.shaparak.pec.EShopService();
                byte pecStatus = 0;

                pec.PinReversal(Config.Credentials.Pin, orderid, orderid, ref pecStatus);

                result.Status = pecStatus;
                result.Succeeded = (pecStatus == 0);
            }

            return result;
            */
            throw new NotImplementedException();
        }
        public override Task<PaymentProviderReversalPaymentResponse> ReversalPaymentAsync(ReversalRequest request, CancellationToken cancellation)
        {
            /*
            var tcs = new TaskCompletionSource<PaymentProviderReversalPaymentResponse>();

            try
            {
                var pec = new ir.shaparak.pec.EShopService();

                pec.PinReversalCompleted += new PinReversalCompletedEventHandler((sender, args) =>
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

                            result.Status = args.status;
                            result.Succeeded = (args.status == 0);
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

                byte pecStatus = 0;
                int orderid = 0;

                if (!int.TryParse(request.PaymentCode, out orderid))
                {
                    var result = new PaymentProviderReversalPaymentResponse();

                    result.Status = (int)ZarinPalBankTranStatus.InvalidReversalOrder;

                    tcs.SetResult(result);
                }
                else
                {
                    cancellation.Register(() => pec.CancelAsync(request.PaymentCode));

                    pec.PinReversalAsync(Config.Credentials.Pin, orderid, orderid, pecStatus, request.PaymentCode);
                }
            }
            catch (Exception e)
            {
                tcs.SetException(e);
            }

            return tcs.Task;
            */

            throw new NotImplementedException();
        }
    }
}
