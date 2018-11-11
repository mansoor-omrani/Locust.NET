using Locust.ServiceModel;

namespace Locust.Modules.Location.Strategies
{
	public partial class CountryUpdateRequest : IBaseServiceRequest
    {
        public int CountryId { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }

    }
}