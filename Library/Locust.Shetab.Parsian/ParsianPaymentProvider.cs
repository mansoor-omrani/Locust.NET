using Locust.Conversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Locust.Shetab.ir.shaparak.pec;
using System.Threading;

namespace Locust.Shetab.Parsian
{
    public class ParsianPaymentProvider : BaseShetabPaymentProvider
    {
        public override BankType BankType { get; protected set; }
        public ParsianPaymentProvider(ParsianBankConfig config)
            : base(config, BankType.Parsian)
        { }
        protected bool PaymentSucceeded(string status)
        {
            return status == "0";
        }
        protected bool PaymentStep2Succeeded(byte status)
        {
            return status == 0;
        }
        public override ShetabPaymentStep1 BeginPayment(string paymentcode, decimal amount, string returnUrl)
        {
            var result = new ShetabPaymentStep1<ParsianBankTranStatus>();
            result.BankType = this.BankType;

            var pec = new ir.shaparak.pec.EShopService();
            var orderid = SafeClrConvert.ToInt32(paymentcode);
            var pay = SafeClrConvert.ToInt32(amount);
            byte pecStatus = 0;
            long auth = 0;

            pec.PinPaymentRequest(Config.Credentials.Pin, pay, orderid, returnUrl, ref auth, ref pecStatus);

            result.Code = auth;
            result.SendData.Add("au", auth.ToString());
            result.Status = pecStatus;
            result.Succeeded = (pecStatus == 0 && auth != -1);
            result.GatewayUrl = Config.GatewayUrl + "?au=" + auth.ToString();
            result.SendMethod = Config.GatewayMethod;
            
            return result;
        }
        public override ShetabPaymentStep2 EndPayment(HttpRequestBase request)
        {
            //var au = request["au"];
            var au = GetBankCode(request);

            return endPayment(au, request["rs"]);
        }
        public override bool CanEnd(HttpRequestBase request)
        {
            var au = GetBankCode(request);

            return !string.IsNullOrEmpty(au);
        }
        public override bool CanEnd(IDictionary<string, string> request)
        {
            //if (request.ContainsKey("au"))
            //{
            //    return request["au"] != null;
            //}
            //else
            //{
            //    return false;
            //}
            var au = GetBankCode(request);

            return !string.IsNullOrEmpty(au);
        }
        public override Task<ShetabPaymentStep1> BeginPaymentAsync(string paymentcode, decimal amount, string returnUrl)
        {
            return BeginPaymentAsync(paymentcode, amount, returnUrl, CancellationToken.None);
        }

        public override Task<ShetabPaymentStep1> BeginPaymentAsync(string paymentcode, decimal amount, string returnUrl, System.Threading.CancellationToken cancellation)
        {
            var tcs = new TaskCompletionSource<ShetabPaymentStep1>();

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
                                var result = new ShetabPaymentStep1<ParsianBankTranStatus>();
                                result.BankType = this.BankType;
                                result.Code = args.authority;
                                result.SendData.Add("au", args.authority.ToString());
                                result.Status = args.status;
                                result.Succeeded = (args.status == 0 && args.authority != -1);
                                result.GatewayUrl = Config.GatewayUrl + "?au=" + args.authority.ToString();
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

                var orderid = SafeClrConvert.ToInt32(paymentcode);
                var pay = SafeClrConvert.ToInt32(amount);
                byte pecStatus = 0;
                long auth = 0;

                cancellation.Register(() => pec.CancelAsync(paymentcode));
                
                pec.PinPaymentRequestAsync(Config.Credentials.Pin, pay, orderid, returnUrl, auth, pecStatus, paymentcode);
            }
            catch (Exception e)
            {
                tcs.SetException(e);
            }

            return tcs.Task;
        }

        public override Task<ShetabPaymentStep2> EndPaymentAsync(HttpRequestBase request)
        {
            return EndPaymentAsync(request, CancellationToken.None);
        }

        public override Task<ShetabPaymentStep2> EndPaymentAsync(HttpRequestBase request, System.Threading.CancellationToken cancellation)
        {
            var au = GetBankCode(request);  // request["au"]

            return endPaymentAsync(au, request["rs"], cancellation);
        }

