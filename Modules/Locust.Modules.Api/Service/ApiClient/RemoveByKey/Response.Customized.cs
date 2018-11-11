using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientRemoveByKeyResponse : BaseServiceResponse<object, ApiClientRemoveByKeyStatus>
    {
        public int Id { get; set; }
    }
}