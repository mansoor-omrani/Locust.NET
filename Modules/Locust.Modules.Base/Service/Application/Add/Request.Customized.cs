using System.Data;
using Locust.Data;
using Locust.ServiceModel;

namespace Locust.Modules.Base.Strategies
{
	public partial class ApplicationAddRequest : IBaseServiceRequest
    {
        public CommandParameter Id { get; set; }
        public bool AllowAnonymousHardwareRegistration { get; set; }
        public bool AllowAnonymousIPRegistration { get; set; }
        public bool RegisterBySerialNo { get; set; }
        public bool RequiresImmediateApiCall { get; set; }
        public bool IsActive { get; set; }
        public bool MultipleActivationRoutes { get; set; }
        public string Code { get; set; }
        public string Version { get; set; }
        public string Host { get; set; }
        public string BaseAddress { get; set; }
        public string ShortName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ApplicationAddRequest()
        {
            Id = CommandParameter.Output(SqlDbType.Int);
        }

    }
}