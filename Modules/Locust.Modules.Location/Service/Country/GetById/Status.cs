using Locust.Base;

namespace Locust.Modules.Location.Strategies
{
	[EnumDefault("None")]
    public enum CountryGetByIdStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus
    }
}