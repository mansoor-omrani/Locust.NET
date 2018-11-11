using System.Data;
using Locust.Data;
using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientDeleteByKeyRequest : IBaseServiceRequest
    {
        public string ClientKey { get; set; }
        public CommandParameter Id { get; set; }

        public ApiClientDeleteByKeyRequest()
        {
            //ClientKey = CommandParameter.Guid("");
            Id = CommandParameter.Output(SqlDbType.Int);
        }
    }
}