using Locust.Base;

namespace Locust.Modules.Location.Strategies
{
	[EnumDefault("None")]
    public enum CityGetByCodeStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus
    }
}