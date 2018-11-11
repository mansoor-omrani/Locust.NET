using Locust.Base;

namespace Locust.Modules.Api.Strategies
{
	[EnumDefault("None")]
    public enum ApiClientCustomerCheckStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus
    }
}