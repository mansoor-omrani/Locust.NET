using System;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class DateNowResponse : BaseServiceResponse<object, DateNowStatus>
    {
        public DateTime Now { get; set; }
    }
}