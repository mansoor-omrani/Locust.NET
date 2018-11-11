using Locust.ServiceModel;

namespace Locust.Modules.Setting.Strategies
{
	public partial class AppSettingGetByPKRequest : IBaseServiceRequest
    {
        public int AppSettingId { get; set; }
    }
}