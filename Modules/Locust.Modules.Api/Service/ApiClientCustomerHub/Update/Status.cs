using Locust.Base;

namespace Locust.Modules.Api.Strategies
{
	[EnumDefault("None")]
    public enum ApiClientCustomerHubUpdateStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus, NotFound, NoHubCode, HubCodeAlreadyExists, InvalidMobileNo, InvalidEmail, InvalidHubCode, InvalidMobileInHubCode, InvalidEmailInHubCode
    }
}