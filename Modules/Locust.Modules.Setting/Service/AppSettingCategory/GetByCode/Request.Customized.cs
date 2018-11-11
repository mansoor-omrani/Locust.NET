using System;
using Locust.ServiceModel;

namespace Locust.Modules.Setting.Strategies
{
	public partial class AppSettingCategoryGetByCodeRequest : IBaseServiceRequest
    {
        public int AppId { get; set; }
        public string Code { get; set; }
    }
}