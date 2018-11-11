using Locust.Base;

namespace Locust.Modules.Api.Strategies
{
	[EnumDefault("None")]
    public enum ApiUpdateStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus, NoService, NoStrategy, PathAlreadyExists, NotFound
    }
}