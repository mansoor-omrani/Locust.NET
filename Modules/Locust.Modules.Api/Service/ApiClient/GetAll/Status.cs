using Locust.Base;

namespace Locust.Modules.Api.Strategies
{
	[EnumDefault("None")]
    public enum ApiClientGetAllStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus
    }
}