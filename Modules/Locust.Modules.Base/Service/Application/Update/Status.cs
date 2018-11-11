using Locust.Base;

namespace Locust.Modules.Base.Strategies
{
	[EnumDefault("None")]
    public enum ApplicationUpdateStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus, NotFound, NoCodeGiven, CodeAlreadyExists, NoTitleGiven, NoShortNameGiven, ShortNameAlreadyExists, InvalidDefaultCustomer, DefaultCustomerBelongsToAnotherApp
    }
}