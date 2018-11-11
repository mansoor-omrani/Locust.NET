using Locust.Base;

namespace Locust.Modules.Setting.Strategies
{
	[EnumDefault("None")]
    public enum AppSettingQuickAddStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus, NoTitle, NoKey, KeyAlreadyExists
    }
}