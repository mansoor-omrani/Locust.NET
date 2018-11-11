using System.Data;
using Locust.Data;
using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientRemoveByKeyRequest : IBaseServiceRequest
    {
        public string ClientKey { get; set; }
        public CommandParameter Id { get; set; }

        public ApiClientRemoveByKeyRequest()
        {
            //ClientKey = CommandParameter.Guid("");
            Id = CommandParameter.Output(SqlDbType.Int);
        }
    }
}