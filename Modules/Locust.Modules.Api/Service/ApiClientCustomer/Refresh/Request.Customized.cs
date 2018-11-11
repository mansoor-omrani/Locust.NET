using System.Data;
using Locust.Data;
using Locust.Modules.Api.Service.ApiEngine;
using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerRefreshRequest : ApiBaseRequest
    {
        public string RefreshToken { get; set; }
        public CommandOutputParameter NewAccessToken { get; set; }
        public CommandOutputParameter NewRefreshToken { get; set; }
        public CommandOutputParameter NewEncryptionCode { get; set; }
        public ApiClientCustomerRefreshRequest()
        {
            NewAccessToken = CommandParameter.Output(SqlDbType.UniqueIdentifier) as CommandOutputParameter;
            NewRefreshToken = CommandParameter.Output(SqlDbType.UniqueIdentifier) as CommandOutputParameter;
            NewEncryptionCode = CommandParameter.Output(SqlDbType.VarChar, 16) as CommandOutputParameter;
        }
    }
}