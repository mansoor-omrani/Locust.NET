using Locust.ServiceModel;

namespace Locust.Modules.Location.Strategies
{
	public partial class CityGetByStateRequest : IBaseServiceRequest
    {
        public int stateid { get; set; }
    }
}