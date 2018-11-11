using Locust.ServiceModel.Babbage;
using ResponseType = Locust.Modules.Location.Model.State.Full;

namespace Locust.Modules.Location.Strategies
{
	public abstract partial class StateGetByCodeStrategyBase : BabbageItemFetcherStrategy<StateGetByCodeResponse, ResponseType, StateGetByCodeStatus, StateGetByCodeRequest, StateGetByCodeContext>
    {
		

		public StateGetByCodeStrategyBase ()
		{
			
			Init();
		}

    }
}