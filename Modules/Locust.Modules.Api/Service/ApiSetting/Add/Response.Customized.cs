using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiSettingAddResponse : BaseServiceResponse<object, ApiSettingAddStatus>
    {
        public int Id { get; set; }
    }
}