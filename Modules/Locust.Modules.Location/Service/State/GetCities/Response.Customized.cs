using System.Collections.Generic;
using Locust.ServiceModel;
using ResponseType = Locust.Modules.Location.Model.City.CityState;

namespace Locust.Modules.Location.Strategies
{
	public partial class StateGetCitiesResponse : BaseServiceListResponse<ResponseType, StateGetCitiesStatus>
    {
    }
}