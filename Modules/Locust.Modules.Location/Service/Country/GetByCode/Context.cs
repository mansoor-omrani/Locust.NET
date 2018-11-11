using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using ResponseType = Locust.Modules.Location.Model.Country.Full;

namespace Locust.Modules.Location.Strategies
{
	public class CountryGetByCodeContext : BabbageContext<CountryGetByCodeResponse, ResponseType, CountryGetByCodeStatus, CountryGetByCodeRequest>
    {
    }
}