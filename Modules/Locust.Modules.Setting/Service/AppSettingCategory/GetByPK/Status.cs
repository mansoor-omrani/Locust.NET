using Locust.Base;

namespace Locust.Modules.Setting.Strategies
{
	[EnumDefault("None")]
    public enum AppSettingCategoryGetByPKStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus
    }
}