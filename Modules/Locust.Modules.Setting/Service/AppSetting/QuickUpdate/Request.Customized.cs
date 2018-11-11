using System;
using Locust.ServiceModel;

namespace Locust.Modules.Setting.Strategies
{
	public partial class AppSettingQuickUpdateRequest : IBaseServiceRequest
    {
        public Int32 Id { get; set; }
        public Int16 AppSettingCategoryID { get; set; }
        public string Key { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
    }
}