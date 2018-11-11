using Locust.ServiceModel;
using Locust.Modules.Location.Model;
using Locust.ServiceModel.Babbage;

namespace Locust.Modules.Location.Strategies
{
	public class CountryAddContext : BabbageContext<CountryAddResponse, object, CountryAddStatus, CountryAddRequest>
    {
    }
}