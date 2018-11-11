using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiUpdateResponse : BaseServiceResponse<object, ApiUpdateStatus>
    {
        public int AppId { get; set; }
        public string OldPath { get; set; }
    }
}