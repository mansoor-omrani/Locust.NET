using System;
using System.Data;
using Locust.Data;
using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientAddRequest : IBaseServiceRequest
    {
        public CommandParameter Id { get; set; }
        public Int32 AppId { get; set; }
        public bool Enabled { get; set; }
        public bool AllowAnyIPAddress { get; set; }
        public string ClientSecret { get; set; }
        public string HardwareCode { get; set; }
        public string FinishPaymentReturnUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public string Photo { get; set; }

        public ApiClientAddRequest()
        {
            Id = CommandParameter.Output(SqlDbType.Int);
        }
    }
}