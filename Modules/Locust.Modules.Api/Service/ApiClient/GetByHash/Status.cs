using Locust.Base;

namespace Locust.Modules.Api.Strategies
{
	[EnumDefault("None")]
    public enum ApiClientGetByHashStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus, NotFound
    }
}