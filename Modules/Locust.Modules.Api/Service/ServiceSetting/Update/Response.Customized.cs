using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ServiceSettingUpdateResponse : BaseServiceResponse<object, ServiceSettingUpdateStatus>
    {
        public string Service { get; set; }
    }
}