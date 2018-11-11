using Locust.ServiceModel;

namespace Locust.Modules.Location.Strategies
{
	public partial class CityGetByIdRequest : IBaseServiceRequest
    {
        public int cityid { get; set; }
    }
}