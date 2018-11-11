using System.Collections.Generic;
using Locust.ServiceModel;
using Locust.Modules.Location.Model.City;
using Locust.ServiceModel.Babbage;

namespace Locust.Modules.Location.Strategies
{
	public class CityGetAllContext : BabbageContext<CityGetAllResponse, IList<CityGetAllModel>, CityGetAllStatus, CityGetAllRequest>
    {
    }
}