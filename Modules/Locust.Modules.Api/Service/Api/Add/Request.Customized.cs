using System;
using System.Data;
using Locust.Data;
using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiAddRequest : IBaseServiceRequest
    {
        public CommandParameter Id { get; set; }
        public Int32 AppId { get; set; }
        public bool Enabled { get; set; }
        public bool EncryptResponse { get; set; }
        public bool Async { get; set; }
        public bool RequiresEncryptedRequest { get; set; }
        public bool AllowExpiredAccessToken { get; set; }
        public bool UseArrayForJsonSerialization { get; set; }
        public string Service { get; set; }
        public string Strategy { get; set; }
        public string Path { get; set; }
        public string Namespace { get; set; }
        public bool CompressedRequest { get; set; }
        public bool CompressedResponse { get; set; }
        public ApiAddRequest()
        {
            Id = CommandParameter.Output(SqlDbType.Int);
        }
    }
}