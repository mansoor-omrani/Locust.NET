using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Location.Model;

namespace Locust.Modules.Location.Strategies
{
	public abstract partial class StateAddStrategyBase : BabbageDataManipulationStrategy<StateAddResponse, object, StateAddStatus, StateAddRequest, StateAddContext>
    {
		

		public StateAddStrategyBase ()
		{
			
			Init();
		}

    }
}