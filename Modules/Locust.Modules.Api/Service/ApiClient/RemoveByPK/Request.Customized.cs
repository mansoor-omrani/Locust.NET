using System.Data;
using Locust.Data;
using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientRemoveByPKRequest : IBaseServiceRequest
    {
        public int Id { get; set; }
        public CommandParameter ClientKey { get; set; }

        public ApiClientRemoveByPKRequest()
        {
            ClientKey = CommandParameter.Output(SqlDbType.UniqueIdentifier);
        }
    }
}