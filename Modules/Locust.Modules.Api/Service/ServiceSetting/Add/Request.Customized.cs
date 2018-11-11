using System.Data;
using Locust.Data;
using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ServiceSettingAddRequest : IBaseServiceRequest
    {
        public CommandParameter Id { get; set; }
        public string Service { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public ServiceSettingAddRequest()
        {
            Id = CommandParameter.Output(SqlDbType.Int);
        }
    }
}