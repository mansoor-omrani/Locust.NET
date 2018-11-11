using System.Data;
using Locust.Data;
using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiSettingAddRequest : IBaseServiceRequest
    {
        public CommandParameter Id { get; set; }
        public int ApiId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public ApiSettingAddRequest()
        {
            Id = CommandParameter.Output(SqlDbType.Int);
        }
    }
}