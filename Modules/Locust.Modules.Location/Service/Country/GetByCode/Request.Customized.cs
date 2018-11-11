using Locust.ServiceModel;

namespace Locust.Modules.Location.Strategies
{
	public partial class CountryGetByCodeRequest : IBaseServiceRequest
    {
        public string Code { get; set; }
    }
}