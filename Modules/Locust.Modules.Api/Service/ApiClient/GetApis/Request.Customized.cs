using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientGetApisRequest : IBaseServiceRequest
    {
        public int Id { get; set; }
    }
}