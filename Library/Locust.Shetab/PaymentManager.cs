using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Services.Description;
using Locust.Base;
using Locust.Conversion;
using Locust.Data;
using Locust.Db;
using Locust.Extensions;
using Locust.Shetab.Models;
using Locust.Logging;

namespace Locust.Shetab
{
    public enum PaymentCheckResult
    {
        None = 0,
        NoPaymentCode = 1,
        NoBankCode = 2,
        PaymentCodeNotFound = 3,
        BankCodeMismatch = 4,
        ProblematicBankCode = 5,    // bank code equals '0'
        Matched = 6,
        DbError = 7
    }
    public class PaymentManager: IPaymentManager
    {
        protected IDbHelper _db;
        protected IPaymentProviderFactory _providerFactory;
        //protected static readonly string paymentCookie = "_pc";
        //public static string CookieName
        //{
        //    get { return paymentCookie; }
        //}
        public PaymentManager(PaymentManagerConfig config, IPaymentProviderFactory providerFactory, IDbHelper db, ILogger logger)
        {
            _providerFactory = providerFactory;
            _db = db;
            Config = config;
            Logger = logger;
        }
        public PaymentManagerConfig Config { get; set; }
        public ILogger Logger { get; set; }
        private PaymentManagerBeginPaymentResponse SaveBeginPayment(BeginPaymentRequest request, PaymentProviderBeginPaymentResponse providerResponse)
        {
            var result = new PaymentManagerBeginPaymentResponse();

            result.Request = request;
            result.ProviderResponse = providerResponse;
            
            var dbOk = false;

            Logger.LogCategory("SaveBeginPayment");
            
            if (providerResponse.Succeeded || !Config.SaveOnlySuccessfulOperations)
            {
                Logger.Log("Start saving in the database");

                var args = new
                {
                    Result = CommandParameter.Output(SqlDbType.VarChar, 50),
                    PaymentId = CommandParameter.Output(SqlDbType.Int),
                    PaymentCode = request.PaymentCode,
                    BankType = request.BankType,
                    Amount = request.Amount,
                    Info = request.Info,
                    Data = request.Data,
                    StepCode = SafeClrConvert.ToString(providerResponse.Code),
                    StepStatus = SafeClrConvert.ToString(providerResponse.Status),
                    StepDate = providerResponse.Date,
                    StepSucceeded = providerResponse.Succeeded,
                    @StepData = ""
                };
                var cmd = _db.GetCommand("usp1_Payment_save_begin_step");

                result.DbResult = _db.ExecuteNonQuery(cmd, args);

                if (result.DbResult.Success)
                {
                    Logger.Log("DbStatus = " + result.Status);

                    dbOk = result.Status == "Success";

                    if (dbOk)
                    {
                        result.Status = args.Result.Value.ToString();
                        result.Data = result.DbResult.Data = (int)args.PaymentId.Value;
                    }
                    else
                    {
                        result.Status = "SaveError";
                    }
                }
                else
                {
                    Logger.Log("Failed: " + result.DbResult.Exception.ToString(","));

                    result.Failed(result.DbResult.Exception);
                }
            }
            else
            {
                dbOk = true;
            }

            if (providerResponse.Succeeded && dbOk)
            {
                result.Succeeded();
            }

            return result;
        }
        private async Task<PaymentManagerBeginPaymentResponse> SaveBeginPaymentAsync(BeginPaymentRequest request, PaymentProviderBeginPaymentResponse providerResponse, CancellationToken cancellation)
        {
            var result = new PaymentManagerBeginPaymentResponse();

            result.Request = request;
            result.ProviderResponse = providerResponse;

            var dbOk = false;

            Logger.LogCategory("SaveBeginPaymentAsync");
            
            if (providerResponse.Succeeded || !Config.SaveOnlySuccessfulOperations)
            {
                Logger.Log("Start saving in the database");

                var args = new
                {
                    Result = CommandParameter.Output(SqlDbType.VarChar, 50),
                    PaymentId = CommandParameter.Output(SqlDbType.Int),
                    PaymentCode = request.PaymentCode,
                    BankType = request.BankType,
                    Amount = request.Amount,
                    Info = request.Info,
                    Data = request.Data,
                    StepCode = SafeClrConvert.ToString(providerResponse.Code),
                    StepStatus = SafeClrConvert.ToString(providerResponse.Status),
                    StepDate = providerResponse.Date,
                    StepSucceeded = providerResponse.Succeeded,
                    @StepData = ""
                };
                var cmd = _db.GetCommand("usp1_Payment_save_begin_step");

                result.DbResult = await _db.ExecuteNonQueryAsync(cmd, args, cancellation);

                if (result.DbResult.Success)
                {
                    Logger.Log("DbStatus = " + result.Status);

                    dbOk = result.Status == "Success";

                    if (dbOk)
                    {
                        result.Status = args.Result.Value.ToString();
                        result.Data = result.DbResult.Data = (int)args.PaymentId.Value;
                    }
                    else
                    {
                        result.Status = "SaveError";
                    }
                }
                else
                {
                    Logger.Log("Failed: " + result.DbResult.Exception.ToString(","));

                    result.Failed(result.DbResult.Exception);
                }
            }
            else
            {
                dbOk = true;
            }

            if (providerResponse.Succeeded && dbOk)
            {
                result.Succeeded();
            }

            return result;
        }
        private PaymentManagerEndPaymentResponse SaveEndPayment(string paymentCode, string beginStepCode, IDictionary<string, string> request, PaymentProviderEndPaymentResponse providerResponse)
        {
            var result = new PaymentManagerEndPaymentResponse();

            result.QueryCode = beginStepCode;
            result.Request = request;

            var dbOk = false;

            Logger.LogCategory("SaveEndPayment");
            
            if (providerResponse.Succeeded || !Config.SaveOnlySuccessfulOperations)
            {
                Logger.Log("Start saving in the database");

                var args = new
                {
                    Result = CommandParameter.Output(SqlDbType.VarChar, 50),
                    PaymentCode = paymentCode,
                    BankType = providerResponse.ProviderType,
                    BeginStepCode = beginStepCode,
                    StepCode = SafeClrConvert.ToString(providerResponse.Code),
                    StepStatus = SafeClrConvert.ToString(providerResponse.Status),
                    StepDate = providerResponse.Date,
                    StepSucceeded = providerResponse.Succeeded,
                    @StepData = ""
                };
                var cmd = _db.GetCommand("usp1_Payment_save_end_step");

                result.DbResult = _db.ExecuteNonQuery(cmd, args);

                if (result.DbResult.Success)
                {
                    result.Status = args.Result.Value.ToString();

                    Logger.Log("DbStatus = " + result.Status);

                    dbOk = result.Status == "Success";

                    if (!dbOk)
                    {
                        result.Status = "SaveError";
                    }
                }
                else
                {
                    Logger.Log("Failed: " + result.DbResult.Exception.ToString(","));

                    result.Failed(result.DbResult.Exception);
                }
            }
            else
            {
                dbOk = true;
            }

            if (providerResponse.Succeeded && dbOk)
            {
                result.Succeeded();
            }

            return result;
        }
        private async Task<PaymentManagerEndPaymentResponse> SaveEndPaymentAsync(string paymentCode, string beginStepCode, IDictionary<string, string> request, PaymentProviderEndPaymentResponse providerResponse, CancellationToken cancellation)
        {
            var result = new PaymentManagerEndPaymentResponse();

            result.QueryCode = beginStepCode;
            result.Request = request;

            var dbOk = false;

            Logger.LogCategory("SaveEndPaymentAsync");
            
            if (providerResponse.Succeeded || !Config.SaveOnlySuccessfulOperations)
            {
                Logger.Log("Start saving in the database");

                var args = new
                {
                    Result = CommandParameter.Output(SqlDbType.VarChar, 50),
                    PaymentCode = paymentCode,
                    BankType = providerResponse.ProviderType,
                    BeginStepCode = beginStepCode,
                    StepCode = SafeClrConvert.ToString(providerResponse.Code),
                    StepStatus = SafeClrConvert.ToString(providerResponse.Status),
                    StepDate = providerResponse.Date,
                    StepSucceeded = providerResponse.Succeeded,
                    @StepData = ""
                };
                var cmd = _db.GetCommand("usp1_Payment_save_end_step");

                result.DbResult = await _db.ExecuteNonQueryAsync(cmd, args, cancellation);

                if (result.DbResult.Success)
                {
                    result.Status = args.Result.Value.ToString();

                    Logger.Log("DbStatus = " + result.Status);

                    dbOk = result.Status == "Success";

                    if (!dbOk)
                    {
                        result.Status = "SaveError";
                    }
                }
                else
                {
                    Logger.Log("Failed: " + result.DbResult.Exception.ToString(","));

                    result.Failed(result.DbResult.Exception);
                }
            }
            else
            {
                dbOk = true;
            }

            if (providerResponse.Succeeded && dbOk)
            {
                result.Succeeded();
            }

            return result;
        }
        private PaymentManagerReversalPaymentResponse SaveReversalPayment(ReversalRequest request, PaymentProviderReversalPaymentResponse providerResponse)
        {
            var result = new PaymentManagerReversalPaymentResponse();

            result.Request = request;

            var dbOk = false;

            Logger.LogCategory("SaveReversalPayment");

            if (providerResponse.Succeeded || !Config.SaveOnlySuccessfulOperations)
            {
                Logger.Log("Start saving in the database");

                var args = new
                {
                    Result = CommandParameter.Output(SqlDbType.VarChar, 50),
                    PaymentCode = request.PaymentCode,
                    BankType = providerResponse.ProviderType,
                    StepStatus = SafeClrConvert.ToString(providerResponse.Status),
                    StepDate = providerResponse.Date,
                    StepSucceeded = providerResponse.Succeeded,
                    @StepData = ""
                };
                var cmd = _db.GetCommand("usp1_Payment_save_reversal_step");

                result.DbResult = _db.ExecuteNonQuery(cmd, args);

                if (result.DbResult.Success)
                {
                    result.Status = args.Result.Value.ToString();

                    Logger.Log("DbStatus = " + result.Status);

                    dbOk = result.Status == "Success";

                    if (!dbOk)
                    {
                        result.Status = "SaveError";
                    }
                }
                else
                {
                    Logger.Log("Failed: " + result.DbResult.Exception.ToString(","));

                    result.Failed(result.DbResult.Exception);
                }
            }
            else
            {
                dbOk = true;
            }

            if (providerResponse.Succeeded && dbOk)
            {
                result.Succeeded();
            }

            return result;
        }
        private async Task<PaymentManagerReversalPaymentResponse> SaveReversalPaymentAsync(ReversalRequest request, PaymentProviderReversalPaymentResponse providerResponse, CancellationToken cancellation)
        {
            var result = new PaymentManagerReversalPaymentResponse();

            result.Request = request;

            var dbOk = false;

            Logger.LogCategory("SaveReversalPaymentAsync");

            if (providerResponse.Succeeded || !Config.SaveOnlySuccessfulOperations)
            {
                Logger.Log("Start saving in the database");

                var args = new
                {
                    Result = CommandParameter.Output(SqlDbType.VarChar, 50),
                    PaymentCode = request.PaymentCode,
                    BankType = providerResponse.ProviderType,
                    StepStatus = SafeClrConvert.ToString(providerResponse.Status),
                    StepDate = providerResponse.Date,
                    StepSucceeded = providerResponse.Succeeded,
                    @StepData = ""
                };
                var cmd = _db.GetCommand("usp1_Payment_save_reversal_step");

                result.DbResult = await _db.ExecuteNonQueryAsync(cmd, args, cancellation);

                if (result.DbResult.Success)
                {
                    result.Status = args.Result.Value.ToString();

                    Logger.Log("DbStatus = " + result.Status);

                    dbOk = result.Status == "Success";

                    if (!dbOk)
                    {
                        result.Status = "SaveError";
                    }
                }
                else
                {
                    Logger.Log("Failed: " + result.DbResult.Exception.ToString(","));

                    result.Failed(result.DbResult.Exception);
                }
            }
            else
            {
                dbOk = true;
            }

            if (providerResponse.Succeeded && dbOk)
            {
                result.Succeeded();
            }

            return result;
        }
        public PaymentManagerBeginPaymentResponse BeginPayment(BeginPaymentRequest request)
        {
            Logger.LogCategory("BeginPayment");
            Logger.Log(new { Request = request });

            var result = new PaymentManagerBeginPaymentResponse();
            var _provider = _providerFactory.GetProvider(request.BankType);

            if (_provider != null)
            {
                var providerResponse = _provider.BeginPayment(request);

                Logger.Log(new { ProviderResponse = providerResponse });

                result = SaveBeginPayment(request, providerResponse);
            }
            else
            {
                result.Status = "InvalidBank";
            }

            Logger.Log("Result = " + result.Status);

            return result;
        }
        public async Task<PaymentManagerBeginPaymentResponse> BeginPaymentAsync(BeginPaymentRequest request, System.Threading.CancellationToken cancellation)
        {
            Logger.LogCategory("BeginPaymentAsync");
            Logger.Log(new { Request = request });

            var result = new PaymentManagerBeginPaymentResponse();
            var _provider = _providerFactory.GetProvider(request.BankType);

            if (_provider != null)
            {
                var providerResponse = _provider.BeginPayment(request);

                Logger.Log(new { ProviderResponse = providerResponse });

                result = await SaveBeginPaymentAsync(request, providerResponse, cancellation);
            }
            else
            {
                result.Status = "InvalidBank";
            }

            Logger.Log("Result = " + result.Status);

            return result;
        }
        public PaymentManagerReversalPaymentResponse ReversalPayment(string bankType, ReversalRequest request)
        {
            var result = new PaymentManagerReversalPaymentResponse();

            Logger.LogCategory("ReversalPayment");
            Logger.Log(new { Request = request });

            var _provider = _providerFactory.GetProvider(bankType);

            if (_provider != null)
            {
                var providerResponse = _provider.ReversalPayment(request);
                result = SaveReversalPayment(request, providerResponse);
            }
            else
            {
                result.Status = "NoPaymentProviderFoundForReversal";
                Logger.Log("No PaymentProvider found for Reversal");
            }

            Logger.Log($"Result = {result.Status}");

            return result;
        }
        public async Task<PaymentManagerReversalPaymentResponse> ReversalPaymentAsync(string bankType, ReversalRequest request, CancellationToken cancellation)
        {
            var result = new PaymentManagerReversalPaymentResponse();

            Logger.LogCategory("ReversalPaymentAsync");
            Logger.Log(new { Request = request });

            var _provider = _providerFactory.GetProvider(bankType);

            if (_provider != null)
            {
                var providerResponse = await _provider.ReversalAsync(request);
                result = await SaveReversalPaymentAsync(request, providerResponse, cancellation);
            }
            else
            {
                result.Status = "NoPaymentProviderFoundForReversal";
                Logger.Log("No PaymentProvider found for Reversal");
            }

            Logger.Log($"Result = {result.Status}");

            return result;
        }
        public PaymentManagerEndPaymentResponse EndPayment(IDictionary<string, string> request, string paymentCode)
        {
            var result = new PaymentManagerEndPaymentResponse();

            Logger.LogCategory("EndPaymentAsync");
            Logger.Log(new { Request = request, PaymentCode = paymentCode });

            var providers = _providerFactory.GetProviders();

            if (providers == null || providers.Length == 0)
            {
                result.Status = "ProviderFactoryIsEmpty";
            }
            else
            {
                var found = false;

                foreach (var _provider in providers)
                {
                    if (_provider.CanEnd(request))
                    {
                        Logger.Log($"Provider {_provider.ProviderType} volunteers for ending this request");
                        Logger.Log($"Retrieving payment from database");

                        var payment = GetPayment(_provider.ProviderType, paymentCode);

                        if (payment == null || payment.Id == 0)
                        {
                            result.NotFound();
                        }
                        else
                        {
                            if (payment.Steps == null || payment.Steps.Count == 0)
                            {
                                result.Status = "PaymentHasNoSteps";
                            }
                            else
                            {
                                request.Add("Amount", payment.Amount);

                                var beginStep = payment.Steps.FirstOrDefault(ps => ps.PaymentStepTypeCodeName == "BeginPayment");
                                if (beginStep == null)
                                {
                                    result.Status = "PaymentHasNoBeginStep";
                                }
                                else
                                {
                                    found = true;
                                    var query = _provider.GetEndPaymentQuery(request);

                                    if (!string.IsNullOrEmpty(query))
                                    {
                                        Logger.Log($"Query = {query}");

                                        try
                                        {
                                            var providerResponse = _provider.EndPayment(request);

                                            Logger.Log(new { ProviderResponse = providerResponse });

                                            result = SaveEndPayment(paymentCode, query, request, providerResponse);

                                            if (providerResponse.Succeeded && !result.Success)
                                            {
                                                Logger.Log("EndPayment not saved in DB.");

                                                if (Config.AutoReverseFailedPayments)
                                                {
                                                    Logger.Log("Reversing the payment ...");

                                                    try
                                                    {
                                                        result.ReversalResponse = ReversalPayment(providerResponse.ProviderType, new ReversalRequest { PaymentCode = paymentCode });

                                                        if (result.ReversalResponse.ProviderResponse.Succeeded)
                                                        {
                                                            Logger.Log("Payment reversed.");

                                                            if (!result.ReversalResponse.DbResult.Success)
                                                            {
                                                                Logger.Log("Warning: Reversal result not saved in DB.");
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Logger.Log("INCONSISTENCY: EndPayment not reversed");
                                                        }
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        Logger.Log("Reversal Failed: " + e.ToString(","));
                                                    }
                                                }
                                                else
                                                {
                                                    Logger.Log("Warning: Auto Reversing the payment is prohibited.");
                                                }
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            Logger.Log(e.ToString(","));

                                            result.SetStatus("ServiceCallFailed", e);
                                        }
                                    }
                                    else
                                    {
                                        result.Status = "NoQuery";
                                    }
                                }
                            }
                        }

                        break;
                    }
                }

                if (!found)
                {
                    result.Status = "NoProviderCanEndThisRequest";
                }
            }

            Logger.Log("EndPayment Result = " + result.Status);

            return result;
        }
        public async Task<PaymentManagerEndPaymentResponse> EndPaymentAsync(IDictionary<string, string> request, string paymentCode, CancellationToken cancellation)
        {
            var result = new PaymentManagerEndPaymentResponse();

            Logger.LogCategory("EndPaymentAsync");
            Logger.Log(new { Request = request, PaymentCode = paymentCode });

            var providers = _providerFactory.GetProviders();
            if (providers == null || providers.Length == 0)
            {
                result.Status = "ProviderFactoryIsEmpty";
            }
            else
            {
                var found = false;

                foreach (var _provider in providers)
                {
                    if (_provider.CanEnd(request))
                    {
                        Logger.Log($"Provider {_provider.ProviderType} volunteers for ending this request");
                        Logger.Log($"Retrieving payment from database");

                        var payment = await GetPaymentAsync(_provider.ProviderType, paymentCode, cancellation);

                        if (payment == null || payment.Id == 0)
                        {
                            result.NotFound();
                        }
                        else
                        {
                            if (payment.Steps == null || payment.Steps.Count == 0)
                            {
                                result.Status = "PaymentHasNoSteps";
                            }
                            else
                            {
                                request.Add("Amount", payment.Amount);
                                
                                var beginStep = payment.Steps.FirstOrDefault(ps => ps.PaymentStepTypeCodeName == "BeginPayment");
                                if (beginStep == null)
                                {
                                    result.Status = "PaymentHasNoBeginStep";
                                }
                                else
                                {
                                    found = true;
                                    var query = _provider.GetEndPaymentQuery(request);

                                    if (!string.IsNullOrEmpty(query))
                                    {
                                        Logger.Log($"Query = {query}");

                                        try
                                        {
                                            var providerResponse = _provider.EndPayment(request);

                                            Logger.Log(new { ProviderResponse = providerResponse });

                                            result = await SaveEndPaymentAsync(paymentCode, query, request, providerResponse, cancellation);

                                            if (providerResponse.Succeeded && !result.Success)
                                            {
                                                Logger.Log("EndPayment not saved in DB.");

                                                if (Config.AutoReverseFailedPayments)
                                                {
                                                    Logger.Log("Reversing the payment ...");

                                                    try
                                                    {
                                                        result.ReversalResponse = await ReversalPaymentAsync(providerResponse.ProviderType, new ReversalRequest { PaymentCode = paymentCode }, cancellation);

                                                        if (result.ReversalResponse.ProviderResponse.Succeeded)
                                                        {
                                                            Logger.Log("Payment reversed.");

                                                            if (!result.ReversalResponse.DbResult.Success)
                                                            {
                                                                Logger.Log("Warning: Reversal result not saved in DB.");
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Logger.Log("INCONSISTENCY: EndPayment not reversed");
                                                        }
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        Logger.Log("Reversal Failed: " + e.ToString(","));
                                                    }
                                                }
                                                else
                                                {
                                                    Logger.Log("Warning: Auto Reversing the payment is prohibited.");
                                                }
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            Logger.Log(e.ToString(","));

                                            result.SetStatus("ServiceCallFailed", e);
                                        }
                                    }
                                    else
                                    {
                                        result.Status = "NoQuery";
                                    }
                                }
                            }
                        }

                        break;
                    }
                }

                if (!found)
                {
                    result.Status = "NoProviderCanEndThisRequest";
                }
            }

            Logger.Log("EndPayment Result = " + result.Status);

            return result;
        }
        public Payment GetPayment(string bankType, string paymentCode)
        {
            Payment result = null;

            var cmd = _db.GetCommand("usp1_Payment_get_by_paymentcode");

            var dbr = _db.ExecuteSingle<Payment>(cmd, new { PaymentCode = paymentCode });
            
            if (dbr.Success)
            {
                result = dbr.Data;

                cmd = _db.GetCommand("usp1_Payment_get_steps");
                var dbr2 = _db.ExecuteReader<PaymentStep>(cmd, new { Id = result.Id });

                if (dbr2.Success)
                {
                    result.Steps = dbr2.Data;
                }
                else
                {
                    Logger.Log("GetPaymentSteps Failed: " + dbr2.Exception?.ToString(","));
                }
            }
            else
            {
                Logger.Log("GetPayment Failed: " + dbr.Exception?.ToString(","));
            }

            return result;
        }
        public async Task<Payment> GetPaymentAsync(string bankType, string paymentCode, CancellationToken cancellation)
        {
            Payment result = null;

            var cmd = _db.GetCommand("usp1_Payment_get_by_paymentcode");

            var dbr = await _db.ExecuteSingleAsync<Payment>(cmd, new { PaymentCode = paymentCode }, cancellation);

            if (dbr.Success)
            {
                result = dbr.Data;

                cmd = _db.GetCommand("usp1_Payment_get_steps");
                var dbr2 = await _db.ExecuteReaderAsync<PaymentStep>(cmd, new { Id = result.Id }, cancellation);

                if (dbr2.Success)
                {
                    result.Steps = dbr2.Data;
                }
                else
                {
                    Logger.Log("GetPaymentSteps Failed: " + dbr2.Exception?.ToString(","));
                }
            }
            else
            {
                Logger.Log("GetPayment Failed: " + dbr.Exception?.ToString(","));
            }

            return result;
        }
    }
}
