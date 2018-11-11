using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Location.Model;

namespace Locust.Modules.Location.Strategies
{
	public abstract partial class CountryUpdateStrategyBase : BabbageDataManipulationStrategy<CountryUpdateResponse, object, CountryUpdateStatus, CountryUpdateRequest, CountryUpdateContext>
    {
		protected void Init()
		{
		}
    }
}