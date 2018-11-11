using System.Data;
using Locust.Data;
using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerEnrolRequest : IBaseServiceRequest
    {
        public int AppId { get; set; }
        public int ApiClientId { get; set; }
        public string IP { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string HardwareCode { get; set; }
        public string SerialNo { get; set; }
        public string ActivationMethod { get; set; }
        public string CustomerType { get; set; }
        public CommandOutputParameter ApiClientCustomerId { get; set; }
        public CommandOutputParameter ActivationCode { get; set; }
        public ApiClientCustomerEnrolRequest()
        {
            ApiClientCustomerId = CommandParameter.Output(SqlDbType.Int) as CommandOutputParameter;
            ActivationCode = CommandParameter.Output(SqlDbType.VarChar, 15) as CommandOutputParameter;
        }
    }
}