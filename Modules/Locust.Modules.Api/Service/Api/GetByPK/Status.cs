using Locust.Base;

namespace Locust.Modules.Api.Strategies
{
	[EnumDefault("None")]
    public enum ApiGetByPKStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus
    }
}