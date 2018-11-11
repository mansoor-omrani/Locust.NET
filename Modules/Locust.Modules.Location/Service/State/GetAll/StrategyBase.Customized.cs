using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using ResponseType = Locust.Modules.Location.Model.State.Full;

namespace Locust.Modules.Location.Strategies
{
	public abstract partial class StateGetAllStrategyBase : BabbageListFetcherStrategy<StateGetAllResponse, StateGetAllStatus, StateGetAllRequest, StateGetAllContext, ResponseType>
    {
		protected void Init()
		{
		}

    }
}