using Locust.Base;

namespace Locust.Modules.Setting.Strategies
{
	[EnumDefault("None")]
    public enum AppSettingCategoryUpdateStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus, NoTitleGiven, NotFound
    }
}