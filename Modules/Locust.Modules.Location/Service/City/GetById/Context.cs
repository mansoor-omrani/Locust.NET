using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using ResponseType = Locust.Modules.Location.Model.City.City;

namespace Locust.Modules.Location.Strategies
{
	public class CityGetByIdContext : BabbageContext<CityGetByIdResponse, ResponseType, CityGetByIdStatus, CityGetByIdRequest>
    {
    }
}