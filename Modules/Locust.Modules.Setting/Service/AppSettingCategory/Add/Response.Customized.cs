using System;
using Locust.ServiceModel;
using Locust.Modules.Setting.Model;
namespace Locust.Modules.Setting.Strategies
{
	public partial class AppSettingCategoryAddResponse : BaseServiceResponse<object, AppSettingCategoryAddStatus>
    {
        public Int16 Id { get; set; }
    }
}