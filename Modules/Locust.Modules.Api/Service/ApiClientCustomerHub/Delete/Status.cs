using Locust.Base;

namespace Locust.Modules.Api.Strategies
{
	[EnumDefault("None")]
    public enum ApiClientCustomerHubDeleteStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus, HasChildren, NotFound
    }
}