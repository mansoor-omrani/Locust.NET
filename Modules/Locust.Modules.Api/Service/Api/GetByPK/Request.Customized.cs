using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiGetByPKRequest : IBaseServiceRequest
    {
        public int AppId { get; set; }
        public int Id { get; set; }
    }
}