using Locust.Base;

namespace Locust.Modules.Setting.Strategies
{
	[EnumDefault("None")]
    public enum AppSettingCategoryDeleteStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus, HasChildren, NotFound
    }
}