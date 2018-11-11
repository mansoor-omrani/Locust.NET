using System.Collections.Generic;
using Locust.ServiceModel;
using Locust.Modules.Location.Model.City;
using Locust.ServiceModel.Babbage;

namespace Locust.Modules.Location.Strategies
{
	public class CityGetByStateContext : BabbageContext<CityGetByStateResponse, IList<City>, CityGetByStateStatus, CityGetByStateRequest>
    {
    }
}