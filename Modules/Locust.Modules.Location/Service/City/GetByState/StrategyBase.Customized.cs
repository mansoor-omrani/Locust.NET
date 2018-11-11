using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Location.Model.City;

namespace Locust.Modules.Location.Strategies
{
	public abstract partial class CityGetByStateStrategyBase : BabbageListFetcherStrategy<CityGetByStateResponse, CityGetByStateStatus, CityGetByStateRequest, CityGetByStateContext, City>
    {
		protected void Init()
		{
		}

    }
}