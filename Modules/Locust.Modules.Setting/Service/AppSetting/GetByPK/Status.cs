using Locust.Base;

namespace Locust.Modules.Setting.Strategies
{
	[EnumDefault("None")]
    public enum AppSettingGetByPKStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus
    }
}