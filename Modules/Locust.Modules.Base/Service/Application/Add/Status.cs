using Locust.Base;

namespace Locust.Modules.Base.Strategies
{
	[EnumDefault("None")]
    public enum ApplicationAddStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus, NoCodeGiven, CodeAlreadyExists, NoTitleGiven, NoShortNameGiven, ShortNameAlreadyExists
    }
}