using Locust.ServiceModel;

namespace Locust.Modules.Location.Strategies
{
	public partial class CityDeleteByIdRequest : IBaseServiceRequest
    {
        public int cityid { get; set; }
    }
}