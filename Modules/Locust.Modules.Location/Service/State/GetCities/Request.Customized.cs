using Locust.ServiceModel;

namespace Locust.Modules.Location.Strategies
{
	public partial class StateGetCitiesRequest : IBaseServiceRequest
    {
        public int StateId { get; set; }
    }
}