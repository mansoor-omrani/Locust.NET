using Locust.Base;

namespace Locust.Modules.Location.Strategies
{
	[EnumDefault("None")]
    public enum CityDeleteByIdStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus, AccessDenied, NotFound
    }
}