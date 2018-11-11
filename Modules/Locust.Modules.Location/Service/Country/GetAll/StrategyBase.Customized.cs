using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using ResponseType = Locust.Modules.Location.Model.Country.Full;

namespace Locust.Modules.Location.Strategies
{
	public abstract partial class CountryGetAllStrategyBase : BabbageListFetcherStrategy<CountryGetAllResponse, CountryGetAllStatus, CountryGetAllRequest, CountryGetAllContext, ResponseType>
    {
		protected void Init()
		{
		}

    }
}