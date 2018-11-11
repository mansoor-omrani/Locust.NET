using Locust.ServiceModel;

namespace Locust.Modules.Setting.Strategies
{
	public partial class AppSettingCategoryGetAllRequest : IBaseServiceRequest
    {
        public int AppId { get; set; }
    }
}