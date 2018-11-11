using Locust.Base;

namespace Locust.Modules.Api.Strategies
{
	[EnumDefault("None")]
    public enum ApiClientGetPageStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus
    }
}