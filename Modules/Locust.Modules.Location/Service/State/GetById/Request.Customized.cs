using Locust.ServiceModel;

namespace Locust.Modules.Location.Strategies
{
	public partial class StateGetByIdRequest : IBaseServiceRequest
    {
        public int StateId { get; set; }
    }
}