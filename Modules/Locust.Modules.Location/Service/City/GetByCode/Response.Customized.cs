using Locust.ServiceModel;
using ResponseType = Locust.Modules.Location.Model.City.City;
namespace Locust.Modules.Location.Strategies
{
	public partial class CityGetByCodeResponse : BaseServiceResponse<ResponseType, CityGetByCodeStatus>
    {
    }
}