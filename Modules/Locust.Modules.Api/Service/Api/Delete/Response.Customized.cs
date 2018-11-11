using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiDeleteResponse : BaseServiceResponse<object, ApiDeleteStatus>
    {
        public int AppId { get; set; }
        public string Path { get; set; }
    }
}