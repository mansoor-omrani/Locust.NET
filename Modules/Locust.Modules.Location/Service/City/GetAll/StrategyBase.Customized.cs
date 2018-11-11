using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Location.Model.City;

namespace Locust.Modules.Location.Strategies
{
	public abstract partial class CityGetAllStrategyBase : BabbageListFetcherStrategy<CityGetAllResponse, CityGetAllStatus, CityGetAllRequest, CityGetAllContext, CityGetAllModel>
    {
		protected void Init()
		{
		}

    }
}