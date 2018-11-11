using Locust.Base;

namespace Locust.Modules.Location.Strategies
{
	[EnumDefault("None")]
    public enum CountryGetByCodeStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus
    }
}