using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientDeleteByPKResponse : BaseServiceResponse<object, ApiClientDeleteByPKStatus>
    {
        public string ClientKey { get; set; }
    }
}