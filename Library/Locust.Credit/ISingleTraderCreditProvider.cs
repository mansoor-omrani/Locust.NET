using Locust.Auditing;
using Locust.Data;
using Locust.Db;
using Locust.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Locust.Credit
{
    public class SingleTraderCreditProviderConfig
    {
        
    }
    #region Request/Response
    // ------------------------- Apply --------------------
    public class SingleTraderCreditProviderApplyRequest : ServiceRequest
    {
        public string UserName { get; set; }
        public decimal Amount { get; set; }
        public string Info { get; set; }
        internal string AuditCode { get; set; }
    }
    public class SingleTraderCreditProviderApplyResponse : ServiceResponse
    {
    }
    // ------------------------- BeginApply --------------------
    public class SingleTraderCreditProviderBeginApplyRequest : SingleTraderCreditProviderApplyRequest
    {
    }
    public class SingleTraderCreditProviderBeginApplyResponse : ServiceResponse<string>
    {
    }
    // ------------------------- EndApply --------------------
    public class SingleTraderCreditProviderEndApplyRequest : ServiceRequest
    {
        public string TransactionKey { get; set; }
        internal string AuditCode { get; set; }
    }
    public class SingleTraderCreditProviderEndApplyResponse : ServiceResponse
    {
    }
    // ------------------------- BeginWithdraw --------------------
    public class SingleTraderCreditProviderBeginWithdrawRequest: SingleTraderCreditProviderApplyRequest
    {
    }
    public class SingleTraderCreditProviderBeginWithdrawResponse : ServiceResponse<string>
    {
    }
    // ------------------------- EndWithdraw --------------------
    public class SingleTraderCreditProviderEndWithdrawRequest : SingleTraderCreditProviderEndApplyRequest
    {
    }
    public class SingleTraderCreditProviderEndWithdrawResponse : ServiceResponse
    {
    }
    // ------------------------- Withdraw --------------------
    public class SingleTraderCreditProviderWithdrawRequest : SingleTraderCreditProviderApplyRequest
    {
    }
    public class SingleTraderCreditProviderWithdrawResponse : ServiceResponse
    {
    }
    // ------------------------- BeginDeposit --------------------
    public class SingleTraderCreditProviderBeginDepositRequest : SingleTraderCreditProviderApplyRequest
    {
    }
    public class SingleTraderCreditProviderBeginDepositResponse : ServiceResponse<string>
    {
    }
    // ------------------------- EndDeposit --------------------
    public class SingleTraderCreditProviderEndDepositRequest : SingleTraderCreditProviderEndApplyRequest
    {
    }
    public class SingleTraderCreditProviderEndDepositResponse : ServiceResponse
    {
    }
    // ------------------------- Deposit --------------------
    public class SingleTraderCreditProviderDepositRequest : SingleTraderCreditProviderApplyRequest
    {
    }
    public class SingleTraderCreditProviderDepositResponse : ServiceResponse
    {
    }
    // ------------------------- BeginTransfer --------------------
    public class SingleTraderCreditProviderBeginTransferRequest : SingleTraderCreditProviderTransferRequest
    {
    }
    public class SingleTraderCreditProviderBeginTransferResponse : ServiceResponse<string>
    {
    }
    // ------------------------- EndTransfer --------------------
    public class SingleTraderCreditProviderEndTransferRequest : SingleTraderCreditProviderEndApplyRequest
    {
    }
    public class SingleTraderCreditProviderEndTransferResponse : ServiceResponse
    {
    }
    // ------------------------- Transfer --------------------
    public class SingleTraderCreditProviderTransferRequest : ServiceRequest
    {
        public string FromUserName { get; set; }
        public string ToUserName { get; set; }
        public decimal Amount { get; set; }
        public string FromInfo { get; set; }
        public string ToInfo { get; set; }
    }
    public class SingleTraderCreditProviderTransferResponse : ServiceResponse
    {
    }
    #endregion
    public interface ISingleTraderCreditProvider
    {
        SingleTraderCreditProviderConfig Config { get; set; }
        // -------------------- WithDraw --------------------
        SingleTraderCreditProviderBeginWithdrawResponse BeginWithDraw(SingleTraderCreditProviderBeginWithdrawRequest request);
        Task<SingleTraderCreditProviderBeginWithdrawResponse> BeginWithDrawAsync(SingleTraderCreditProviderBeginWithdrawRequest request, CancellationToken cancellation);
        SingleTraderCreditProviderEndWithdrawResponse EndWithDraw(SingleTraderCreditProviderEndWithdrawRequest request);
        Task<SingleTraderCreditProviderEndWithdrawResponse> EndWithDrawAsync(SingleTraderCreditProviderEndWithdrawRequest request, CancellationToken cancellation);
        SingleTraderCreditProviderWithdrawResponse WithDraw(SingleTraderCreditProviderWithdrawRequest request);
        Task<SingleTraderCreditProviderWithdrawResponse> WithDrawAsync(SingleTraderCreditProviderWithdrawRequest request, CancellationToken cancellation);
        // -------------------- Deposit --------------------
        SingleTraderCreditProviderBeginDepositResponse BeginDeposit(SingleTraderCreditProviderBeginDepositRequest request);
        Task<SingleTraderCreditProviderBeginDepositResponse> BeginDepositAsync(SingleTraderCreditProviderBeginDepositRequest request, CancellationToken cancellation);
        SingleTraderCreditProviderEndDepositResponse EndDeposit(SingleTraderCreditProviderEndDepositRequest request);
        Task<SingleTraderCreditProviderEndDepositResponse> EndDepositAsync(SingleTraderCreditProviderEndDepositRequest request, CancellationToken cancellation);
        SingleTraderCreditProviderDepositResponse Deposit(SingleTraderCreditProviderDepositRequest request);
        Task<SingleTraderCreditProviderDepositResponse> DepositAsync(SingleTraderCreditProviderDepositRequest request, CancellationToken cancellation);
        // -------------------- Transfer --------------------
        SingleTraderCreditProviderBeginTransferResponse BeginTransfer(SingleTraderCreditProviderBeginTransferRequest request);
        Task<SingleTraderCreditProviderBeginTransferResponse> BeginTransferAsync(SingleTraderCreditProviderBeginTransferRequest request, CancellationToken cancellation);
        SingleTraderCreditProviderEndTransferResponse EndTransfer(SingleTraderCreditProviderEndTransferRequest request);
        Task<SingleTraderCreditProviderEndTransferResponse> EndTransferAsync(SingleTraderCreditProviderEndTransferRequest request, CancellationToken cancellation);
        SingleTraderCreditProviderTransferResponse Transfer(SingleTraderCreditProviderTransferRequest request);
        Task<SingleTraderCreditProviderTransferResponse> TransferAsync(SingleTraderCreditProviderTransferRequest request, CancellationToken cancellation);
    }
    public class SingleTraderCreditProvider : ISingleTraderCreditProvider
    {
        public IDbHelper Db { get; set; }
        public IAuditor Auditor { get; set; }
        public SingleTraderCreditProviderConfig Config { get; set; }
        public SingleTraderCreditProvider(SingleTraderCreditProviderConfig config, IDbHelper db, IAuditor auditor)
        {
            Db = db;
            Auditor = auditor;
            Config = config;
        }
        private SingleTraderCreditProviderApplyResponse Apply(SingleTraderCreditProviderApplyRequest request)
        {
            var response = new SingleTraderCreditProviderApplyResponse();
            var args = new
            {
                Result = CommandParameter.Output(System.Data.SqlDbType.VarChar, 80),
                UserName = request.UserName,
                Amount = request.Amount,
                Info = request.Info
            };
            var dbr = Db.ExecuteNonQuery("usp1_Credit_singletrader_apply", args);
            if (dbr.Success)
            {
                response.Status = args.Result.Value?.ToString();
                var ar = Auditor.Audit(request.AuditCode, $"{{u:{request.UserName},m:{request.Amount}}}");
                if (ar.IsSucceeded())
                {
                    if (response.Status == "Success")
                    {
                        response.Succeeded();
                    }
                }
                else
                {
                    response.Exception = ar.Exception;
                    response.Status = "AuditError";
                }
            }
            else
            {
                response.Failed(dbr.Exception);
            }

            return response;
        }
        private async Task<SingleTraderCreditProviderApplyResponse> ApplyAsync(SingleTraderCreditProviderApplyRequest request, CancellationToken cancellation)
        {
            var response = new SingleTraderCreditProviderApplyResponse();
            var args = new
            {
                Result = CommandParameter.Output(System.Data.SqlDbType.VarChar, 80),
                UserName = request.UserName,
                Amount = request.Amount,
                Info = request.Info
            };
            var dbr = await Db.ExecuteNonQueryAsync("usp1_Credit_singletrader_apply", args, cancellation);
            if (dbr.Success)
            {
                response.Status = args.Result.Value?.ToString();
                var ar = await Auditor.AuditAsync(request.AuditCode, $"{{u:{request.UserName},m:{request.Amount}}}");
                if (ar.IsSucceeded())
                {
                    if (response.Status == "Success")
                    {
                        response.Succeeded();
                    }
                }
                else
                {
                    response.Exception = ar.Exception;
                    response.Status = "AuditError";
                }
            }
            else
            {
                response.Failed(dbr.Exception);
            }

            return response;
        }
        private SingleTraderCreditProviderBeginApplyResponse BeginApply(SingleTraderCreditProviderBeginApplyRequest request)
        {
            var response = new SingleTraderCreditProviderBeginApplyResponse();
            var args = new
            {
                Result = CommandParameter.Output(System.Data.SqlDbType.VarChar, 80),
                Key = CommandParameter.Output(System.Data.SqlDbType.VarChar, 50),
                UserName = request.UserName,
                Amount = request.Amount,
                Info = request.Info
            };
            var dbr = Db.ExecuteNonQuery("usp1_Credit_singletrader_begin_apply", args);
            if (dbr.Success)
            {
                response.Status = args.Result.Value?.ToString();
                var ar = Auditor.Audit(request.AuditCode, $"{{u:{request.UserName},m:{request.Amount}}}");
                if (ar.IsSucceeded())
                {
                    if (response.Status == "Success")
                    {
                        response.Succeeded(args.Key.Value);
                    }
                }
                else
                {
                    response.Exception = ar.Exception;
                    response.Status = "AuditError";
                }
            }
            else
            {
                response.Failed(dbr.Exception);
            }

            return response;
        }
        private async Task<SingleTraderCreditProviderBeginApplyResponse> BeginApplyAsync(SingleTraderCreditProviderBeginApplyRequest request, CancellationToken cancellation)
        {
            var response = new SingleTraderCreditProviderBeginApplyResponse();
            var args = new
            {
                Result = CommandParameter.Output(System.Data.SqlDbType.VarChar, 50),
                Key = CommandParameter.Output(System.Data.SqlDbType.VarChar, 50),
                UserName = request.UserName,
                Amount = request.Amount,
                Info = request.Info
            };
            var dbr = await Db.ExecuteNonQueryAsync("usp1_Credit_singletrader_begin_apply", args, cancellation);
            if (dbr.Success)
            {
                response.Status = args.Result.Value?.ToString();
                var ar = await Auditor.AuditAsync(request.AuditCode, $"{{u:{request.UserName},m:{request.Amount}}}");

                if (ar.IsSucceeded())
                {
                    if (response.Status == "Success")
                    {
                        response.Succeeded(args.Key.Value);
                    }
                }
                else
                {
                    response.Exception = ar.Exception;
                    response.Status = "AuditError";
                }
            }
            else
            {
                response.Failed(dbr.Exception);
            }

            return response;
        }
        private SingleTraderCreditProviderEndApplyResponse EndApply(SingleTraderCreditProviderEndApplyRequest request)
        {
            var response = new SingleTraderCreditProviderEndApplyResponse();
            var args = new
            {
                Result = CommandParameter.Output(System.Data.SqlDbType.VarChar, 80),
                TransactionKey = request.TransactionKey
            };
            var dbr = Db.ExecuteNonQuery("usp1_Credit_singletrader_end_apply", args);
            if (dbr.Success)
            {
                response.Status = args.Result.Value?.ToString();
                var ar = Auditor.Audit(request.AuditCode, $"{{trnk:{request.TransactionKey}}}");
                if (ar.IsSucceeded())
                {
                    if (response.Status == "Success")
                    {
                        response.Succeeded();
                    }
                }
                else
                {
                    response.Exception = ar.Exception;
                    response.Status = "AuditError";
                }
            }
            else
            {
                response.Failed(dbr.Exception);
            }

            return response;
        }
        private async Task<SingleTraderCreditProviderEndApplyResponse> EndApplyAsync(SingleTraderCreditProviderEndApplyRequest request, CancellationToken cancellation)
        {
            var response = new SingleTraderCreditProviderEndApplyResponse();
            var args = new
            {
                Result = CommandParameter.Output(System.Data.SqlDbType.VarChar, 50),
                Key = CommandParameter.Output(System.Data.SqlDbType.VarChar, 50),
                TransactionKey = request.TransactionKey
            };
            var dbr = await Db.ExecuteNonQueryAsync("usp1_Credit_singletrader_end_apply", args, cancellation);
            if (dbr.Success)
            {
                response.Status = args.Result.Value?.ToString();
                var ar = await Auditor.AuditAsync(request.AuditCode, $"{{trnk:{request.TransactionKey}}}");

                if (ar.IsSucceeded())
                {
                    if (response.Status == "Success")
                    {
                        response.Succeeded();
                    }
                }
                else
                {
                    response.Exception = ar.Exception;
                    response.Status = "AuditError";
                }
            }
            else
            {
                response.Failed(dbr.Exception);
            }

            return response;
        }
        // -------------------------- Withdraw --------------------------
        public SingleTraderCreditProviderBeginWithdrawResponse BeginWithDraw(SingleTraderCreditProviderBeginWithdrawRequest request)
        {
            var response = new SingleTraderCreditProviderBeginWithdrawResponse();
            var sr = BeginApply(new SingleTraderCreditProviderBeginApplyRequest
            {
                UserName = request.UserName,
                Amount = -request.Amount,
                Info = request.Info,
                AuditCode = "CRD_BGNWTHDRW"
            });

            response.Copy(sr);

            return response;
        }
        public async Task<SingleTraderCreditProviderBeginWithdrawResponse> BeginWithDrawAsync(SingleTraderCreditProviderBeginWithdrawRequest request, CancellationToken cancellation)
        {
            var response = new SingleTraderCreditProviderBeginWithdrawResponse();
            var sr = await BeginApplyAsync(new SingleTraderCreditProviderBeginApplyRequest
            {
                UserName = request.UserName,
                Amount = -request.Amount,
                Info = request.Info,
                AuditCode = "CRD_BGNWTHDRW"
            }, cancellation);

            response.Copy(sr);

            return response;
        }
        public SingleTraderCreditProviderEndWithdrawResponse EndWithDraw(SingleTraderCreditProviderEndWithdrawRequest request)
        {
            var response = new SingleTraderCreditProviderEndWithdrawResponse();
            var sr = EndApply(new SingleTraderCreditProviderEndApplyRequest
            {
                TransactionKey = request.TransactionKey,
                AuditCode = "CRD_ENDWTHDRW"
            });

            response.Copy(sr);

            return response;
        }
        public async Task<SingleTraderCreditProviderEndWithdrawResponse> EndWithDrawAsync(SingleTraderCreditProviderEndWithdrawRequest request, CancellationToken cancellation)
        {
            var response = new SingleTraderCreditProviderEndWithdrawResponse();
            var sr = await EndApplyAsync(new SingleTraderCreditProviderEndApplyRequest
            {
                TransactionKey = request.TransactionKey,
                AuditCode = "CRD_ENDWTHDRW"
            }, cancellation);

            response.Copy(sr);

            return response;
        }
        public SingleTraderCreditProviderWithdrawResponse WithDraw(SingleTraderCreditProviderWithdrawRequest request)
        {
            var response = new SingleTraderCreditProviderWithdrawResponse();
            var sr = Apply(new SingleTraderCreditProviderApplyRequest
            {
                UserName = request.UserName,
                Amount = -request.Amount,
                Info = request.Info,
                AuditCode = "CRD_WTHDRW"
            });

            response.Copy(sr);

            return response;
        }
        public async Task<SingleTraderCreditProviderWithdrawResponse> WithDrawAsync(SingleTraderCreditProviderWithdrawRequest request, CancellationToken cancellation)
        {
            var response = new SingleTraderCreditProviderWithdrawResponse();
            var sr = await ApplyAsync(new SingleTraderCreditProviderApplyRequest
            {
                UserName = request.UserName,
                Amount = -request.Amount,
                Info = request.Info,
                AuditCode = "CRD_WTHDRW"
            }, cancellation);

            response.Copy(sr);

            return response;
        }
        // -------------------------- Deposit --------------------------
        public SingleTraderCreditProviderBeginDepositResponse BeginDeposit(SingleTraderCreditProviderBeginDepositRequest request)
        {
            var response = new SingleTraderCreditProviderBeginDepositResponse();
            var sr = BeginApply(new SingleTraderCreditProviderBeginApplyRequest
            {
                UserName = request.UserName,
                Amount = request.Amount,
                Info = request.Info,
                AuditCode = "CRD_BGNDPST"
            });

            response.Copy(sr);

            return response;
        }
        public async Task<SingleTraderCreditProviderBeginDepositResponse> BeginDepositAsync(SingleTraderCreditProviderBeginDepositRequest request, CancellationToken cancellation)
        {
            var response = new SingleTraderCreditProviderBeginDepositResponse();
            var sr = await BeginApplyAsync(new SingleTraderCreditProviderBeginApplyRequest
            {
                UserName = request.UserName,
                Amount = request.Amount,
                Info = request.Info,
                AuditCode = "CRD_BGNDPST"
            }, cancellation);

            response.Copy(sr);

            return response;
        }
        public SingleTraderCreditProviderEndDepositResponse EndDeposit(SingleTraderCreditProviderEndDepositRequest request)
        {
            var response = new SingleTraderCreditProviderEndDepositResponse();
            var sr = EndApply(new SingleTraderCreditProviderEndApplyRequest
            {
                TransactionKey = request.TransactionKey,
                AuditCode = "CRD_ENDDPST"
            });

            response.Copy(sr);

            return response;
        }
        public async Task<SingleTraderCreditProviderEndDepositResponse> EndDepositAsync(SingleTraderCreditProviderEndDepositRequest request, CancellationToken cancellation)
        {
            var response = new SingleTraderCreditProviderEndDepositResponse();
            var sr = await EndApplyAsync(new SingleTraderCreditProviderEndApplyRequest
            {
                TransactionKey = request.TransactionKey,
                AuditCode = "CRD_ENDDPST"
            }, cancellation);

            response.Copy(sr);

            return response;
        }
        public SingleTraderCreditProviderDepositResponse Deposit(SingleTraderCreditProviderDepositRequest request)
        {
            var response = new SingleTraderCreditProviderDepositResponse();
            var sr = Apply(new SingleTraderCreditProviderApplyRequest
            {
                UserName = request.UserName,
                Amount = request.Amount,
                Info = request.Info,
                AuditCode = "CRD_DPST"
            });

            response.Copy(sr);

            return response;
        }
        public async Task<SingleTraderCreditProviderDepositResponse> DepositAsync(SingleTraderCreditProviderDepositRequest request, CancellationToken cancellation)
        {
            var response = new SingleTraderCreditProviderDepositResponse();
            var sr = await ApplyAsync(new SingleTraderCreditProviderApplyRequest
            {
                UserName = request.UserName,
                Amount = request.Amount,
                Info = request.Info,
                AuditCode = "CRD_DPST"
            }, cancellation);

            response.Copy(sr);

            return response;
        }
        // -------------------------- Transfer --------------------------
        public SingleTraderCreditProviderTransferResponse Transfer(SingleTraderCreditProviderTransferRequest request)
        {
            var response = new SingleTraderCreditProviderTransferResponse();
            var args = new
            {
                Result = CommandParameter.Output(System.Data.SqlDbType.VarChar, 80),
                request.FromUserName,
                request.ToUserName,
                request.Amount,
                request.FromInfo,
                request.ToInfo
            };
            var dbr = Db.ExecuteNonQuery("usp1_Credit_singletrader_transfer", args);
            if (dbr.Success)
            {
                response.Status = args.Result.Value?.ToString();
                var ar = Auditor.Audit("CRD_TRNSFR", $"{{fu:{request.FromUserName},tu:{request.ToUserName},m:{request.Amount}}}");
                if (ar.IsSucceeded())
                {
                    if (response.Status == "Success")
                    {
                        response.Succeeded();
                    }
                }
                else
                {
                    response.Exception = ar.Exception;
                    response.Status = "AuditError";
                }
            }
            else
            {
                response.Failed(dbr.Exception);
            }

            return response;
        }
        public async Task<SingleTraderCreditProviderTransferResponse> TransferAsync(SingleTraderCreditProviderTransferRequest request, CancellationToken cancellation)
        {
            var response = new SingleTraderCreditProviderTransferResponse();
            var args = new
            {
                Result = CommandParameter.Output(System.Data.SqlDbType.VarChar, 80),
                request.FromUserName,
                request.ToUserName,
                request.Amount,
                request.FromInfo,
                request.ToInfo
            };
            var dbr = await Db.ExecuteNonQueryAsync("usp1_Credit_singletrader_transfer", args, cancellation);
            if (dbr.Success)
            {
                response.Status = args.Result.Value?.ToString();
                var ar = await Auditor.AuditAsync("CRD_TRNSFR", $"{{fu:{request.FromUserName},tu:{request.ToUserName},m:{request.Amount}}}");
                if (ar.IsSucceeded())
                {
                    if (response.Status == "Success")
                    {
                        response.Succeeded();
                    }
                }
                else
                {
                    response.Exception = ar.Exception;
                    response.Status = "AuditError";
                }
            }
            else
            {
                response.Failed(dbr.Exception);
            }

            return response;
        }
        public SingleTraderCreditProviderBeginTransferResponse BeginTransfer(SingleTraderCreditProviderBeginTransferRequest request)
        {
            var response = new SingleTraderCreditProviderBeginTransferResponse();
            var args = new
            {
                Result = CommandParameter.Output(System.Data.SqlDbType.VarChar, 80),
                Key = CommandParameter.Output(System.Data.SqlDbType.VarChar, 50),
                request.FromUserName,
                request.ToUserName,
                request.Amount,
                request.FromInfo,
                request.ToInfo
            };
            var dbr = Db.ExecuteNonQuery("usp1_Credit_singletrader_begin_transfer", args);
            if (dbr.Success)
            {
                response.Status = args.Result.Value?.ToString();
                var ar = Auditor.Audit("CRD_BGNTRNSFR", $"{{fu:{request.FromUserName},tu:{request.ToUserName},m:{request.Amount}}}");
                if (ar.IsSucceeded())
                {
                    if (response.Status == "Success")
                    {
                        response.Succeeded(args.Key.Value);
                    }
                }
                else
                {
                    response.Exception = ar.Exception;
                    response.Status = "AuditError";
                }
            }
            else
            {
                response.Failed(dbr.Exception);
            }

            return response;
        }
        public async Task<SingleTraderCreditProviderBeginTransferResponse> BeginTransferAsync(SingleTraderCreditProviderBeginTransferRequest request, CancellationToken cancellation)
        {
            var response = new SingleTraderCreditProviderBeginTransferResponse();
            var args = new
            {
                Result = CommandParameter.Output(System.Data.SqlDbType.VarChar, 50),
                Key = CommandParameter.Output(System.Data.SqlDbType.VarChar, 50),
                request.FromUserName,
                request.ToUserName,
                request.Amount,
                request.FromInfo,
                request.ToInfo
            };
            var dbr = await Db.ExecuteNonQueryAsync("usp1_Credit_singletrader_begin_transfer", args, cancellation);
            if (dbr.Success)
            {
                response.Status = args.Result.Value?.ToString();
                var ar = await Auditor.AuditAsync("CRD_BGNTRNSFR", $"{{fu:{request.FromUserName},tu:{request.ToUserName},m:{request.Amount}}}");

                if (ar.IsSucceeded())
                {
                    if (response.Status == "Success")
                    {
                        response.Succeeded(args.Key.Value);
                    }
                }
                else
                {
                    response.Exception = ar.Exception;
                    response.Status = "AuditError";
                }
            }
            else
            {
                response.Failed(dbr.Exception);
            }

            return response;
        }
        public SingleTraderCreditProviderEndTransferResponse EndTransfer(SingleTraderCreditProviderEndTransferRequest request)
        {
            var response = new SingleTraderCreditProviderEndTransferResponse();
            var args = new
            {
                Result = CommandParameter.Output(System.Data.SqlDbType.VarChar, 80),
                TransactionKey = request.TransactionKey
            };
            var dbr = Db.ExecuteNonQuery("usp1_Credit_singletrader_end_transfer", args);
            if (dbr.Success)
            {
                response.Status = args.Result.Value?.ToString();
                var ar = Auditor.Audit("CRD_ENDTRNSFR", $"{{trnk:{request.TransactionKey}}}");
                if (ar.IsSucceeded())
                {
                    if (response.Status == "Success")
                    {
                        response.Succeeded();
                    }
                }
                else
                {
                    response.Exception = ar.Exception;
                    response.Status = "AuditError";
                }
            }
            else
            {
                response.Failed(dbr.Exception);
            }

            return response;
        }
        public async Task<SingleTraderCreditProviderEndTransferResponse> EndTransferAsync(SingleTraderCreditProviderEndTransferRequest request, CancellationToken cancellation)
        {
            var response = new SingleTraderCreditProviderEndTransferResponse();
            var args = new
            {
                Result = CommandParameter.Output(System.Data.SqlDbType.VarChar, 50),
                Key = CommandParameter.Output(System.Data.SqlDbType.VarChar, 50),
                TransactionKey = request.TransactionKey
            };
            var dbr = await Db.ExecuteNonQueryAsync("usp1_Credit_singletrader_end_transfer", args, cancellation);
            if (dbr.Success)
            {
                response.Status = args.Result.Value?.ToString();
                var ar = await Auditor.AuditAsync("CRD_ENDTRNSFR", $"{{trnk:{request.TransactionKey}}}");

                if (ar.IsSucceeded())
                {
                    if (response.Status == "Success")
                    {
                        response.Succeeded();
                    }
                }
                else
                {
                    response.Exception = ar.Exception;
                    response.Status = "AuditError";
                }
            }
            else
            {
                response.Failed(dbr.Exception);
            }

            return response;
        }
    }
}
