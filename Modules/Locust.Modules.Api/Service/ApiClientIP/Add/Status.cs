using Locust.Base;

namespace Locust.Modules.Api.Strategies
{
	[EnumDefault("None")]
    public enum ApiClientIPAddStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus, InvalidApiClient, InvalidIP, NoIP
    }
}