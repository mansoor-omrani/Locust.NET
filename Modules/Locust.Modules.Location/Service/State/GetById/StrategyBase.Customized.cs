using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using ResponseType = Locust.Modules.Location.Model.State.Full;

namespace Locust.Modules.Location.Strategies
{
	public abstract partial class StateGetByIdStrategyBase : BabbageItemFetcherStrategy<StateGetByIdResponse, ResponseType, StateGetByIdStatus, StateGetByIdRequest, StateGetByIdContext>
    {
		protected void Init()
		{
		}
    }
}