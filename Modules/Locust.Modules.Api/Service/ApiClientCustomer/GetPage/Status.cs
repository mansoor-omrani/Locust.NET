using Locust.Base;

namespace Locust.Modules.Api.Strategies
{
	[EnumDefault("None")]
    public enum ApiClientCustomerGetPageStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus
    }
}