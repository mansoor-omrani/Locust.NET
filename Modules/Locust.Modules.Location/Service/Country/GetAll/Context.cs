using System.Collections.Generic;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using ResponseType = Locust.Modules.Location.Model.Country.Full;

namespace Locust.Modules.Location.Strategies
{
	public class CountryGetAllContext : BabbageContext<CountryGetAllResponse, IList<ResponseType>, CountryGetAllStatus, CountryGetAllRequest>
    {
    }
}