using Locust.ServiceModel;

namespace Locust.Modules.Setting.Strategies
{
	public partial class AppSettingDeleteRequest : IBaseServiceRequest
    {
        public int Id { get; set; }
    }
}