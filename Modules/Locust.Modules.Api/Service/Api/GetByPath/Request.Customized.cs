using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiGetByPathRequest : IBaseServiceRequest
    {
        public int AppId { get; set; }
        public string Path { get; set; }
    }
}