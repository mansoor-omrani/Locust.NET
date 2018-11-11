using Locust.Modules.Api.Service;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiCheckAccessStrategyBase : BabbageDataManipulationStrategy<ApiCheckAccessResponse, object, ApiCheckAccessStatus, ApiCheckAccessRequest, ApiCheckAccessContext>
    {
        public ApiServiceBase Service
        {
            get { return Store.Service as ApiServiceBase; }
        }
        protected void Init()
		{
		}
    }
}