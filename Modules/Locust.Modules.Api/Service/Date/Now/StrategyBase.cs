using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class DateNowStrategyBase : BabbageDataManipulationStrategy<DateNowResponse, object, DateNowStatus, DateNowRequest, DateNowContext>
    {
		

		public DateNowStrategyBase ()
		{
			
			Init();
		}

    }
}