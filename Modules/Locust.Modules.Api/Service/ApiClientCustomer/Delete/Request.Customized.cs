using System.Data;
using Locust.Data;
using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerDeleteRequest : IBaseServiceRequest
    {
        public int Id { get; set; }
        public CommandParameter AccessToken { get; set; }

        public ApiClientCustomerDeleteRequest()
        {
            AccessToken = CommandParameter.Output(SqlDbType.UniqueIdentifier);
        }
    }
}