using System.Data;
using Locust.Data;
using Locust.ServiceModel;

namespace Locust.Modules.Base.Strategies
{
	public partial class ApplicationDeleteRequest : IBaseServiceRequest
    {
        public int Id { get; set; }
        public CommandParameter ShortName { get; set; }

        public ApplicationDeleteRequest()
        {
            ShortName = CommandParameter.Output(SqlDbType.VarChar, 20);
        }
    }
}