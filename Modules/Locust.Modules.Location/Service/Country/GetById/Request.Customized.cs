using Locust.ServiceModel;

namespace Locust.Modules.Location.Strategies
{
	public partial class CountryGetByIdRequest : IBaseServiceRequest
    {
        public int CountryId { get; set; }
    }
}