using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Location.Model.City;

namespace Locust.Modules.Location.Strategies
{
	public abstract partial class CityGetAllByStateStrategyBase : BabbagePageFetcherStrategy<CityGetAllByStateResponse, CityGetAllByStateStatus, CityGetAllByStateRequest, CityGetAllByStateContext, CityByState>
    {
		protected void Init()
		{
		}

    }
}