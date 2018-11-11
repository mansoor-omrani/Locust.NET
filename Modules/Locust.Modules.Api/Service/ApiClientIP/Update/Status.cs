using Locust.Base;

namespace Locust.Modules.Api.Strategies
{
	[EnumDefault("None")]
    public enum ApiClientIPUpdateStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus, NotFound, InvalidIP, NoIP
    }
}