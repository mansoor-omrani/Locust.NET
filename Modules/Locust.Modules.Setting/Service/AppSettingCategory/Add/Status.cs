using Locust.Base;

namespace Locust.Modules.Setting.Strategies
{
	[EnumDefault("None")]
    public enum AppSettingCategoryAddStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus, NoTitleGiven
    }
}