using Locust.Base;

namespace Locust.Modules.Location.Strategies
{
	[EnumDefault("None")]
    public enum CityGetAllByStateStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus
    }
}