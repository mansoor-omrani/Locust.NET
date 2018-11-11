using Locust.ServiceModel.Babbage;
using ResponseType = Locust.Modules.Location.Model.City.CityState;

namespace Locust.Modules.Location.Strategies
{
	public abstract partial class StateGetCitiesStrategyBase : BabbageListFetcherStrategy<StateGetCitiesResponse, StateGetCitiesStatus, StateGetCitiesRequest, StateGetCitiesContext, ResponseType>
    {
		
		
		public StateGetCitiesStrategyBase ()
		{
			
			Init();
		}

    }
}