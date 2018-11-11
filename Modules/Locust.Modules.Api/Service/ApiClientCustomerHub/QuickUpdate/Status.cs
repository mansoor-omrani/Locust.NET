using Locust.Base;

namespace Locust.Modules.Api.Strategies
{
	[EnumDefault("None")]
    public enum ApiClientCustomerHubQuickUpdateStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus, NotFound
    }
}