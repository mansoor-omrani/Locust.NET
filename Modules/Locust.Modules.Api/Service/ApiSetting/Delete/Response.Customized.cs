using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiSettingDeleteResponse : BaseServiceResponse<object, ApiSettingDeleteStatus>
    {
        public int ApiId { get; set; }
    }
}