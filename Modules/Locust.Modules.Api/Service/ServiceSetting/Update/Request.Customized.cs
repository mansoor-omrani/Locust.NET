using System.Data;
using Locust.Data;
using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ServiceSettingUpdateRequest : IBaseServiceRequest
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public CommandParameter Service { get; set; }

        public ServiceSettingUpdateRequest()
        {
            Service = CommandParameter.Output(SqlDbType.VarChar, 50);
        }
    }
}