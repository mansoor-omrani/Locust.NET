using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using ResponseType = Locust.Modules.Location.Model.State.Full;

namespace Locust.Modules.Location.Strategies
{
	public class StateGetByIdContext : BabbageContext<StateGetByIdResponse, ResponseType, StateGetByIdStatus, StateGetByIdRequest>
    {
    }
}