using System;
using System.Data;
using Locust.Data;
using Locust.ServiceModel;

namespace Locust.Modules.Setting.Strategies
{
	public partial class AppSettingCategoryAddRequest : IBaseServiceRequest
    {
        public CommandParameter Id { get; set; }
        public Int32 AppID { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public AppSettingCategoryAddRequest()
        {
            Id = CommandParameter.Output(SqlDbType.SmallInt);
        }
    }
}