using System;
using System.Data;
using Locust.Data;
using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientUpdateRequest : IBaseServiceRequest
    {
        public Int32 Id { get; set; }
        public string ClientKey { get; set; }
        public bool Enabled { get; set; }
        public bool AllowAnyIPAddress { get; set; }
        public string ClientSecret { get; set; }
        public string HardwareCode { get; set; }
        public string FinishPaymentReturnUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public string Photo { get; set; }
        public CommandParameter OldClientKey { get; set; }

        public ApiClientUpdateRequest()
        {
            OldClientKey = CommandParameter.Output(SqlDbType.UniqueIdentifier);
        }
    }
}