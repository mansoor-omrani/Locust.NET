using Locust.Base;

namespace Locust.Modules.Location.Strategies
{
	[EnumDefault("None")]
    public enum CityGetByIdStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus
    }
}