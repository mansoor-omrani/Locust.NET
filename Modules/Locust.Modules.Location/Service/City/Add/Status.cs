using Locust.Base;

namespace Locust.Modules.Location.Strategies
{
	[EnumDefault("None")]
    public enum CityAddStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus, NotFound
    }
}