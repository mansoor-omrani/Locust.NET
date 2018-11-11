using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientAddResponse : BaseServiceResponse<int, ApiClientAddStatus>
    {
        public int Id { get; set; }
    }
}