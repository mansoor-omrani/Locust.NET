using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ServiceSettingGetAllByServiceRequest : IBaseServiceRequest
    {
        public string Service { get; set; }
    }
}