using System.Data;
using Locust.Data;
using Locust.ServiceModel;

namespace Locust.Modules.Base.Strategies
{
	public partial class AppCrossOriginDeleteRequest : IBaseServiceRequest
    {
        public int Id { get; set; }
        public CommandParameter AppId { get; set; }

        public AppCrossOriginDeleteRequest()
        {
            AppId = CommandParameter.InputOutput(SqlDbType.Int);
        }
    }
}