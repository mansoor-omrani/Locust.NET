using Locust.ServiceModel;
using Locust.Modules.Location.Model;
using Locust.ServiceModel.Babbage;

namespace Locust.Modules.Location.Strategies
{
	public class StateUpdateContext : BabbageContext<StateUpdateResponse, object, StateUpdateStatus, StateUpdateRequest>
    {
    }
}