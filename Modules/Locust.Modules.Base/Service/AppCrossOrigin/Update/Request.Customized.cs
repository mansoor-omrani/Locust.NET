using System;
using System.Data;
using Locust.Data;
using Locust.ServiceModel;

namespace Locust.Modules.Base.Strategies
{
	public partial class AppCrossOriginUpdateRequest : IBaseServiceRequest
    {
        public int Id { get; set; }
        public Int32 MaxAge { get; set; }
        public bool WithCredentials { get; set; }
        public string Origin { get; set; }
        public string ExposeHeaders { get; set; }
        public string AllowHeaders { get; set; }
        public CommandParameter AppId { get; set; }

        public AppCrossOriginUpdateRequest()
        {
            AppId = CommandParameter.Output(SqlDbType.Int);
        }
    }
}