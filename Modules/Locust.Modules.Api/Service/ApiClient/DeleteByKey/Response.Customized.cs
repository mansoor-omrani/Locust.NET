using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientDeleteByKeyResponse : BaseServiceResponse<object, ApiClientDeleteByKeyStatus>
    {
        public int Id { get; set; }
    }
}