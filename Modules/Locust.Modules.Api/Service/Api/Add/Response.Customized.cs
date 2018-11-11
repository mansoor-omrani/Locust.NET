using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiAddResponse : BaseServiceResponse<int, ApiAddStatus>
    {
        public int Id { get; set; }
    }
}