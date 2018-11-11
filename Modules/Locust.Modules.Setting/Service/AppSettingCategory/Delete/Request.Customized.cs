using System;
using Locust.ServiceModel;

namespace Locust.Modules.Setting.Strategies
{
	public partial class AppSettingCategoryDeleteRequest : IBaseServiceRequest
    {
        public Int16 Id { get; set; }
    }
}