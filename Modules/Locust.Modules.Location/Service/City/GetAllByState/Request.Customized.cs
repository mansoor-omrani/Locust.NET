using System.Data;
using Locust.Data;
using Locust.ServiceModel;

namespace Locust.Modules.Location.Strategies
{
	public partial class CityGetAllByStateRequest : BaseServicePageRequest
    {
        public int StateId { get; set; }
    }
}