using System;
using Locust.ServiceModel;

namespace Locust.Modules.Setting.Strategies
{
	public partial class AppSettingCategoryGetByPKRequest : IBaseServiceRequest
    {
        public Int16 Id { get; set; }
    }
}