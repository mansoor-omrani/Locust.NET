using Locust.Base;

namespace Locust.Modules.Setting.Strategies
{
	[EnumDefault("None")]
    public enum AppSettingCategoryGetAllStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus
    }
}