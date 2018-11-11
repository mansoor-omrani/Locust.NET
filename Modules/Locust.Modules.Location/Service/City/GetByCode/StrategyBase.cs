using Locust.ServiceModel.Babbage;
using ResponseType = Locust.Modules.Location.Model.City.City;

namespace Locust.Modules.Location.Strategies
{
	public abstract partial class CityGetByCodeStrategyBase : BabbageItemFetcherStrategy<CityGetByCodeResponse, ResponseType, CityGetByCodeStatus, CityGetByCodeRequest, CityGetByCodeContext>
    {
		

		public CityGetByCodeStrategyBase ()
		{
			
			Init();
		}

    }
}