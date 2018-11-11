using Locust.ServiceModel;

namespace Locust.Modules.Setting.Strategies
{
	public partial class AppSettingGetByKeyRequest : IBaseServiceRequest
    {
        public int AppId { get; set; }
        public string Key { get; set; }
    }
}