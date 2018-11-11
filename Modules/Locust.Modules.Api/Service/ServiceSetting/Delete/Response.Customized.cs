using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ServiceSettingDeleteResponse : BaseServiceResponse<object, ServiceSettingDeleteStatus>
    {
        public string Service { get; set; }
    }
}