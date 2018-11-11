using System.Data;
using Locust.Data;
using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ServiceSettingDeleteRequest : IBaseServiceRequest
    {
        public int Id { get; set; }
        public CommandParameter Service { get; set; }

        public ServiceSettingDeleteRequest()
        {
            Service= CommandParameter.Output(SqlDbType.VarChar, 50);
        }
    }
}