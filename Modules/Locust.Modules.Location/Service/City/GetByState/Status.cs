using Locust.Base;

namespace Locust.Modules.Location.Strategies
{
	[EnumDefault("None")]
    public enum CityGetByStateStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus
    }
}