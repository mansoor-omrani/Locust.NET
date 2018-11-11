using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiSettingUpdateResponse : BaseServiceResponse<object, ApiSettingUpdateStatus>
    {
        public int ApiId { get; set; }
    }
}