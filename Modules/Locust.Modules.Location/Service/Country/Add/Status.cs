using Locust.Base;

namespace Locust.Modules.Location.Strategies
{
	[EnumDefault("None")]
    public enum CountryAddStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus
    }
}