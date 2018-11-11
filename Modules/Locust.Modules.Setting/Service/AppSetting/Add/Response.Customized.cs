using Locust.ServiceModel;

namespace Locust.Modules.Setting.Strategies
{
	public partial class AppSettingAddResponse : BaseServiceResponse<object, AppSettingAddStatus>
    {
        public int Id { get; set; }
    }
}