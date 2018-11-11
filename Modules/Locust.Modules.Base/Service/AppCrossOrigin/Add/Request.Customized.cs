using System;
using System.Data;
using Locust.Data;
using Locust.ServiceModel;

namespace Locust.Modules.Base.Strategies
{
	public partial class AppCrossOriginAddRequest : IBaseServiceRequest
    {
        public CommandParameter Id { get; set; }
        public Int32 AppId { get; set; }
        public Int32 MaxAge { get; set; }
        public bool WithCredentials { get; set; }
        public string Origin { get; set; }
        public string ExposeHeaders { get; set; }
        public string AllowHeaders { get; set; }

        public AppCrossOriginAddRequest()
        {
            Id = CommandParameter.Output(SqlDbType.Int);
        }
    }
}