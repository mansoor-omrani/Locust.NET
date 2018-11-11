using Locust.ServiceModel.Babbage;
using ResponseType = Locust.Modules.Location.Model.Country.Full;

namespace Locust.Modules.Location.Strategies
{
	public abstract partial class CountryGetByIdStrategyBase : BabbageItemFetcherStrategy<CountryGetByIdResponse, ResponseType, CountryGetByIdStatus, CountryGetByIdRequest, CountryGetByIdContext>
    {
		

		public CountryGetByIdStrategyBase ()
		{
			
			Init();
		}

    }
}