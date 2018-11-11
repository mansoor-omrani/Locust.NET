using Locust.ServiceModel;
using Locust.Modules.Setting.Model;
namespace Locust.Modules.Setting.Strategies
{
	public partial class AppSettingQuickAddResponse : BaseServiceResponse<object, AppSettingQuickAddStatus>
    {
        public int Id { get; set; }
    }
}