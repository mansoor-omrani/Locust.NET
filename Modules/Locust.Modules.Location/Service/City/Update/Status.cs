using Locust.Base;

namespace Locust.Modules.Location.Strategies
{
	[EnumDefault("None")]
    public enum CityUpdateStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus, NoTitleGiven, CodeAlreadyExists
    }
}