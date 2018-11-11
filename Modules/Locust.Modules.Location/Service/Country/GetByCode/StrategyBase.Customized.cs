using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using ResponseType = Locust.Modules.Location.Model.Country.Full;

namespace Locust.Modules.Location.Strategies
{
	public abstract partial class CountryGetByCodeStrategyBase : BabbageItemFetcherStrategy<CountryGetByCodeResponse, ResponseType, CountryGetByCodeStatus, CountryGetByCodeRequest, CountryGetByCodeContext>
    {
		protected void Init()
		{
		}
    }
}