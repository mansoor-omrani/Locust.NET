using System.Collections.Generic;
using Locust.ServiceModel;
using ResponseType = Locust.Modules.Location.Model.Country.Full;

namespace Locust.Modules.Location.Strategies
{
	public partial class CountryGetAllResponse : BaseServiceListResponse<ResponseType, CountryGetAllStatus>
    {
    }
}