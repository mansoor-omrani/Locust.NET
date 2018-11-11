using Locust.Base;

namespace Locust.Modules.Setting.Strategies
{
	[EnumDefault("None")]
    public enum AppSettingDeleteStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus
    }
}