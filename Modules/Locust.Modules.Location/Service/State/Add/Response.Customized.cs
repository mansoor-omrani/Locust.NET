using Locust.ServiceModel;
using Locust.Modules.Location.Model;
namespace Locust.Modules.Location.Strategies
{
	public partial class StateAddResponse : BaseServiceResponse<object, StateAddStatus>
    {
        public int StateId { get; set; }
    }
}