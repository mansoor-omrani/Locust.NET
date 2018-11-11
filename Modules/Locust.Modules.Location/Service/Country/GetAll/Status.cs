using Locust.Base;

namespace Locust.Modules.Location.Strategies
{
	[EnumDefault("None")]
    public enum CountryGetAllStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus
    }
}