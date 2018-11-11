using Locust.Base;

namespace Locust.Modules.Api.Strategies
{
	[EnumDefault("None")]
    public enum ApiEngineRunStatus
    {
        None, Success, Faulted, Errored, Failed, InvalidStatus,

        InvalidOperation,

        AppNotFound,
        AppInactive,

        CustomerNotFound,
        CustomerInactive,
        CustomerDisabled,
        AccessTokenExpired, 

        HubNotFound,
        HubInactive,

        ClientNotFound,
        ClientDisabled,

        ClientIPMissing,
        ClientIPDenied,

        NoData,
        InvalidData,
        InvalidCompressedData,
        CannotDecryptData,
        InvalidApiRequest,

        RequestExpired,
        NoApi,

        ApiNotFound,
        ApiDisabled,

        RequestIsNotEncrypted,
        RequestShouldNotBeEncrypted,

        ServiceNotFound,
        ServiceNotResolved,
        InvalidMethod,
        ApiCallError,
        InvalidApiData,
        IncompleteApiData,

        ResultSerializationError,
        NoKeyToEncryptResult,
        EncryptResultError,

        OperationError
    }
}