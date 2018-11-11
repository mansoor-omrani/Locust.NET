using Locust.Base;

namespace Locust.Modules.Api.Strategies
{
	[EnumDefault("None")]
    public enum ServiceSettingAddStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus, NoKey, NoService
    }
}