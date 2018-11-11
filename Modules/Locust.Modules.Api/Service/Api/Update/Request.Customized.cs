using System.Data;
using Locust.Data;
using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiUpdateRequest : IBaseServiceRequest
    {
        public int Id { get; set; }
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
        public CommandParameter AppId { get; set; }
        public CommandParameter OldPath { get; set; }
        public ApiUpdateRequest()
        {
            AppId = CommandParameter.Output(SqlDbType.Int);
            OldPath = CommandParameter.Output(SqlDbType.VarChar, 100);
        }
    }
}