using System.Collections.Generic;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using ResponseType = Locust.Modules.Location.Model.City.CityState;

namespace Locust.Modules.Location.Strategies
{
	public class StateGetCitiesContext : BabbageContext<StateGetCitiesResponse, IList<ResponseType>, StateGetCitiesStatus, StateGetCitiesRequest>
    {
    }
}