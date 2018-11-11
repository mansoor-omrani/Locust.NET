using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Location.Model;

namespace Locust.Modules.Location.Strategies
{
	public abstract partial class StateDeleteByIdStrategyBase : BabbageDataManipulationStrategy<StateDeleteByIdResponse, object, StateDeleteByIdStatus, StateDeleteByIdRequest, StateDeleteByIdContext>
    {
		protected void Init()
		{
		}
    }
}