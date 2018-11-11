using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Location.Model;

namespace Locust.Modules.Location.Strategies
{
	public abstract partial class CityAddStrategyBase : BabbageDataManipulationStrategy<CityAddResponse, object, CityAddStatus, CityAddRequest, CityAddContext>
    {
		

		public CityAddStrategyBase ()
		{
			
			Init();
		}

    }
}