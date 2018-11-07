using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Locust.Conversion;
using Locust.Shetab.ir.shaparak.pec;
using Locust.Shetab.Models;
using Locust.Date;

namespace Locust.Shetab.Ayandeh
{
    public class AyandehPaymentProvider : BaseShetabPaymentProvider
    {
        public AyandehPaymentProvider(AyandehBankConfig config, INow now)
            : base(config, now, "Ayandeh")
        { }
        protected override string BankCodeArgName { get { return "au"; } }
        protected override string BankStatusArgName { get { return "rs"; } }
        protected bool EndPaymentSucceeded(string status)
        {
            return status == "0" || status == "-1";
        }
        protected bool EndPaymentSucceeded(byte status)
        {
            return status == 0;
        }
        public override PaymentProviderBeginPaymentResponse BeginPayment(BeginPaymentRequest request)
        {
            var result = new PaymentProviderBeginPaymentResponse<AyandehBankTranStatus>(Now);
            result.ProviderType = this.ProviderType;

            var pec = new ir.shaparak.pec.EShopService();
            var orderid = SafeClrConvert.ToInt32(request.PaymentCode);
            var pay = SafeClrConvert.ToInt32(request.Amount);
            byte pecStatus = 0;
            long auth = 0;

            pec.PinPaymentRequest(Config.Credentials.Pin, pay, orderid, (string.IsNullOrEmpty(request.ReturnUrl) ? Config.CallbackUrl : request.ReturnUrl), ref auth, ref pecStatus);

            result.Code = auth;
            result.SendData.Add(BankCodeArgName, auth.ToString());
            result.Status = pecStatus;
            result.Succeeded = (pecStatus == 0 && auth != -1);
            result.GatewayUrl = Config.GatewayUrl + $"?{BankCodeArgName}={auth}";
            result.SendMethod = Config.GatewayMethod;
            
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
                var pec = new ir.shaparak.pec.EShopService();

                pec.PinPaymentRequestCompleted += new PinPaymentRequestCompletedEventHandler((sender, args) =>
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
                                var result = new PaymentProviderBeginPaymentResponse<AyandehBankTranStatus>(Now);

                                result.ProviderType = this.ProviderType;
                                result.Code = args.authority;
                                result.SendData.Add(BankCodeArgName, args.authority.ToString());
                                result.Status = args.status;
                                result.Succeeded = (args.status == 0 && args.authority != -1);
                                result.GatewayUrl = Config.GatewayUrl + $"?{BankCodeArgName}={args.authority}";
                                result.SendMethod = Config.GatewayMethod;

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

                var orderid = SafeClrConvert.ToInt32(request.PaymentCode);
                var pay = SafeClrConvert.ToInt32(request.Amount);
                byte pecStatus = 0;
                long auth = 0;

                cancellation.Register(() => pec.CancelAsync(request.PaymentCode));
                
                pec.PinPaymentRequestAsync(Config.Credentials.Pin, pay, orderid, (string.IsNullOrEmpty(request.ReturnUrl) ? Config.CallbackUrl : request.ReturnUrl), auth, pecStatus, request.PaymentCode);
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
                var pec = new ir.shaparak.pec.EShopService();

                pec.PaymentEnquiryCompleted += new PaymentEnquiryCompletedEventHandler((sender, args) =>
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
                                var result = new PaymentProviderEndPaymentResponse<AyandehBankTranStatus>(Now);

                                result.Query = (long)args.UserState;
                                result.Code = args.invoiceNumber;
                                result.Status = args.status;
                                result.Succeeded = (EndPaymentSucceeded(args.status) && result.Query != -1);
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

                string authority = code;
                long auth;
                byte pecStatus = 0;
                long invoice = 0;

                if (!long.TryParse(authority, out auth))
                {
                    var result = new PaymentProviderEndPaymentResponse<AyandehBankTranStatus>();

                    result.Query = auth;
                    result.Status = (int)AyandehBankTranStatus.InvalidBankStep2Code;
                    result.Succeeded = false;
                    result.ProviderType = ProviderType;

                    tcs.SetResult(result);
                }
                else if (!EndPaymentSucceeded(status))
                {
                    var result = new PaymentProviderEndPaymentResponse<AyandehBankTranStatus>();

                    result.Query = auth;
                    result.Status = status;
                    result.Succeeded = false;
                    result.ProviderType = ProviderType;

                    tcs.SetResult(result);
                }
                else
                {
                    cancellation.Register(() => pec.CancelAsync(auth));

                    pec.PaymentEnquiryAsync(Config.Credentials.Pin, auth, pecStatus, invoice, auth);
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
            var result = new PaymentProviderEndPaymentResponse<AyandehBankTranStatus>(Now);
            result.ProviderType = this.ProviderType;

            string authority = code;
            long auth;

            if (!long.TryParse(authority, out auth))
            {
                result.Status = (int)AyandehBankTranStatus.InvalidBankStep2Code;
            }
            else if (!EndPaymentSucceeded(status))
            {
                result.Status = status;
            }
            else
            {
                var pec = new ir.shaparak.pec.EShopService();
                byte pecStatus = 0;
                long invoice = 0;
                
                pec.PaymentEnquiry(Config.Credentials.Pin, auth, ref pecStatus, ref invoice);
                
                result.Query = auth;
                result.Code = invoice;
                result.Status = pecStatus;
                result.Succeeded = (EndPaymentSucceeded(pecStatus) && auth != -1);
            }

            return result;
        }
        public override PaymentProviderReversalPaymentResponse ReversalPayment(ReversalRequest request)
        {
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
        }
        public override Task<PaymentProviderReversalPaymentResponse> ReversalPaymentAsync(ReversalRequest request, CancellationToken cancellation)
        {
            var tcs = new TaskCompletionSource<PaymentProviderReversalPaymentResponse>();

            try
            {
                var pec = new ir.shaparak.pec.EShopService();

                pec.PinReversalCompleted +=new PinReversalCompletedEventHandler((sender, args) =>
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

                    result.Status = (int)AyandehBankTranStatus.InvalidReversalOrder;
                    
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
        }
    }
}
