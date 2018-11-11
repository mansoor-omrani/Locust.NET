using Locust.Base;

namespace Locust.Modules.Api.Strategies
{
	[EnumDefault("None")]
    public enum ApiGetAllStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus
    }
}