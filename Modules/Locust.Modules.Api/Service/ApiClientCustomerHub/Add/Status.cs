using Locust.Base;

namespace Locust.Modules.Api.Strategies
{
	[EnumDefault("None")]
    public enum ApiClientCustomerHubAddStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus, InvalidClient, NoHubCode, HubCodeAlreadyExists, InvalidMobileNo, InvalidEmail, InvalidHubCode, InvalidMobileInHubCode, InvalidEmailInHubCode
    }
}