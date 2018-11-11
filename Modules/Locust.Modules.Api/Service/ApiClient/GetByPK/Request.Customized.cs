using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientGetByPKRequest : IBaseServiceRequest
    {
        public int Id { get; set; }
    }
}