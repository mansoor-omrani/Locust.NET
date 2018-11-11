using ResponseType = Locust.Modules.Location.Model.Country.Full;
using Locust.ServiceModel.Babbage;

namespace Locust.Modules.Location.Strategies
{
	public abstract partial class CountryGetByCodeStrategyBase : BabbageItemFetcherStrategy<CountryGetByCodeResponse, ResponseType, CountryGetByCodeStatus, CountryGetByCodeRequest, CountryGetByCodeContext>
    {
		public CountryGetByCodeStrategyBase ()
		{
			
			Init();
		}

    }
}