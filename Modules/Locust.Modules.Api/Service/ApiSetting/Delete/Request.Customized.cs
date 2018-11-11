using System.Data;
using Locust.Data;
using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiSettingDeleteRequest : IBaseServiceRequest
    {
        public int Id { get; set; }
        public CommandParameter ApiId { get; set; }

        public ApiSettingDeleteRequest()
        {
            ApiId = CommandParameter.Output(SqlDbType.Int);
        }
    }
}