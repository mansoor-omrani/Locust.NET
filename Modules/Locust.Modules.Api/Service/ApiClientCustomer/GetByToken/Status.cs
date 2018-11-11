using Locust.Base;

namespace Locust.Modules.Api.Strategies
{
	[EnumDefault("None")]
    public enum ApiClientCustomerGetByTokenStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus, NotFound
    }
}