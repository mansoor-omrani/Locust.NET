using Locust.Data;
using Locust.Db;
using Locust.Model;
using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientGetByKeyRequest : BaseModel, IBaseServiceRequest
    {
        public GuidCommandParameter ClientKey { get; private set; }

	    public ApiClientGetByKeyRequest()
	    {
	        ClientKey = new GuidCommandParameter("");
	    }
    }
}