        protected virtual Task<ShetabPaymentStep2> endPaymentAsync(string code, string status, CancellationToken cancellation)
        {
            var tcs = new TaskCompletionSource<ShetabPaymentStep2>();

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
                                var result = new ShetabPaymentStep2<ParsianBankTranStatus>();

                                result.Query = (long)args.UserState;
                                result.Code = args.invoiceNumber;
                                result.Status = args.status;
                                result.Succeeded = (PaymentStep2Succeeded(args.status) && result.Query != -1);
                                result.BankType = this.BankType;

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
                    var result = new ShetabPaymentStep2<ParsianBankTranStatus>();

                    result.Query = auth;
                    result.Status = (int)ParsianBankTranStatus.InvalidBankStep2Code;
                    result.Succeeded = false;
                    result.BankType = this.BankType;

                    tcs.SetResult(result);
                }
                else if (!PaymentSucceeded(status))
                {
                    var result = new ShetabPaymentStep2<ParsianBankTranStatus>();

                    result.Query = auth;
                    result.Status = status;
                    result.Succeeded = false;
                    result.BankType = this.BankType;

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
        protected virtual ShetabPaymentStep2 endPayment(string code, string status)
        {
            var result = new ShetabPaymentStep2<ParsianBankTranStatus>();
            result.BankType = this.BankType;

            string authority = code;
            long auth;

            if (!long.TryParse(authority, out auth))
            {
                result.Status = (int)ParsianBankTranStatus.InvalidBankStep2Code;
            }
            else if (!PaymentSucceeded(status))
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
                result.Succeeded = (PaymentStep2Succeeded(pecStatus) && auth != -1);
            }

            return result;
        }
        public override ShetabPaymentStep2 EndPayment(string code, string status)
        {
            return endPayment(code, status);
        }

        public override Task<ShetabPaymentStep2> EndPaymentAsync(string code, string status)
        {
            return endPaymentAsync(code, status, CancellationToken.None);
        }

        public override Task<ShetabPaymentStep2> EndPaymentAsync(string code, string status, CancellationToken cancellation)
        {
            return endPaymentAsync(code, status, cancellation);
        }

        public override ShetabPaymentReversal Reversal(string paymentCode)
        {
            var result = new ShetabPaymentReversal();
            result.BankType = this.BankType;

            int orderid;

            if (!int.TryParse(paymentCode, out orderid))
            {
                var pec = new ir.shaparak.pec.EShopService();
                byte pecStatus = 0;
                
                pec.PinReversal(Config.Credentials.Pin, orderid, orderid, ref pecStatus);

                result.Status = pecStatus;
                result.Succeeded = (pecStatus == 0);
            }

            return result;
        }

        public override Task<ShetabPaymentReversal> ReversalAsync(string paymentCode)
        {
            return ReversalAsync(paymentCode, CancellationToken.None);
        }
        public override Task<ShetabPaymentReversal> ReversalAsync(string paymentCode, CancellationToken cancellation)
        {
            var tcs = new TaskCompletionSource<ShetabPaymentReversal>();

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
                                var result = new ShetabPaymentReversal();

                                result.Status = args.status;
                                result.Succeeded = (args.status == 0);
                                result.BankType = this.BankType;

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

                if (!int.TryParse(paymentCode, out orderid))
                {
                    var result = new ShetabPaymentReversal();

                    result.Status = (int)ParsianBankTranStatus.InvalidReversalOrder;
                    
                    tcs.SetResult(result);
                }
                else
                {
                    cancellation.Register(() => pec.CancelAsync(paymentCode));

                    pec.PinReversalAsync(Config.Credentials.Pin, orderid, orderid, pecStatus, paymentCode);
                }
            }
            catch (Exception e)
            {
                tcs.SetException(e);
            }

            return tcs.Task;
        }

        public override ShetabPaymentStep2 EndPayment(IDictionary<string, string> request)
        {
            var au = GetBankCode(request);
            var rs = "";

            //if (request.ContainsKey("au"))
            //    au = request["au"];
            if (request.ContainsKey("rs"))
                rs = request["rs"];

            return endPayment(au, rs);
        }

        public override Task<ShetabPaymentStep2> EndPaymentAsync(IDictionary<string, string> request)
        {
            return EndPaymentAsync(request, CancellationToken.None);
        }

        public override Task<ShetabPaymentStep2> EndPaymentAsync(IDictionary<string, string> request, System.Threading.CancellationToken cancellation)
        {
            var au = GetBankCode(request);
            var rs = "";

            //if (request.ContainsKey("au"))
            //    au = request["au"];
            if (request.ContainsKey("rs"))
                rs = request["rs"];

            return endPaymentAsync(au, rs, cancellation);
        }

        public override string GetBankCode(HttpRequestBase request)
        {
            return request["au"];
        }

        public override string GetBankCode(IDictionary<string, string> request)
        {
            var au = "";

            if (request.ContainsKey("au"))
                au = request["au"];

            return au;
        }
    }
}
