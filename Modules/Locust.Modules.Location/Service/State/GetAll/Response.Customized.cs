using System.Collections.Generic;
using Locust.ServiceModel;
using ResponseType = Locust.Modules.Location.Model.State.Full;

namespace Locust.Modules.Location.Strategies
{
	public partial class StateGetAllResponse : BaseServiceListResponse<ResponseType, StateGetAllStatus>
    {
    }
}