using Locust.Conversion;
using Locust.Data;
using Locust.Db;
using Locust.Extensions;
using Locust.Service;
using Locust.WebExtensions;
using Locust.WebTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Auditing.Web
{
    public class DirectWebAuditor : IWebAuditor
    {
        internal class DirectWebAuditorSprocArgs
        {
            public CommandOutputParameter result { get; set; }
            public CommandInputOutputParameter args { get; set; }
            public int ApplicationID { get; set; }
            public string UserName { get; set; }
            public string RoleName { get; set; }
            public string Lang { get; set; }
            public int? RelatedRecordId { get; set; }
            public string BrowserName { get; set; }
            public string BrowserVersion { get; set; }
            public string Code { get; set; }
            public string SessionId { get; set; }
            public string AssignedCode { get; set; }
            public string IP { get; set; }
            public string Data { get; set; }
            public DirectWebAuditorSprocArgs()
            {
                result = new CommandOutputParameter(System.Data.SqlDbType.VarChar, 100);
                args = new CommandInputOutputParameter(System.Data.SqlDbType.NVarChar, 2000);
            }
        }
        public IHttpContextProvider HttpContextProvider { get; set; }
        public IDbHelper Db { get; set; }
        public DirectWebAuditor(IDbHelper db, IHttpContextProvider httpContextProvider)
        {
            this.Db = db;
            this.HttpContextProvider = httpContextProvider;
        }
        private WebAuditData GetWebAuditData(int applicationId, string lang, int? RelatedRecordId, string assignedCode, string code, string data)
        {
            HttpContextProvider.Capture();

            var httpContext = HttpContextProvider.Get();
            
            return new WebAuditData
            {
                ApplicationId = applicationId,
                UserName = httpContext.User.Identity.Name,
                RoleName = httpContext.User.Identity.GetRoleName(),
                Lang = (string.IsNullOrEmpty(lang) ? httpContext.Items["Lang"]?.ToString() : lang),
                RelatedRecordId = RelatedRecordId,
                IP = httpContext.Request.GetClientIpAddress(),
                BrowserName = httpContext.Request.Browser.Browser,
                BrowserVersion = httpContext.Request.Browser.Version,
                SessionId = httpContext.Session.SessionID,
                AssignedCode = assignedCode,
                Code = code,
                Data = data
            };
        }
        private DirectWebAuditorSprocArgs GetArgs(WebAuditData data)
        {
            return new DirectWebAuditorSprocArgs
            {
                ApplicationID = data.ApplicationId,
                UserName = data.UserName,
                RoleName = data.RoleName,
                Lang = data.Lang,
                RelatedRecordId = data.RelatedRecordId,
                BrowserName = data.BrowserName,
                BrowserVersion = data.BrowserVersion,
                Code = data.Code,
                SessionId = data.SessionId,
                AssignedCode = data.AssignedCode,
                IP = data.IP,
                Data = data.Data
            };
        }
        public ServiceResponse<string> Audit(BaseAuditData data)
        {
            return Audit((WebAuditData)data);
        }
        public ServiceResponse<string> Audit(string code, string data = "")
        {
            var auditData = GetWebAuditData(0, null, null, null, code, data);

            return Audit(auditData);
        }
        public virtual ServiceResponse<string> Audit(WebAuditData data)
        {
            var result = new ServiceResponse<string>();

            try
            {
                var cmd = Db.GetCommand("usp0_Audit_web_direct");
                var args = GetArgs(data);

                var dbr = Db.ExecuteNonQuery(cmd, args);

                result.Status = SafeClrConvert.ToString(args.result.Value);
                result.Data = SafeClrConvert.ToString(args.args.Value);
                result.Success = result.Status == "AuditSucceeded";
                result.Exception = dbr.Exception;
            }
            catch (Exception e)
            {
                result.Status = "AuditError";
                result.Exception = e;
            }

            return result;
        }
        public Task<ServiceResponse<string>> AuditAsync(BaseAuditData data)
        {
            return AuditAsync((WebAuditData)data);
        }
        public Task<ServiceResponse<string>> AuditAsync(string code, string data = "")
        {
            var auditData = GetWebAuditData(0, null, null, null, code, data);

            return AuditAsync(auditData);
        }
        public virtual async Task<ServiceResponse<string>> AuditAsync(WebAuditData data)
        {
            var result = new ServiceResponse<string>();

            try
            {
                var cmd = Db.GetCommand("usp0_Audit_web_direct");
                var args = GetArgs(data);

                await Db.ExecuteNonQueryAsync(cmd, args);

                result.Status = SafeClrConvert.ToString(args.result.Value);
                result.Data = SafeClrConvert.ToString(args.args.Value);
                result.Success = result.Status == "AuditSucceeded";
            }
            catch (Exception e)
            {
                result.Status = "AuditError";
                result.Exception = e;
            }

            return result;
        }
    }
}
