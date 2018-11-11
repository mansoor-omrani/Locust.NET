using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ServiceSettingAddResponse : BaseServiceResponse<object, ServiceSettingAddStatus>
    {
        public int Id { get; set; }
    }
}