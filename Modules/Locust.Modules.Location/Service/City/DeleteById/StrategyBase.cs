using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Location.Model;

namespace Locust.Modules.Location.Strategies
{
	public abstract partial class CityDeleteByIdStrategyBase : BabbageDataManipulationStrategy<CityDeleteByIdResponse, object, CityDeleteByIdStatus, CityDeleteByIdRequest, CityDeleteByIdContext>
    {
		

		public CityDeleteByIdStrategyBase ()
		{
			
			Init();
		}

    }
}