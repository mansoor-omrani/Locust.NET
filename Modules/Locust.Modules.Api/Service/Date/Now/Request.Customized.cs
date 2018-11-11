using System.Data;
using Locust.Data;
using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class DateNowRequest : IBaseServiceRequest
    {
        public string Calendar { get; set; }
        public CommandParameter Now { get; set; }

        public DateNowRequest()
        {
            Now = CommandParameter.Output(SqlDbType.DateTime);
        }
    }
}