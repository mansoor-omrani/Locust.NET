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
    public class MultiTraderCreditProviderConfig
    {
        
    }
    #region Request/Response
    // ------------------------- Apply --------------------
    public class MultiTraderCreditProviderApplyRequest : ServiceRequest
    {
        public string TraderKey { get; set; }
        public string UserName { get; set; }
        public decimal Amount { get; set; }
        public string Info { get; set; }
        internal string AuditCode { get; set; }
    }
    public class MultiTraderCreditProviderApplyResponse : ServiceResponse
    {
    }
    // ------------------------- BeginApply --------------------
    public class MultiTraderCreditProviderBeginApplyRequest : MultiTraderCreditProviderApplyRequest
    {
    }
    public class MultiTraderCreditProviderBeginApplyResponse : ServiceResponse<string>
    {
    }
    // ------------------------- EndApply --------------------
    public class MultiTraderCreditProviderEndApplyRequest : ServiceRequest
    {
        public string TraderKey { get; set; }
        public string TransactionKey { get; set; }
        internal string AuditCode { get; set; }
    }
    public class MultiTraderCreditProviderEndApplyResponse : ServiceResponse
    {
    }
    // ------------------------- BeginWithdraw --------------------
    public class MultiTraderCreditProviderBeginWithdrawRequest: MultiTraderCreditProviderApplyRequest
    {
    }
    public class MultiTraderCreditProviderBeginWithdrawResponse : ServiceResponse<string>
    {
    }
    // ------------------------- EndWithdraw --------------------
    public class MultiTraderCreditProviderEndWithdrawRequest : MultiTraderCreditProviderEndApplyRequest
    {
    }
    public class MultiTraderCreditProviderEndWithdrawResponse : ServiceResponse
    {
    }
    // ------------------------- Withdraw --------------------
    public class MultiTraderCreditProviderWithdrawRequest : MultiTraderCreditProviderApplyRequest
    {
    }
    public class MultiTraderCreditProviderWithdrawResponse : ServiceResponse
    {
    }
    // ------------------------- BeginDeposit --------------------
    public class MultiTraderCreditProviderBeginDepositRequest : MultiTraderCreditProviderApplyRequest
    {
    }
    public class MultiTraderCreditProviderBeginDepositResponse : ServiceResponse<string>
    {
    }
    // ------------------------- EndDeposit --------------------
    public class MultiTraderCreditProviderEndDepositRequest : MultiTraderCreditProviderEndApplyRequest
    {
    }
    public class MultiTraderCreditProviderEndDepositResponse : ServiceResponse
    {
    }
    // ------------------------- Deposit --------------------
    public class MultiTraderCreditProviderDepositRequest : MultiTraderCreditProviderApplyRequest
    {
    }
    public class MultiTraderCreditProviderDepositResponse : ServiceResponse
    {
    }
    // ------------------------- BeginTransfer --------------------
    public class MultiTraderCreditProviderBeginTransferRequest : MultiTraderCreditProviderTransferRequest
    {
    }
    public class MultiTraderCreditProviderBeginTransferResponse : ServiceResponse<string>
    {
    }
    // ------------------------- EndTransfer --------------------
    public class MultiTraderCreditProviderEndTransferRequest : MultiTraderCreditProviderEndApplyRequest
    {
    }
    public class MultiTraderCreditProviderEndTransferResponse : ServiceResponse
    {
    }
    // ------------------------- Transfer --------------------
    public class MultiTraderCreditProviderTransferRequest : ServiceRequest
    {
        public string TraderKey { get; set; }
        public string FromUserName { get; set; }
        public string ToUserName { get; set; }
        public decimal Amount { get; set; }
        public string FromInfo { get; set; }
        public string ToInfo { get; set; }
    }
    public class MultiTraderCreditProviderTransferResponse : ServiceResponse
    {
    }
    #endregion
    public interface IMultiTraderCreditProvider
    {
        MultiTraderCreditProviderConfig Config { get; set; }
        // -------------------- Withdraw --------------------
        MultiTraderCreditProviderBeginWithdrawResponse BeginWithdraw(MultiTraderCreditProviderBeginWithdrawRequest request);
        Task<MultiTraderCreditProviderBeginWithdrawResponse> BeginWithdrawAsync(MultiTraderCreditProviderBeginWithdrawRequest request, CancellationToken cancellation);
        MultiTraderCreditProviderEndWithdrawResponse EndWithdraw(MultiTraderCreditProviderEndWithdrawRequest request);
        Task<MultiTraderCreditProviderEndWithdrawResponse> EndWithdrawAsync(MultiTraderCreditProviderEndWithdrawRequest request, CancellationToken cancellation);
        MultiTraderCreditProviderWithdrawResponse Withdraw(MultiTraderCreditProviderWithdrawRequest request);
        Task<MultiTraderCreditProviderWithdrawResponse> WithdrawAsync(MultiTraderCreditProviderWithdrawRequest request, CancellationToken cancellation);
        // -------------------- Deposit --------------------
        MultiTraderCreditProviderBeginDepositResponse BeginDeposit(MultiTraderCreditProviderBeginDepositRequest request);
        Task<MultiTraderCreditProviderBeginDepositResponse> BeginDepositAsync(MultiTraderCreditProviderBeginDepositRequest request, CancellationToken cancellation);
        MultiTraderCreditProviderEndDepositResponse EndDeposit(MultiTraderCreditProviderEndDepositRequest request);
        Task<MultiTraderCreditProviderEndDepositResponse> EndDepositAsync(MultiTraderCreditProviderEndDepositRequest request, CancellationToken cancellation);
        MultiTraderCreditProviderDepositResponse Deposit(MultiTraderCreditProviderDepositRequest request);
        Task<MultiTraderCreditProviderDepositResponse> DepositAsync(MultiTraderCreditProviderDepositRequest request, CancellationToken cancellation);
        // -------------------- Transfer --------------------
        MultiTraderCreditProviderBeginTransferResponse BeginTransfer(MultiTraderCreditProviderBeginTransferRequest request);
        Task<MultiTraderCreditProviderBeginTransferResponse> BeginTransferAsync(MultiTraderCreditProviderBeginTransferRequest request, CancellationToken cancellation);
        MultiTraderCreditProviderEndTransferResponse EndTransfer(MultiTraderCreditProviderEndTransferRequest request);
        Task<MultiTraderCreditProviderEndTransferResponse> EndTransferAsync(MultiTraderCreditProviderEndTransferRequest request, CancellationToken cancellation);
        MultiTraderCreditProviderTransferResponse Transfer(MultiTraderCreditProviderTransferRequest request);
        Task<MultiTraderCreditProviderTransferResponse> TransferAsync(MultiTraderCreditProviderTransferRequest request, CancellationToken cancellation);
    }
    public class MultiTraderCreditProvider : IMultiTraderCreditProvider
    {
        public IDbHelper Db { get; set; }
        public IAuditor Auditor { get; set; }
        public MultiTraderCreditProviderConfig Config { get; set; }
        public MultiTraderCreditProvider(MultiTraderCreditProviderConfig config, IDbHelper db, IAuditor auditor)
        {
            Db = db;
            Auditor = auditor;
            Config = config;
        }
        private MultiTraderCreditProviderApplyResponse Apply(MultiTraderCreditProviderApplyRequest request)
        {
            var response = new MultiTraderCreditProviderApplyResponse();
            var args = new
            {
                Result = CommandParameter.Output(System.Data.SqlDbType.VarChar, 80),
                TraderKey = request.TraderKey,
                UserName = request.UserName,
                Amount = request.Amount,
                Info = request.Info
            };
            var dbr = Db.ExecuteNonQuery("usp1_CreditTransaction_apply", args);
            if (dbr.Success)
            {
                response.Status = args.Result.Value?.ToString();
                var ar = Auditor.Audit(request.AuditCode, $"{{tk:{request.TraderKey},u:{request.UserName},m:{request.Amount}}}");
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
        private async Task<MultiTraderCreditProviderApplyResponse> ApplyAsync(MultiTraderCreditProviderApplyRequest request, CancellationToken cancellation)
        {
            var response = new MultiTraderCreditProviderApplyResponse();
            var args = new
            {
                Result = CommandParameter.Output(System.Data.SqlDbType.VarChar, 80),
                TraderKey = request.TraderKey,
                UserName = request.UserName,
                Amount = request.Amount,
                Info = request.Info
            };
            var dbr = await Db.ExecuteNonQueryAsync("usp1_CreditTransaction_apply", args, cancellation);
            if (dbr.Success)
            {
                response.Status = args.Result.Value?.ToString();
                var ar = await Auditor.AuditAsync(request.AuditCode, $"{{tk:{request.TraderKey},u:{request.UserName},m:{request.Amount}}}");
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
        private MultiTraderCreditProviderBeginApplyResponse BeginApply(MultiTraderCreditProviderBeginApplyRequest request)
        {
            var response = new MultiTraderCreditProviderBeginApplyResponse();
            var args = new
            {
                Result = CommandParameter.Output(System.Data.SqlDbType.VarChar, 80),
                Key = CommandParameter.Output(System.Data.SqlDbType.VarChar, 50),
                TraderKey = request.TraderKey,
                UserName = request.UserName,
                Amount = request.Amount,
                Info = request.Info
            };
            var dbr = Db.ExecuteNonQuery("usp1_CreditTransaction_begin_apply", args);
            if (dbr.Success)
            {
                response.Status = args.Result.Value?.ToString();
                var ar = Auditor.Audit(request.AuditCode, $"{{tk:{request.TraderKey},u:{request.UserName},m:{request.Amount}}}");
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
        private async Task<MultiTraderCreditProviderBeginApplyResponse> BeginApplyAsync(MultiTraderCreditProviderBeginApplyRequest request, CancellationToken cancellation)
        {
            var response = new MultiTraderCreditProviderBeginApplyResponse();
            var args = new
            {
                Result = CommandParameter.Output(System.Data.SqlDbType.VarChar, 50),
                Key = CommandParameter.Output(System.Data.SqlDbType.VarChar, 50),
                TraderKey = request.TraderKey,
                UserName = request.UserName,
                Amount = request.Amount,
                Info = request.Info
            };
            var dbr = await Db.ExecuteNonQueryAsync("usp1_CreditTransaction_begin_apply", args, cancellation);
            if (dbr.Success)
            {
                response.Status = args.Result.Value?.ToString();
                var ar = await Auditor.AuditAsync(request.AuditCode, $"{{tk:{request.TraderKey},u:{request.UserName},m:{request.Amount}}}");

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
        private MultiTraderCreditProviderEndApplyResponse EndApply(MultiTraderCreditProviderEndApplyRequest request)
        {
            var response = new MultiTraderCreditProviderEndApplyResponse();
            var args = new
            {
                Result = CommandParameter.Output(System.Data.SqlDbType.VarChar, 80),
                TraderKey = request.TraderKey,
                TransactionKey = request.TransactionKey
            };
            var dbr = Db.ExecuteNonQuery("usp1_CreditTransaction_end_apply", args);
            if (dbr.Success)
            {
                response.Status = args.Result.Value?.ToString();
                var ar = Auditor.Audit(request.AuditCode, $"{{tk:{request.TraderKey},trnk:{request.TransactionKey}}}");
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
        private async Task<MultiTraderCreditProviderEndApplyResponse> EndApplyAsync(MultiTraderCreditProviderEndApplyRequest request, CancellationToken cancellation)
        {
            var response = new MultiTraderCreditProviderEndApplyResponse();
            var args = new
            {
                Result = CommandParameter.Output(System.Data.SqlDbType.VarChar, 50),
                Key = CommandParameter.Output(System.Data.SqlDbType.VarChar, 50),
                TraderKey = request.TraderKey,
                TransactionKey = request.TransactionKey
            };
            var dbr = await Db.ExecuteNonQueryAsync("usp1_CreditTransaction_end_apply", args, cancellation);
            if (dbr.Success)
            {
                response.Status = args.Result.Value?.ToString();
                var ar = await Auditor.AuditAsync(request.AuditCode, $"{{tk:{request.TraderKey},trnk:{request.TransactionKey}}}");

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
        public MultiTraderCreditProviderBeginWithdrawResponse BeginWithdraw(MultiTraderCreditProviderBeginWithdrawRequest request)
        {
            var response = new MultiTraderCreditProviderBeginWithdrawResponse();
            var sr = BeginApply(new MultiTraderCreditProviderBeginApplyRequest
            {
                TraderKey = request.TraderKey,
                UserName = request.UserName,
                Amount = -request.Amount,
                Info = request.Info,
                AuditCode = "CRD_BGNWTHDRW"
            });

            response.Copy(sr);

            return response;
        }
        public async Task<MultiTraderCreditProviderBeginWithdrawResponse> BeginWithdrawAsync(MultiTraderCreditProviderBeginWithdrawRequest request, CancellationToken cancellation)
        {
            var response = new MultiTraderCreditProviderBeginWithdrawResponse();
            var sr = await BeginApplyAsync(new MultiTraderCreditProviderBeginApplyRequest
            {
                TraderKey = request.TraderKey,
                UserName = request.UserName,
                Amount = -request.Amount,
                Info = request.Info,
                AuditCode = "CRD_BGNWTHDRW"
            }, cancellation);

            response.Copy(sr);

            return response;
        }
        public MultiTraderCreditProviderEndWithdrawResponse EndWithdraw(MultiTraderCreditProviderEndWithdrawRequest request)
        {
            var response = new MultiTraderCreditProviderEndWithdrawResponse();
            var sr = EndApply(new MultiTraderCreditProviderEndApplyRequest
            {
                TraderKey = request.TraderKey,
                TransactionKey = request.TransactionKey,
                AuditCode = "CRD_ENDWTHDRW"
            });

            response.Copy(sr);

            return response;
        }
        public async Task<MultiTraderCreditProviderEndWithdrawResponse> EndWithdrawAsync(MultiTraderCreditProviderEndWithdrawRequest request, CancellationToken cancellation)
        {
            var response = new MultiTraderCreditProviderEndWithdrawResponse();
            var sr = await EndApplyAsync(new MultiTraderCreditProviderEndApplyRequest
            {
                TraderKey = request.TraderKey,
                TransactionKey = request.TransactionKey,
                AuditCode = "CRD_ENDWTHDRW"
            }, cancellation);

            response.Copy(sr);

            return response;
        }
        public MultiTraderCreditProviderWithdrawResponse Withdraw(MultiTraderCreditProviderWithdrawRequest request)
        {
            var response = new MultiTraderCreditProviderWithdrawResponse();
            var sr = Apply(new MultiTraderCreditProviderApplyRequest
            {
                TraderKey = request.TraderKey,
                UserName = request.UserName,
                Amount = -request.Amount,
                Info = request.Info,
                AuditCode = "CRD_WTHDRW"
            });

            response.Copy(sr);

            return response;
        }
        public async Task<MultiTraderCreditProviderWithdrawResponse> WithdrawAsync(MultiTraderCreditProviderWithdrawRequest request, CancellationToken cancellation)
        {
            var response = new MultiTraderCreditProviderWithdrawResponse();
            var sr = await ApplyAsync(new MultiTraderCreditProviderApplyRequest
            {
                TraderKey = request.TraderKey,
                UserName = request.UserName,
                Amount = -request.Amount,
                Info = request.Info,
                AuditCode = "CRD_WTHDRW"
            }, cancellation);

            response.Copy(sr);

            return response;
        }
        // -------------------------- Deposit --------------------------
        public MultiTraderCreditProviderBeginDepositResponse BeginDeposit(MultiTraderCreditProviderBeginDepositRequest request)
        {
            var response = new MultiTraderCreditProviderBeginDepositResponse();
            var sr = BeginApply(new MultiTraderCreditProviderBeginApplyRequest
            {
                TraderKey = request.TraderKey,
                UserName = request.UserName,
                Amount = request.Amount,
                Info = request.Info,
                AuditCode = "CRD_BGNDPST"
            });

            response.Copy(sr);

            return response;
        }
        public async Task<MultiTraderCreditProviderBeginDepositResponse> BeginDepositAsync(MultiTraderCreditProviderBeginDepositRequest request, CancellationToken cancellation)
        {
            var response = new MultiTraderCreditProviderBeginDepositResponse();
            var sr = await BeginApplyAsync(new MultiTraderCreditProviderBeginApplyRequest
            {
                TraderKey = request.TraderKey,
                UserName = request.UserName,
                Amount = request.Amount,
                Info = request.Info,
                AuditCode = "CRD_BGNDPST"
            }, cancellation);

            response.Copy(sr);

            return response;
        }
        public MultiTraderCreditProviderEndDepositResponse EndDeposit(MultiTraderCreditProviderEndDepositRequest request)
        {
            var response = new MultiTraderCreditProviderEndDepositResponse();
            var sr = EndApply(new MultiTraderCreditProviderEndApplyRequest
            {
                TraderKey = request.TraderKey,
                TransactionKey = request.TransactionKey,
                AuditCode = "CRD_ENDDPST"
            });

            response.Copy(sr);

            return response;
        }
        public async Task<MultiTraderCreditProviderEndDepositResponse> EndDepositAsync(MultiTraderCreditProviderEndDepositRequest request, CancellationToken cancellation)
        {
            var response = new MultiTraderCreditProviderEndDepositResponse();
            var sr = await EndApplyAsync(new MultiTraderCreditProviderEndApplyRequest
            {
                TraderKey = request.TraderKey,
                TransactionKey = request.TransactionKey,
                AuditCode = "CRD_ENDDPST"
            }, cancellation);

            response.Copy(sr);

            return response;
        }
        public MultiTraderCreditProviderDepositResponse Deposit(MultiTraderCreditProviderDepositRequest request)
        {
            var response = new MultiTraderCreditProviderDepositResponse();
            var sr = Apply(new MultiTraderCreditProviderApplyRequest
            {
                TraderKey = request.TraderKey,
                UserName = request.UserName,
                Amount = request.Amount,
                Info = request.Info,
                AuditCode = "CRD_DPST"
            });

            response.Copy(sr);

            return response;
        }
        public async Task<MultiTraderCreditProviderDepositResponse> DepositAsync(MultiTraderCreditProviderDepositRequest request, CancellationToken cancellation)
        {
            var response = new MultiTraderCreditProviderDepositResponse();
            var sr = await ApplyAsync(new MultiTraderCreditProviderApplyRequest
            {
                TraderKey = request.TraderKey,
                UserName = request.UserName,
                Amount = request.Amount,
                Info = request.Info,
                AuditCode = "CRD_DPST"
            }, cancellation);

            response.Copy(sr);

            return response;
        }
        // -------------------------- Transfer --------------------------
        public MultiTraderCreditProviderTransferResponse Transfer(MultiTraderCreditProviderTransferRequest request)
        {
            var response = new MultiTraderCreditProviderTransferResponse();
            var args = new
            {
                Result = CommandParameter.Output(System.Data.SqlDbType.VarChar, 80),
                TraderKey = request.TraderKey,
                request.FromUserName,
                request.ToUserName,
                request.Amount,
                request.FromInfo,
                request.ToInfo
            };
            var dbr = Db.ExecuteNonQuery("usp1_CreditTransaction_transfer", args);
            if (dbr.Success)
            {
                response.Status = args.Result.Value?.ToString();
                var ar = Auditor.Audit("CRD_TRNSFR", $"{{tk:{request.TraderKey},fu:{request.FromUserName},tu:{request.ToUserName},m:{request.Amount}}}");
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
        public async Task<MultiTraderCreditProviderTransferResponse> TransferAsync(MultiTraderCreditProviderTransferRequest request, CancellationToken cancellation)
        {
            var response = new MultiTraderCreditProviderTransferResponse();
            var args = new
            {
                Result = CommandParameter.Output(System.Data.SqlDbType.VarChar, 80),
                TraderKey = request.TraderKey,
                request.FromUserName,
                request.ToUserName,
                request.Amount,
                request.FromInfo,
                request.ToInfo
            };
            var dbr = await Db.ExecuteNonQueryAsync("usp1_CreditTransaction_transfer", args, cancellation);
            if (dbr.Success)
            {
                response.Status = args.Result.Value?.ToString();
                var ar = await Auditor.AuditAsync("CRD_TRNSFR", $"{{tk:{request.TraderKey},fu:{request.FromUserName},tu:{request.ToUserName},m:{request.Amount}}}");
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
        public MultiTraderCreditProviderBeginTransferResponse BeginTransfer(MultiTraderCreditProviderBeginTransferRequest request)
        {
            var response = new MultiTraderCreditProviderBeginTransferResponse();
            var args = new
            {
                Result = CommandParameter.Output(System.Data.SqlDbType.VarChar, 80),
                Key = CommandParameter.Output(System.Data.SqlDbType.VarChar, 50),
                TraderKey = request.TraderKey,
                request.FromUserName,
                request.ToUserName,
                request.Amount,
                request.FromInfo,
                request.ToInfo
            };
            var dbr = Db.ExecuteNonQuery("usp1_CreditTransaction_begin_transfer", args);
            if (dbr.Success)
            {
                response.Status = args.Result.Value?.ToString();
                var ar = Auditor.Audit("CRD_BGNTRNSFR", $"{{tk:{request.TraderKey},fu:{request.FromUserName},tu:{request.ToUserName},m:{request.Amount}}}");
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
        public async Task<MultiTraderCreditProviderBeginTransferResponse> BeginTransferAsync(MultiTraderCreditProviderBeginTransferRequest request, CancellationToken cancellation)
        {
            var response = new MultiTraderCreditProviderBeginTransferResponse();
            var args = new
            {
                Result = CommandParameter.Output(System.Data.SqlDbType.VarChar, 50),
                Key = CommandParameter.Output(System.Data.SqlDbType.VarChar, 50),
                TraderKey = request.TraderKey,
                request.FromUserName,
                request.ToUserName,
                request.Amount,
                request.FromInfo,
                request.ToInfo
            };
            var dbr = await Db.ExecuteNonQueryAsync("usp1_CreditTransaction_begin_transfer", args, cancellation);
            if (dbr.Success)
            {
                response.Status = args.Result.Value?.ToString();
                var ar = await Auditor.AuditAsync("CRD_BGNTRNSFR", $"{{tk:{request.TraderKey},fu:{request.FromUserName},tu:{request.ToUserName},m:{request.Amount}}}");

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
        public MultiTraderCreditProviderEndTransferResponse EndTransfer(MultiTraderCreditProviderEndTransferRequest request)
        {
            var response = new MultiTraderCreditProviderEndTransferResponse();
            var args = new
            {
                Result = CommandParameter.Output(System.Data.SqlDbType.VarChar, 80),
                TraderKey = request.TraderKey,
                TransactionKey = request.TransactionKey
            };
            var dbr = Db.ExecuteNonQuery("usp1_CreditTransaction_end_transfer", args);
            if (dbr.Success)
            {
                response.Status = args.Result.Value?.ToString();
                var ar = Auditor.Audit("CRD_ENDTRNSFR", $"{{tk:{request.TraderKey},trnk:{request.TransactionKey}}}");
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
        public async Task<MultiTraderCreditProviderEndTransferResponse> EndTransferAsync(MultiTraderCreditProviderEndTransferRequest request, CancellationToken cancellation)
        {
            var response = new MultiTraderCreditProviderEndTransferResponse();
            var args = new
            {
                Result = CommandParameter.Output(System.Data.SqlDbType.VarChar, 50),
                Key = CommandParameter.Output(System.Data.SqlDbType.VarChar, 50),
                TraderKey = request.TraderKey,
                TransactionKey = request.TransactionKey
            };
            var dbr = await Db.ExecuteNonQueryAsync("usp1_CreditTransaction_end_transfer", args, cancellation);
            if (dbr.Success)
            {
                response.Status = args.Result.Value?.ToString();
                var ar = await Auditor.AuditAsync("CRD_ENDTRNSFR", $"{{tk:{request.TraderKey},trnk:{request.TransactionKey}}}");

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
