using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientRemoveByPKResponse : BaseServiceResponse<object, ApiClientRemoveByPKStatus>
    {
        public string ClientKey { get; set; }
    }
}