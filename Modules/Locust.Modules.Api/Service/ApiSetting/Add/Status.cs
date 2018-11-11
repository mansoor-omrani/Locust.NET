using Locust.Base;

namespace Locust.Modules.Api.Strategies
{
	[EnumDefault("None")]
    public enum ApiSettingAddStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus
    }
}