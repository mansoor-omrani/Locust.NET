using Locust.Base;

namespace Locust.Modules.Location.Strategies
{
	[EnumDefault("None")]
    public enum CountryUpdateStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus
    }
}