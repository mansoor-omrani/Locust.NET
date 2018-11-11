using Locust.ServiceModel.Babbage;
using ResponseType = Locust.Modules.Location.Model.City.City;

namespace Locust.Modules.Location.Strategies
{
	public abstract partial class CityGetByIdStrategyBase : BabbageItemFetcherStrategy<CityGetByIdResponse, ResponseType, CityGetByIdStatus, CityGetByIdRequest, CityGetByIdContext>
    {
		

		public CityGetByIdStrategyBase ()
		{
			
			Init();
		}

    }
}