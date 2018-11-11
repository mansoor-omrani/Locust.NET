using Locust.Base;

namespace Locust.Modules.Api.Strategies
{
	[EnumDefault("None")]
    public enum ApiClientCustomerGetByPKStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus, NotFound
    }
}