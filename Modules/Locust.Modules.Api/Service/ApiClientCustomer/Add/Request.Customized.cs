using System;
using System.Data;
using Locust.Data;
using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerAddRequest : IBaseServiceRequest
    {
        public CommandParameter Id { get; set; }
        public GuidCommandParameter AccessToken { get; set; }
        public GuidCommandParameter RefreshToken { get; set; }
        public int ApiClientCustomerHubId { get; set; }
        public int UserId { get; set; }
        public int LifeLength { get; set; }
        public string HardwareCode { get; set; }
        public string EncryptionCode { get; set; }
        public string CustomerType { get; set; }

        public ApiClientCustomerAddRequest()
        {
            Id = CommandParameter.Output(SqlDbType.Int);
            AccessToken = new GuidCommandParameter("");
            RefreshToken = new GuidCommandParameter("");
        }
    }
}