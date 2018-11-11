using Locust.Base;

namespace Locust.Modules.Api.Strategies
{
	[EnumDefault("None")]
    public enum ApiClientIPDeleteStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus, NotFound
    }
}