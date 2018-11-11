using Locust.Base;

namespace Locust.Modules.Location.Strategies
{
	[EnumDefault("None")]
    public enum CountryDeleteByIdStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus
    }
}