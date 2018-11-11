using System.Data;
using Locust.Data;
using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiSettingUpdateRequest : IBaseServiceRequest
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public CommandParameter ApiId { get; set; }

        public ApiSettingUpdateRequest()
        {
            ApiId = CommandParameter.Output(SqlDbType.Int);
        }
    }
}