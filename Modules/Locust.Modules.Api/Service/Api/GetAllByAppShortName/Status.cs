using Locust.Base;

namespace Locust.Modules.Api.Strategies
{
	[EnumDefault("None")]
    public enum ApiGetAllByAppShortNameStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus
    }
}