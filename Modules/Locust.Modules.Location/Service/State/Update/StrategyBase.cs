using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Location.Model;

namespace Locust.Modules.Location.Strategies
{
	public abstract partial class StateUpdateStrategyBase : BabbageDataManipulationStrategy<StateUpdateResponse, object, StateUpdateStatus, StateUpdateRequest, StateUpdateContext>
    {
		

		public StateUpdateStrategyBase ()
		{
			
			Init();
		}

    }
}