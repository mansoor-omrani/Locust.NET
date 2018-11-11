using Locust.ServiceModel;

namespace Locust.Modules.Location.Strategies
{
	public partial class StateDeleteByIdRequest : IBaseServiceRequest
    {
        public int StateId { get; set; }
    }
}