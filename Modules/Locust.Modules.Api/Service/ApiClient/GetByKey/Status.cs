using Locust.Base;

namespace Locust.Modules.Api.Strategies
{
	[EnumDefault("None")]
    public enum ApiClientGetByKeyStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus, NotFound
    }
}