using Locust.Base;

namespace Locust.Modules.Location.Strategies
{
	[EnumDefault("None")]
    public enum StateGetCitiesStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus
    }
}