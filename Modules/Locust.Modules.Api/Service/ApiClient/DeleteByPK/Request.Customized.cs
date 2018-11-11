using System.Data;
using Locust.Data;
using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientDeleteByPKRequest : IBaseServiceRequest
    {
        public int Id { get; set; }
        public CommandParameter ClientKey { get; set; }

        public ApiClientDeleteByPKRequest()
        {
            ClientKey = CommandParameter.Output(SqlDbType.UniqueIdentifier);
        }
    }
}