using System.Collections.Generic;
using Locust.ServiceModel;
using Locust.Modules.Location.Model.City;
using Locust.ServiceModel.Babbage;

namespace Locust.Modules.Location.Strategies
{
	public class CityGetAllByStateContext : BabbageContext<CityGetAllByStateResponse, PageData<CityByState>, CityGetAllByStateStatus, CityGetAllByStateRequest>
    {
    }
}