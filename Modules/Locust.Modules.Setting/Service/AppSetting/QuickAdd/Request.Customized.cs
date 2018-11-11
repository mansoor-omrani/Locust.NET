using System;
using System.Data;
using Locust.Data;
using Locust.ServiceModel;

namespace Locust.Modules.Setting.Strategies
{
	public partial class AppSettingQuickAddRequest : IBaseServiceRequest
    {
        public CommandParameter Id { get; set; }
        public Int16 AppSettingCategoryID { get; set; }
        public string Key { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public AppSettingQuickAddRequest()
        {
            Id = CommandParameter.Output(SqlDbType.Int);
        }
    }
}