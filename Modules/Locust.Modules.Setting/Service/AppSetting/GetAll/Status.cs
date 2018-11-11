using Locust.Base;

namespace Locust.Modules.Setting.Strategies
{
	[EnumDefault("None")]
    public enum AppSettingGetAllStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus
    }
}