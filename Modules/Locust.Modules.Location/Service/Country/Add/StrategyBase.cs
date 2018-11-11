using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Location.Model;

namespace Locust.Modules.Location.Strategies
{
	public abstract partial class CountryAddStrategyBase : BabbageDataManipulationStrategy<CountryAddResponse, object, CountryAddStatus, CountryAddRequest, CountryAddContext>
    {
		

		public CountryAddStrategyBase ()
		{
			
			Init();
		}

    }
}