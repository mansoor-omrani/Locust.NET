using System.Data;
using Locust.Data;
using Locust.Modules.Api.Service.ApiEngine;
using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerActivateRequest : ApiBaseRequest
    {
        // it seems that passing AppId is irrelevant
        //public int AppId { get; set; }
        public string HashCode { get; set; }
        public CommandOutputParameter ApiClientCustomerId { get; set; }
        public CommandOutputParameter OldAccessToken { get; set; }
        public CommandOutputParameter OldEncryptionCode { get; set; }
        public ApiClientCustomerActivateRequest()
        {
            ApiClientCustomerId = CommandParameter.Output(SqlDbType.Int) as CommandOutputParameter;
            OldAccessToken = CommandParameter.Output(SqlDbType.UniqueIdentifier) as CommandOutputParameter;
            OldEncryptionCode = CommandParameter.Output(SqlDbType.VarChar, 32) as CommandOutputParameter;
        }
    }
}