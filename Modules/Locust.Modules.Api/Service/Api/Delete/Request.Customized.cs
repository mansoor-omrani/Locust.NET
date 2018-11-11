using System.Data;
using Locust.Data;
using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiDeleteRequest : IBaseServiceRequest
    {
        public int Id { get; set; }
        public CommandParameter AppId { get; set; }
        public CommandParameter Path { get; set; }
        public ApiDeleteRequest()
        {
            AppId = CommandParameter.Output(SqlDbType.Int);
            Path = CommandParameter.Output(SqlDbType.VarChar, 100);
        }
    }
}