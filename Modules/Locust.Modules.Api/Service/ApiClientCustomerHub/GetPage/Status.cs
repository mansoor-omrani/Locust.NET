using Locust.Base;

namespace Locust.Modules.Api.Strategies
{
	[EnumDefault("None")]
    public enum ApiClientCustomerHubGetPageStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus
    }
}