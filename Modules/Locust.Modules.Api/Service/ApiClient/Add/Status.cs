using Locust.Base;

namespace Locust.Modules.Api.Strategies
{
	[EnumDefault("None")]
    public enum ApiClientAddStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus, InvalidApp, InvalidTheater, NoTitle
    }
}