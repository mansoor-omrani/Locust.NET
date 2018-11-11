using Locust.Base;

namespace Locust.Modules.Base.Strategies
{
	[EnumDefault("None")]
    public enum AppCrossOriginAddStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus, NoOrigin
    }
}