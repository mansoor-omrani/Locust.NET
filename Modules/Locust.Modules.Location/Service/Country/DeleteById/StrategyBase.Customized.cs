using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Location.Model;

namespace Locust.Modules.Location.Strategies
{
	public abstract partial class CountryDeleteByIdStrategyBase : BabbageDataManipulationStrategy<CountryDeleteByIdResponse, object, CountryDeleteByIdStatus, CountryDeleteByIdRequest, CountryDeleteByIdContext>
    {
		protected void Init()
		{
		}
    }
}