using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Location.Model;

namespace Locust.Modules.Location.Strategies
{
	public abstract partial class CityUpdateStrategyBase : BabbageDataManipulationStrategy<CityUpdateResponse, object, CityUpdateStatus, CityUpdateRequest, CityUpdateContext>
    {
		protected void Init()
		{
		}
    }
}