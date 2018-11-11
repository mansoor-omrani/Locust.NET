using Locust.ServiceModel;

namespace Locust.Modules.Location.Strategies
{
	public partial class CountryDeleteByIdRequest : IBaseServiceRequest
    {
        public int CountryId { get; set; }
    }
}