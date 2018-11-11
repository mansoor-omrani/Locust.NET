using Locust.Base;

namespace Locust.Modules.Location.Strategies
{
	[EnumDefault("None")]
    public enum CityGetAllStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus
    }
}