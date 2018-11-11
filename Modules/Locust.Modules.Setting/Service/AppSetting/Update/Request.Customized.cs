using System;
using Locust.ServiceModel;

namespace Locust.Modules.Setting.Strategies
{
	public partial class AppSettingUpdateRequest : IBaseServiceRequest
    {
        public int AppSettingID { get; set; }
        public Byte SettingTypeId { get; set; }
        public Int16 AppSettingCategoryID { get; set; }
        public Int32 SettingSize { get; set; }
        public bool Encrypted { get; set; }
        public bool Sensitive { get; set; }
        public bool SettingDir { get; set; }
        public string Key { get; set; }
        public string SettingBaseTable { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public string SettingValues { get; set; }
    }
}