using Locust.Base;

namespace Locust.Modules.Setting.Strategies
{
	[EnumDefault("None")]
    public enum AppSettingCategoryGetByCodeStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus
    }
}