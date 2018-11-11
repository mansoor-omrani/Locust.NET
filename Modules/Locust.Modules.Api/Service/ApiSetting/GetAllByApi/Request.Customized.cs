using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiSettingGetAllByApiRequest : IBaseServiceRequest
    {
        public int ApiId { get; set; }
    }
}