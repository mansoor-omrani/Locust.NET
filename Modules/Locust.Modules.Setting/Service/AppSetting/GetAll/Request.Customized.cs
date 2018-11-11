using Locust.ServiceModel;

namespace Locust.Modules.Setting.Strategies
{
	public partial class AppSettingGetAllRequest : IBaseServiceRequest
    {
        public int AppId { get; set; }
    }
}