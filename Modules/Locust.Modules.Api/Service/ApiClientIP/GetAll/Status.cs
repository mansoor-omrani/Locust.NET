using Locust.Base;

namespace Locust.Modules.Api.Strategies
{
	[EnumDefault("None")]
    public enum ApiClientIPGetAllStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus
    }
}