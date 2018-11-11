using Locust.Base;

namespace Locust.Modules.Api.Strategies
{
	[EnumDefault("None")]
    public enum ApiAddStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus, NoService, NoStrategy, PathAlreadyExists, NoApp, InvalidApp
    }
}