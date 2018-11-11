using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Locust.AppPath;
using Locust.Caching;
using Locust.Compression;
using Locust.Conversion;
using Locust.Cryptography;
using Locust.Db;
using Locust.Extensions;
using Locust.Json;
using Locust.Language;
using Locust.Logging;
using Locust.Model;
using Locust.ModelField;
using AppFields = Locust.Modules.Base.Fields.Application;
using Locust.Modules.Api.Service;
using Locust.Modules.Api.Service.ApiEngine;
using Locust.Modules.Base.Service;
using Locust.Network;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Tracing;
using Locust.Translation;
using Locust.WebExtensions;
using ApiClientCustomer = Locust.Modules.Api.Model.ApiClientCustomer;
using AppCrossOrigin = Locust.Modules.Base.Model.AppCrossOrigin.AdminGrid;
using MessageType = Locust.Tracing.MessageType;
using CacheName = Locust.Modules.Api.Service.CacheName;

namespace Locust.Modules.Api.Strategies
{
    public class ApiEngineRunStrategy : ApiEngineRunStrategyBase
    {
        public ApiEngineRunStrategy(ApplicationServiceBase appService,
            AppCrossOriginServiceBase appCrossOriginService,
            ApiClientServiceBase clientService,
            ApiClientCustomerHubService customerHubService,
            ApiClientCustomerServiceBase customerService,
            ApiClientIPServiceBase clientIPService,
            ApiServiceBase apiService,
            ApiSettingServiceBase apiSettingService,
            IBase64Compression compression,
            IDebugRequestGetter debugger,
            IEncryption crypt,
            IExceptionLogger logger,
            ITranslation translator,
            ICacheFactory cacheFactory)
            : base(
                appService, appCrossOriginService, clientService, customerHubService, customerService, clientIPService,
                apiService, apiSettingService, compression, debugger, crypt, logger, translator, cacheFactory)
        {
        }

        private string _category;

        public string Category
        {
            get
            {
                if (string.IsNullOrEmpty(_category))
                {
                    _category = Service.Name;
                }
                return _category;
            }
        }

        public string Operation
        {
            get { return this.Name; }
        }

        public override void Run(ApiEngineRunContext context)
        {
            context.Request.CallContext.EngineService = this.Service;

            if (context.Request.CallContext.HttpContext != null)
            {
                var useFilters = Service.Settings["FILTERS_ENABLED"] == "true";
                var Request = context.Request.CallContext.HttpContext.Request;

                try
                {
                    context.Log.DebugMode = debugger.GetDebugMode();
                    context.Log.TraceMode = debugger.GetTraceMode();
                    context.Log.DebugLevel = debugger.GetDebugLevel();
                    context.Log.ViewerType = debugger.GetViewerType();
                    context.Log.SuppressedDialog = true;
                    context.Log.SuppressedMessageType = MessageType.System;

                    if (useFilters)
                        ApiEngine.OnBegoreGetSettings(context.Request);

                    Service.FetchSettings(context);

                    if (useFilters)
                        ApiEngine.OnBeforeGetApp(context.Request);

                    var getAppResult = getApp(context).Result;
                    var getClientResult = false;

                    if (getAppResult)
                    {
                        var access_token = Request.GetAccessToken();
                        var getCustomerResult = true;

                        if (!string.IsNullOrEmpty(access_token))
                        {
                            if (useFilters)
                                ApiEngine.OnBeforeGetCustomer(context.Request);

                            getCustomerResult = getCustomerByToken(context, access_token).Result;
                        }
                        else
                        {
                            if (context.Request.CallContext.App.DefaultCustomerId > 0)
                            {
                                if (useFilters)
                                    ApiEngine.OnBeforeGetCustomer(context.Request);

                                getCustomerResult = getCustomerById(context).Result;
                            }
                        }

                        if (!getCustomerResult)
                        {
                            goto end_run;
                        }

                        if (context.Request.CallContext.Customer != null)
                        {
                            if (useFilters)
                                ApiEngine.OnBeforeGetCustomerHub(context.Request);

                            var getHubResult = getHubById(context).Result;

                            if (getHubResult)
                            {
                                if (useFilters)
                                    ApiEngine.OnBeforeGetClient(context.Request);

                                getClientResult = getClientById(context).Result;
                            }
                        }
                        else
                        {
                            if (useFilters)
                                ApiEngine.OnBeforeGetClient(context.Request);

                            getClientResult = getClientByKey(context).Result;
                        }

                        if (context.Request.CallContext.Client != null)
                        {
                            if (getClientResult)
                            {
                                if (useFilters)
                                    ApiEngine.OnBeforeCheckClientIp(context.Request);

                                var checkClientIPResult = checkClientIP(context).Result;

                                if (checkClientIPResult)
                                {
                                    if (useFilters)
                                        ApiEngine.OnBeforeGetBody(context.Request);

                                    var getBodyResult = getRequestBody(context);

                                    if (getBodyResult)
                                    {
                                        if (useFilters)
                                            ApiEngine.OnBeforeGetApi(context.Request);

                                        var getApiResult = getApi(context).Result;

                                        if (getApiResult)
                                        {
                                            if (context.Request.CallContext.Customer == null ||
                                                context.Request.CallContext.Customer.HasValidToken ||
                                                (context.Request.CallContext.Customer != null &&
                                                 context.Request.CallContext.Api.AllowExpiredAccessToken))
                                            {
                                                if (useFilters)
                                                    ApiEngine.OnBeforeCheckApiAccess(context.Request);

                                                var checkApiAccessResult = checkApiAccess(context).Result;

                                                if (checkApiAccessResult)
                                                {
                                                    if (useFilters)
                                                        ApiEngine.OnBeforeCallService(context.Request);

                                                    callService(context, async: false).Wait();

                                                    if (useFilters)
                                                        ApiEngine.OnAfterCallService(context.Request);
                                                }
                                            }
                                            else
                                            {
                                                context.Response.Status = ApiEngineRunStatus.AccessTokenExpired;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (useFilters)
                                ApiEngine.OnBeforeGetBody(context.Request);

                            var getBodyResult = getRequestBody(context);

                            if (getBodyResult)
                            {
                                if (useFilters)
                                    ApiEngine.OnBeforeGetApi(context.Request);

                                var getApiResult = getApi(context).Result;

                                if (getApiResult)
                                {
                                    var okToCall = false;

                                    if (!context.Request.CallContext.Api.RequiresEncryptedRequest &&
                                        context.Request.IsEncrypted)
                                    {
                                        context.Response.Status = ApiEngineRunStatus.RequestShouldNotBeEncrypted;
                                    }
                                    else
                                    {
                                        if (context.Request.CallContext.Api.RequiresEncryptedRequest &&
                                            !context.Request.IsEncrypted)
                                        {
                                            context.Response.Status = ApiEngineRunStatus.RequestIsNotEncrypted;
                                        }
                                        else
                                        {
                                            okToCall = true;
                                        }
                                    }

                                    if (okToCall)
                                    {
                                        if (useFilters)
                                            ApiEngine.OnBeforeCallService(context.Request);

                                        callService(context, async: false).Wait();

                                        if (useFilters)
                                            ApiEngine.OnAfterCallService(context.Request);
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    context.Response.Status = ApiEngineRunStatus.OperationError;
                    context.Log.Danger(Category, Operation, "apiengine_error", ex, MessageSource.Framework);
                }

                end_run:

                if (useFilters)
                    ApiEngine.OnBeforeFinalize(context.Request);

                finaizeResponse(context).Wait();
            }
        }

        private async Task<bool> getApp(ApiEngineRunContext context)
        {
            var response = context.Request.CallContext.ApiResponse;
            var result = false;
            var Request = context.Request.CallContext.HttpContext.Request;
            var isPost = string.Compare(Request.HttpMethod, "post", StringComparison.OrdinalIgnoreCase) == 0;
            var isOptions = string.Compare(Request.HttpMethod, "options", StringComparison.OrdinalIgnoreCase) == 0;

            if (!(isPost || isOptions))
            {
                context.Response.Status = ApiEngineRunStatus.InvalidOperation;
                goto exit_step;
            }

            context.Log.Trace(Category, Operation, "create context for AppService");
            var ctxApp = await appService.GetByShortName.InvokeAsync(context, new { context.Request.ShortName });

            var app = ctxApp.Response.Data;

            if (!ctxApp.Response.Success)
            {
                response.Status = ctxApp.ServiceName + "." + ctxApp.Response.GetStatus();

                goto exit_step;
            }

            if (app == null)
            {
                context.Response.Status = ApiEngineRunStatus.AppNotFound;

                goto exit_step;
            }

            context.Request.CallContext.App = app;

            if (!app.IsActive)
            {
                context.Response.Status = ApiEngineRunStatus.AppInactive;

                goto exit_step;
            }

            app.CrossOrigins = await getAppCrossOrigins(context);
            checkCORS(context);

            if (isPost)
            {
                result = true;
            }
            exit_step:
            return result;
        }

        private async Task<IList<AppCrossOrigin>> getAppCrossOrigins(ApiEngineRunContext context)
        {
            var appid = context.Request.CallContext.App.AppId.Value;
            var ctx = await appCrossOriginService.GetAll.InvokeAsync(context, new { appid });
            return ctx.Response.Data;
        }

        private void checkCORS(ApiEngineRunContext context)
        {
            var app = context.Request.CallContext.App;
            var response = context.Request.CallContext.ApiResponse;
            var Request = context.Request.CallContext.HttpContext.Request;
            var Response = context.Request.CallContext.HttpContext.Response;
            var isPost = string.Compare(Request.HttpMethod, "post", StringComparison.OrdinalIgnoreCase) == 0;
            var origin = SafeClrConvert.ToString(Request.Headers["origin"]);
            var lastCh = ' ';

            if (origin.Length > 0)
            {
                lastCh = origin[origin.Length - 1];
            }

            if (lastCh == '/' || lastCh == '\\')
            {
                origin = origin.Left(origin.Length - 1);
            }

            if (!string.IsNullOrEmpty(origin) && app.CrossOrigins != null && app.CrossOrigins.Count > 0)
            {
                Uri uri;

                if (Uri.TryCreate(origin, UriKind.Absolute, out uri))
                {
                    var x =
                        app.CrossOrigins.FirstOrDefault(
                            o => string.Compare(o.Origin.Value, origin, StringComparison.OrdinalIgnoreCase) == 0);

                    if (x != null)
                    {
                        if (isPost)
                        {
                            Response.Headers["Access-Control-Allow-Origin"] = origin;

                            if (x.WithCredentials)
                            {
                                Response.Headers["Access-Control-Allow-Credentials"] = "true";
                            }

                            if (!string.IsNullOrEmpty(x.ExposeHeaders.Value))
                            {
                                Response.Headers["Access-Control-Expose-Headers"] = x.ExposeHeaders.Value;
                            }
                        }
                        else // is OPTIONS
                        {
                            if (
                                string.Compare(
                                    SafeClrConvert.ToString(Request.Headers["Access-Control-Request-Method"]),
                                    "post", StringComparison.OrdinalIgnoreCase) == 0)
                            {
                                Response.Headers["Access-Control-Allow-Origin"] = origin;
                                Response.Headers["Access-Control-Allow-Methods"] = "POST";

                                if (x.WithCredentials)
                                {
                                    Response.Headers["Access-Control-Allow-Credentials"] = "true";
                                }

                                if (!string.IsNullOrEmpty(x.AllowHeaders.Value))
                                {
                                    Response.Headers["Access-Control-Allow-Headers"] = x.AllowHeaders.Value;
                                }

                                if (x.MaxAge > 0)
                                {
                                    Response.Headers["Access-Control-Max-Age"] = x.MaxAge.Value.ToString();
                                }
                            }
                        }
                    }
                }
            }
        }

        private async Task<bool> getCustomerByToken(ApiEngineRunContext context, string accessToken)
        {
            var response = context.Request.CallContext.ApiResponse;
            var result = false;
            Model.ApiClientCustomer.Full data = null;

            context.Log.Trace(Category, Operation, "creating context for ApiClientCustomerService: GetByToken");
            var ctxCustomer = await customerService.GetByToken.InvokeAsync(context, new { AccessToken = accessToken });

            if (!ctxCustomer.Response.Success)
            {
                response.Status = ctxCustomer.ServiceName + "." + ctxCustomer.Response.GetStatus();

                goto exit_step;
            }

            data = ctxCustomer.Response.Data;

            if (data == null)
            {
                context.Response.Status = ApiEngineRunStatus.CustomerNotFound;

                goto exit_step;
            }

            context.Request.CallContext.Customer = data;

            if (data.Disabled)
            {
                context.Response.Status = ApiEngineRunStatus.CustomerDisabled;

                goto exit_step;
            }

            if (!data.Activated)
            {
                context.Response.Status = ApiEngineRunStatus.CustomerInactive;

                goto exit_step;
            }

            result = true;
            exit_step:
            return result;
        }

        private async Task<bool> getCustomerById(ApiEngineRunContext context)
        {
            var apiClientCustomerId = context.Request.CallContext.App.DefaultCustomerId.Value;
            var response = context.Request.CallContext.ApiResponse;
            var result = false;
            Model.ApiClientCustomer.Full data = null;

            context.Log.Trace(Category, Operation, "creating context for ApiClientCustomerService: GetByToken");
            var ctxCustomer = await customerService.GetByPK.InvokeAsync(context, new { Id = apiClientCustomerId });

            if (!ctxCustomer.Response.Success)
            {
                response.Status = ctxCustomer.ServiceName + "." + ctxCustomer.Response.GetStatus();

                goto exit_step;
            }

            data = ctxCustomer.Response.Data;

            if (data == null)
            {
                context.Response.Status = ApiEngineRunStatus.CustomerNotFound;

                goto exit_step;
            }

            context.Request.CallContext.Customer = data;

            if (data.Disabled)
            {
                context.Response.Status = ApiEngineRunStatus.CustomerDisabled;

                goto exit_step;
            }

            if (!data.Activated)
            {
                context.Response.Status = ApiEngineRunStatus.CustomerInactive;

                goto exit_step;
            }

            result = true;
            exit_step:
            return result;
        }

        private async Task<bool> getHubById(ApiEngineRunContext context)
        {
            var apiClientCustomerHubId = context.Request.CallContext.Customer.ApiClientCustomerHubId.Value;
            var response = context.Request.CallContext.ApiResponse;
            var result = false;
            Model.ApiClientCustomerHub.Full data = null;

            context.Log.Trace(Category, Operation, "creating context for ApiClientCustomerHubService: GetByPK");
            var ctxHub = await customerHubService.GetByPK.InvokeAsync(context, new { Id = apiClientCustomerHubId });

            if (!ctxHub.Response.Success)
            {
                response.Status = ctxHub.ServiceName + "." + ctxHub.Response.GetStatus();

                goto exit_step;
            }

            data = ctxHub.Response.Data;

            if (data == null)
            {
                context.Response.Status = ApiEngineRunStatus.HubNotFound;

                goto exit_step;
            }

            context.Request.CallContext.Hub = data;

            if (!data.IsActive)
            {
                context.Response.Status = ApiEngineRunStatus.HubInactive;

                goto exit_step;
            }

            result = true;
            exit_step:
            return result;
        }

        private async Task<bool> getClientById(ApiEngineRunContext context)
        {
            var apiClientId = context.Request.CallContext.Hub.ApiClientId.Value;
            var response = context.Request.CallContext.ApiResponse;
            var result = false;
            Model.ApiClient.Full data = null;

            context.Log.Trace(Category, Operation, "creating context for ApiClientService: GetByPK");
            var ctxClient = await clientService.GetByPK.InvokeAsync(context, new { Id = apiClientId });

            if (!ctxClient.Response.Success)
            {
                response.Status = ctxClient.ServiceName + "." + ctxClient.Response.GetStatus();

                goto exit_step;
            }

            data = ctxClient.Response.Data;

            if (data == null)
            {
                context.Response.Status = ApiEngineRunStatus.ClientNotFound;

                goto exit_step;
            }

            context.Request.CallContext.Client = data;

            if (!data.Enabled)
            {
                context.Response.Status = ApiEngineRunStatus.ClientDisabled;

                goto exit_step;
            }

            result = true;
            exit_step:
            return result;
        }

        private async Task<bool> getClientByKey(ApiEngineRunContext context)
        {
            var response = context.Request.CallContext.ApiResponse;
            var request = context.Request.CallContext.HttpContext.Request;
            var clientKey = request.GetClientKey();
            var clientKeyHash = request.GetClientKeyHash();
            var result = false;
            Model.ApiClient.Full data = null;

            if (!string.IsNullOrEmpty(clientKey))
            {

                context.Log.Trace(Category, Operation, "creating context for ApiClientService: GetByKey");
                var ctxClient = await clientService.GetByKey.InvokeAsync(context, new { ClientKey = clientKey });

                if (!ctxClient.Response.Success)
                {
                    response.Status = ctxClient.ServiceName + "." + ctxClient.Response.GetStatus();

                    goto exit_step;
                }

                data = ctxClient.Response.Data;

                if (data == null)
                {
                    context.Response.Status = ApiEngineRunStatus.ClientNotFound;

                    goto exit_step;
                }

                context.Request.CallContext.Client = data;

                if (!data.Enabled)
                {
                    context.Response.Status = ApiEngineRunStatus.ClientDisabled;

                    goto exit_step;
                }

                result = true;
            }
            else
            {
                if (!string.IsNullOrEmpty(clientKeyHash))
                {
                    context.Log.Trace(Category, Operation, "creating context for ApiClientService: GetByHash");
                    var ctxClient =
                        await
                            clientService.GetByHash.InvokeAsync(context,
                                new ApiClientGetByHashRequest { ClientKeyHash = clientKeyHash });

                    if (!ctxClient.Response.Success)
                    {
                        response.Status = ctxClient.ServiceName + "." + ctxClient.Response.GetStatus();

                        goto exit_step;
                    }

                    data = ctxClient.Response.Data;

                    if (data == null)
                    {
                        context.Response.Status = ApiEngineRunStatus.ClientNotFound;

                        goto exit_step;
                    }

                    context.Request.CallContext.Client = data;

                    if (!data.Enabled)
                    {
                        context.Response.Status = ApiEngineRunStatus.ClientDisabled;

                        goto exit_step;
                    }

                    result = true;
                }
            }
            exit_step:
            return result;
        }

        public override async Task RunAsync(ApiEngineRunContext context)
        {
            context.Request.CallContext.EngineService = this.Service;

            if (context.Request.CallContext.HttpContext != null)
            {
                var useFilters = Service.Settings["FILTERS_ENABLED"] == "true";
                var Request = context.Request.CallContext.HttpContext.Request;

                try
                {
                    context.Log.DebugMode = debugger.GetDebugMode();
                    context.Log.TraceMode = debugger.GetTraceMode();
                    context.Log.DebugLevel = debugger.GetDebugLevel();
                    context.Log.ViewerType = debugger.GetViewerType();
                    context.Log.SuppressedDialog = true;
                    context.Log.SuppressedMessageType = MessageType.System;

                    if (useFilters)
                        await ApiEngine.OnBegoreGetSettingsAsync(context.Request);

                    await Service.FetchSettingsAsync(context);

                    if (useFilters)
                        await ApiEngine.OnBeforeGetAppAsync(context.Request);

                    var getAppResult = await getApp(context);
                    var getClientResult = false;

                    if (getAppResult)
                    {
                        var access_token = Request.GetAccessToken();
                        var getCustomerResult = true;

                        if (!string.IsNullOrEmpty(access_token))
                        {
                            if (useFilters)
                                await ApiEngine.OnBeforeGetCustomerAsync(context.Request);

                            getCustomerResult = await getCustomerByToken(context, access_token);
                        }
                        else
                        {
                            if (context.Request.CallContext.App.DefaultCustomerId > 0)
                            {
                                if (useFilters)
                                    await ApiEngine.OnBeforeGetCustomerAsync(context.Request);

                                getCustomerResult = await getCustomerById(context);
                            }
                        }

                        if (!getCustomerResult)
                        {
                            goto end_run;
                        }

                        if (context.Request.CallContext.Customer != null)
                        {
                            if (useFilters)
                                await ApiEngine.OnBeforeGetCustomerHubAsync(context.Request);

                            var getHubResult = await getHubById(context);

                            if (getHubResult)
                            {
                                if (useFilters)
                                    await ApiEngine.OnBeforeGetClientAsync(context.Request);

                                getClientResult = await getClientById(context);
                            }
                        }
                        else
                        {
                            if (useFilters)
                                await ApiEngine.OnBeforeGetClientAsync(context.Request);

                            getClientResult = await getClientByKey(context);
                        }

                        if (context.Request.CallContext.Client != null)
                        {
                            if (getClientResult)
                            {
                                if (useFilters)
                                    await ApiEngine.OnBeforeCheckClientIpAsync(context.Request);

                                var checkClientIPResult = await checkClientIP(context);

                                if (checkClientIPResult)
                                {
                                    if (useFilters)
                                        await ApiEngine.OnBeforeGetBodyAsync(context.Request);

                                    var getBodyResult = getRequestBody(context);

                                    if (getBodyResult)
                                    {
                                        if (useFilters)
                                            await ApiEngine.OnBeforeGetApiAsync(context.Request);

                                        var getApiResult = await getApi(context);

                                        if (getApiResult)
                                        {
                                            if (context.Request.CallContext.Customer == null ||
                                                context.Request.CallContext.Customer.HasValidToken ||
                                                (context.Request.CallContext.Customer != null &&
                                                 context.Request.CallContext.Api.AllowExpiredAccessToken))
                                            {
                                                if (useFilters)
                                                    await ApiEngine.OnBeforeCheckApiAccessAsync(context.Request);

                                                var checkApiAccessResult = await checkApiAccess(context);

                                                if (checkApiAccessResult)
                                                {
                                                    if (useFilters)
                                                        await ApiEngine.OnBeforeCallServiceAsync(context.Request);

                                                    await callService(context);

                                                    if (useFilters)
                                                        await ApiEngine.OnAfterCallServiceAsync(context.Request);
                                                }
                                            }
                                            else
                                            {
                                                context.Response.Status = ApiEngineRunStatus.AccessTokenExpired;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (useFilters)
                                await ApiEngine.OnBeforeGetBodyAsync(context.Request);

                            var getBodyResult = getRequestBody(context);

                            if (getBodyResult)
                            {
                                if (useFilters)
                                    await ApiEngine.OnBeforeGetApiAsync(context.Request);

                                var getApiResult = await getApi(context);

                                if (getApiResult)
                                {
                                    var okToCall = false;

                                    if (!context.Request.CallContext.Api.RequiresEncryptedRequest &&
                                        context.Request.IsEncrypted)
                                    {
                                        context.Response.Status = ApiEngineRunStatus.RequestShouldNotBeEncrypted;
                                    }
                                    else
                                    {
                                        if (context.Request.CallContext.Api.RequiresEncryptedRequest &&
                                            !context.Request.IsEncrypted)
                                        {
                                            context.Response.Status = ApiEngineRunStatus.RequestIsNotEncrypted;
                                        }
                                        else
                                        {
                                            okToCall = true;
                                        }
                                    }

                                    if (okToCall)
                                    {
                                        if (useFilters)
                                            await ApiEngine.OnBeforeCallServiceAsync(context.Request);

                                        await callService(context);

                                        if (useFilters)
                                            await ApiEngine.OnAfterCallServiceAsync(context.Request);
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    context.Response.Status = ApiEngineRunStatus.OperationError;
                    context.Log.Danger(Category, Operation, "apiengine_error", ex, MessageSource.Framework);
                }

                end_run:

                if (useFilters)
                    await ApiEngine.OnBeforeFinalizeAsync(context.Request);

                await finaizeResponse(context);
            }
        }


        private async Task<bool> checkClientIP(ApiEngineRunContext context)
        {
            var client = context.Request.CallContext.Client;
            var response = context.Request.CallContext.ApiResponse;
            var result = false;

            context.Log.Trace(Category, Operation, "creating context for ApiClientIPService: GetAllFor");
            var ctxClientIP =
                await clientIPService.GetAll.InvokeAsync(context, new { ApiClientId = client.ApiClientId.Value });
            var clientIPs = ctxClientIP.Response.Data;

            if (!ctxClientIP.Response.Success)
            {
                response.Status = ctxClientIP.ServiceName + "." + ctxClientIP.Response.GetStatus();

                goto exit_step;
            }

            context.Request.CallContext.ClientIPs = clientIPs;

            if (!client.AllowAnyIPAddress)
            {
                if (clientIPs == null || clientIPs.Count == 0)
                {
                    context.Response.Status = ApiEngineRunStatus.ClientIPMissing;
                }
                else
                {
                    var currentIP = new IPv4(context.Request.CallContext.ClientIP);

                    foreach (var clientIP in clientIPs)
                    {
                        if (clientIP.IsActive && currentIP.Matches(clientIP.IP))
                        {
                            result = true;
                            break;
                        }
                    }
                    if (!result)
                    {
                        context.Response.Status = ApiEngineRunStatus.ClientIPDenied;
                    }
                }
            }
            else
            {
                result = true;
            }
            exit_step:
            return result;
        }

        private bool IsEncryptedRequest(ApiEngineRunContext context)
        {
            var Request = context.Request.CallContext.HttpContext.Request;
            return SafeClrConvert.ToBoolean(Request.Headers["x-encrypted-api"]);
        }

        private bool IsRequestDataCompressed(ApiEngineRunContext context)
        {
            var Request = context.Request.CallContext.HttpContext.Request;
            return context.Request.CallContext.Api?.CompressedRequest || SafeClrConvert.ToBoolean(Request.Headers["x-compressed-request"]);
        }
        private bool getRequestBody(ApiEngineRunContext context)
        {
            var result = false;
            var customer = context.Request.CallContext.Customer;
            var encryptionCode = (customer != null) ? customer.EncryptionCode : "";
            var Request = context.Request.CallContext.HttpContext.Request;
            var pureBody = "";

            if (Request.IsMultipartFormData())
            {
                pureBody = string.Format("{{api:\"{0}\",data:{1}}}", SafeClrConvert.ToString(Request.Form["api"]), SafeClrConvert.ToString(Request.Form["data"]));
            }
            else
            {
                pureBody = SafeClrConvert.ToString(context.Request.CallContext.HttpContext.Items["x_request_body"]);
            }

            var body = "";

            context.Request.IsEncrypted = IsEncryptedRequest(context);

            if (context.Request.IsEncrypted)
            {
                if (!string.IsNullOrEmpty(encryptionCode))
                {
                    context.Log.Trace(Category, Operation, "getting request body");
                    var encryptedBody = pureBody;

                    if (!string.IsNullOrEmpty(encryptedBody))
                    {
                        context.Log.Trace(Category, Operation, "decrypting request body");
                        try
                        {
                            body = crypt.Decrypt(encryptedBody, encryptionCode);
                            context.Request.IsEncrypted = true;
                        }
                        catch (Exception e)
                        {
                            context.Response.Status = ApiEngineRunStatus.InvalidData;
                            context.Log.Danger(Category, Operation, context.Response.GetStatus(), e);

                            goto exit_getBody;
                        }

                        context.Log.Trace(Category, Operation, "parsing request body as json");

                        try
                        {
                            context.Request.ReadJson(body);
                            result = true;

                            if (IsRequestDataCompressed(context))
                            {
                                try
                                {
                                    var bufferSize =
                                        SafeClrConvert.ToInt(Service.Settings["Stream_Buffer_Length"]);
                                    context.Request.Data = compression.Base64Decompress(context.Request.Data, new ZlibCompressionOptions { DecompressBufferSize = bufferSize });
                                }
                                catch (Exception e2)
                                {
                                    context.Response.Status = ApiEngineRunStatus.InvalidCompressedData;
                                    context.Log.Danger(Category, Operation, context.Response.GetStatus(), e2);
                                    result = false;
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            context.Response.Status = ApiEngineRunStatus.InvalidApiRequest;
                            context.Log.Danger(Category, Operation, context.Response.GetStatus(), e);
                        }
                    }
                    else
                    {
                        context.Response.Status = ApiEngineRunStatus.NoData;
                    }
                }
                else
                {
                    context.Response.Status = ApiEngineRunStatus.CannotDecryptData;
                }
            }
            else
            {
                context.Log.Trace(Category, Operation, "getting request body");
                body = pureBody;

                if (!string.IsNullOrEmpty(body))
                {
                    context.Log.Trace(Category, Operation, "parsing request body as json");

                    try
                    {
                        context.Request.ReadJson(body);
                        result = true;

                        if (IsRequestDataCompressed(context))
                        {
                            try
                            {
                                var bufferSize =
                                        SafeClrConvert.ToInt(Service.Settings["Stream_Buffer_Length"]);
                                context.Request.Data = compression.Base64Decompress(context.Request.Data, new ZlibCompressionOptions { DecompressBufferSize = bufferSize });
                            }
                            catch (Exception e2)
                            {
                                context.Response.Status = ApiEngineRunStatus.InvalidCompressedData;
                                context.Log.Danger(Category, Operation, context.Response.GetStatus(), e2);
                                result = false;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        context.Response.Status = ApiEngineRunStatus.InvalidApiRequest;
                        context.Log.Danger(Category, Operation, context.Response.GetStatus(), e, MessageSource.Framework);
                    }
                }
                else
                {
                    context.Response.Status = ApiEngineRunStatus.NoData;
                }
            }
            exit_getBody:
            context.Request.CallContext.Body = body;

            return result;
        }
        private async Task<bool> getApi(ApiEngineRunContext context)
        {
            var response = context.Request.CallContext.ApiResponse;
            var app = context.Request.CallContext.App;
            var result = false;
            Model.Api.Full data = null;

            if (app.RequiresImmediateApiCall)
            {
                if ((DateTime.Now - context.Request.Date).TotalSeconds > 120)   // we consider requests that are issued from 2 mintues ago so far.
                                                                                // this is for more security, making requests unrelayable after 2 minutes.
                                                                                // the extent of sliding range depends on how fast the app is.
                                                                                // the faster app is, the narrower sliding expiration range will be.
                {
                    context.Response.Status = ApiEngineRunStatus.RequestExpired;

                    goto exit_step;
                }
            }

            if (string.IsNullOrEmpty(context.Request.Api))
            {
                context.Response.Status = ApiEngineRunStatus.NoApi;

                goto exit_step;
            }

            if (context.Request.Api.IsNumeric())
            {
                context.Log.Trace(Category, Operation, "invoking ApiService.GetByPK");
                var ctxApi = await apiService.GetByPK.InvokeAsync(context, new { AppId = app.AppId.Value, Id = SafeClrConvert.ToInt32(context.Request.Api) });

                data = ctxApi.Response.Data;

                if (!ctxApi.Response.Success)
                {
                    response.Status = ctxApi.ServiceName + "." + ctxApi.Response.GetStatus();

                    goto exit_step;
                }
            }
            else
            {
                context.Log.Trace(Category, Operation, "invoking ApiService.GetByPath");
                var ctxApi = await apiService.GetByApiPath.InvokeAsync(context, new { AppId = app.AppId.Value, Path = context.Request.Api });

                data = ctxApi.Response.Data;

                if (!ctxApi.Response.Success)
                {
                    response.Status = ctxApi.ServiceName + "." + ctxApi.Response.GetStatus();

                    goto exit_step;
                }
            }

            if (data == null)
            {
                context.Response.Status = ApiEngineRunStatus.ApiNotFound;

                goto exit_step;
            }

            context.Request.CallContext.Api = data;

            if (!data.Enabled)
            {
                context.Response.Status = ApiEngineRunStatus.ApiDisabled;

                goto exit_step;
            }

            await getApiSetting(context);

            result = true;
            exit_step:
            return result;
        }

        private async Task getApiSetting(ApiEngineRunContext context)
        {
            if (context.Request.CallContext.Api != null)
            {
                context.Log.Trace(Category, Operation, "invoking ApiSettingService.GetAllByApi");
                var ctxApiSetting = await apiSettingService.GetAllByApi.InvokeAsync(context, new ApiSettingGetAllByApiRequest { ApiId = context.Request.CallContext.Api.ApiId });

                if (ctxApiSetting.Response.Success)
                {
                    context.Request.CallContext.Api.Settings = ctxApiSetting.Response.Data;
                }
            }
        }
        private async Task callService(ApiEngineRunContext context, bool async = true)
        {
            context.Log.SuppressedDialog = false;
            context.Log.Trace(Category, Operation, "finding service");

            var response = context.Request.CallContext.ApiResponse;
            var api = context.Request.CallContext.Api;
            var abstractType = ServiceConfig.GetServiceAbstraction(api.Service, api.Namespace);

            if (abstractType != null)
            {
                var service = context.Request.ResolveService(abstractType);

                if (service != null)
                {
                    service.Db = Service.Db;
                    context.Request.CallContext.Service = service;

                    var x = service as ApiBaseService;

                    if (x != null)
                    {
                        context.Log.Trace(Category, Operation,
                            "fetching service settings: " + api.Service + "." + api.Strategy);

                        await x.FetchSettingsAsync(context);
                    }

                    context.Log.Trace(Category, Operation,
                        "creating context for Service.Stratgey: " + api.Service + "." + api.Strategy);
                    var ctxService = service.CreateContextBy(context, api.Strategy);

                    if (ctxService != null)
                    {
                        context.Request.CallContext.ServiceContext = ctxService;
                        var requestType = ctxService.Request.GetType();
                        context.Log.Trace(Category, Operation,
                            "deserializing request data as json for service.context.request: " + requestType.Name);

                        try
                        {
                            var app = context.Request.CallContext.App.AppId;
                            var ac = (context.Request.CallContext.Client != null)
                                ? context.Request.CallContext.Client.ApiClientId
                                : 0;
                            var acch = (context.Request.CallContext.Customer != null)
                                ? context.Request.CallContext.Customer.ApiClientCustomerHubId
                                : 0;
                            var acc = (context.Request.CallContext.Customer != null)
                                ? context.Request.CallContext.Customer.ApiClientCustomerId
                                : 0;
                            var dbContextInfo = string.Format("a:{0},cl:{1},cu:{2},ip:{3},u:{4},r:{5}$",
                                app,
                                ac,
                                acc,
                                context.Request.CallContext.ClientIP,
                                context.Request.CallContext.HttpContext.User.Identity.Name,
                                context.Request.CallContext.HttpContext.User.Identity.GetRole()
                            );

                            Service.Db.ContextInfoProvider.SetContextInfo(dbContextInfo);

                            context.HttpContext.Items.Add("AppId", app);
                            context.HttpContext.Items.Add("ApiClientId", ac);
                            context.HttpContext.Items.Add("ApiClientCustomerHubId", acch);
                            context.HttpContext.Items.Add("ApiClientCustomerId", acc);

                            object req = null;
                            var callService = false;

                            if (!string.IsNullOrEmpty(context.Request.Data))
                            {
                                if (requestType.DescendsFrom(JsonHelper.JsonModelType))
                                {
                                    req = Activator.CreateInstance(requestType);
                                    var jsonModel = req as JsonModel;
                                    jsonModel.ReadJson(context.Request.Data);
                                    callService = true;
                                }
                                else
                                {
                                    try
                                    {
                                        req = JsonConvert.DeserializeObject(context.Request.Data, requestType);
                                        callService = true;
                                    }
                                    catch
                                    {
                                        req = JsonConvert.DeserializeObject(context.Request.Data);
                                        callService = true;
                                    }
                                }
                            }
                            else
                            {
                                callService = true;
                            }

                            if (callService)
                            {
                                if (req != null)
                                {
                                    if (req.GetType() == requestType)
                                    {
                                        ctxService.Request = req as IBaseServiceRequest;
                                    }
                                    else
                                    {
                                        try
                                        {
                                            if (!ctxService.Request.Init(req))
                                            {
                                                context.Response.Status = ApiEngineRunStatus.IncompleteApiData;
                                                context.Log.Debug(Category, Operation, context.Response.GetStatus());
                                                callService = false;
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            callService = false;
                                            context.Response.Status = ApiEngineRunStatus.InvalidApiData;
                                            context.Log.Danger(Category, Operation, context.Response.GetStatus(), e);
                                        }
                                    }
                                }

                                if (callService)
                                {
                                    var apiRequest = ctxService.Request as ApiBaseRequest;

                                    if (apiRequest != null)
                                    {
                                        apiRequest.CallContext = context.Request.CallContext;
                                    }

                                    if (api.Async && async)
                                    {
                                        await ctxService.RunAsync();
                                    }
                                    else
                                    {
                                        ctxService.Run();
                                    }

                                    response.Source = ctxService.Response.Source;
                                    response.Status = ctxService.Response.GetStatus();
                                    response.Data = ctxService.Response.GetData();
                                    response.Success = ctxService.Response.Success;
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            context.Response.Status = ApiEngineRunStatus.ApiCallError;
                            context.Log.Danger(Category, Operation, context.Response.GetStatus(), e);
                        }
                    }
                    else
                    {
                        context.Response.Status = ApiEngineRunStatus.InvalidMethod;
                    }
                }
                else
                {
                    context.Response.Status = ApiEngineRunStatus.ServiceNotResolved;
                }
            }
            else
            {
                context.Response.Status = ApiEngineRunStatus.ServiceNotFound;
            }
        }
        private async Task finaizeResponse(ApiEngineRunContext context)
        {
            var Request = context.Request.CallContext.HttpContext.Request;
            var isOptions = string.Compare(Request.HttpMethod, "options", StringComparison.OrdinalIgnoreCase) == 0;
            var responseString = "";

            if (!isOptions)
            {
                var api = context.Request.CallContext.Api;
                var response = context.Request.CallContext.ApiResponse;
                var customer = context.Request.CallContext.Customer;
                var encryptionCode = (customer != null) ? customer.EncryptionCode : "";
                var encryptResponse = (api != null) ? api.EncryptResponse : false;

                // it seems there's no need to add this dialog message
                //if (!context.Response.Success)
                //{
                //    context.Log.Dialog(Category, Operation,
                //        context.Response.GetStatus());
                //}

                context.Log.Trace(Category, Operation, "initializing Message Provider");

                var mc = new BabbageMessageProvider(translator, cacheFactory.Get(CacheName.Messages));
                mc.BasePath = ApplicationPath.Root + "..\\..\\Messages";
                mc.Load("");

                if (string.Compare(context.Request.Lang, "En", StringComparison.OrdinalIgnoreCase) == 0)
                    mc.Lang = Lang.En;
                else
                    mc.Lang = Lang.Fa;

                if (string.IsNullOrEmpty(response.Status))
                {
                    response.Status = context.Response.GetStatus();
                    response.Source = DataSource.Framework;
                }

                response.Messages = mc.Render(context.Log);
                response.Date = DateTime.Now;

                context.Log.Trace(Category, Operation, "json serializing final result");

                try
                {
                    if (SafeClrConvert.ToBoolean(context.Request.CallContext?.Service?.Settings.ContainsKey("UseAsyncResponseSerialization")) &&
                        SafeClrConvert.ToBoolean(context.Request.CallContext?.Service?.Settings["UseAsyncResponseSerialization"]))
                    {
                        responseString = await response.ToJsonAsync(context);
                    }
                    else
                    {
                        responseString = response.ToJson(context);
                    }

                    if (encryptResponse)
                    {
                        if (!string.IsNullOrEmpty(encryptionCode))
                        {
                            context.Log.Trace(Category, Operation, "encrypting final result");

                            try
                            {
                                responseString = crypt.Encrypt(responseString, encryptionCode);
                                context.Response.EncryptedResult = true;
                                context.Response.Succeeded();
                            }
                            catch (Exception e)
                            {
                                logger.LogException(e);

                                response.Data = null;
                                context.Log.Danger(Category, Operation, "EncryptResultError", e, MessageSource.Framework);
                                response.Messages = mc.Render(context.Log);
                                responseString = JsonConvert.SerializeObject(response);
                            }
                        }
                        else
                        {
                            response.Data = null;
                            context.Log.Warning(Category, Operation, "NoKeyToEncryptResult", MessageSource.Framework);
                            response.Messages = mc.Render(context.Log);
                            responseString = JsonConvert.SerializeObject(response);
                        }
                    }
                    else
                    {
                        if (api != null)
                        {
                            context.Response.Succeeded();
                        }
                    }
                }
                catch (Exception e)
                {
                    responseString = "";
                    context.Response.Status = ApiEngineRunStatus.ResultSerializationError;
                }
            }
            else
            {
                context.Response.Succeeded();
            }

            context.Response.Result = responseString;
        }
        private async Task<bool> checkApiAccess(ApiEngineRunContext context)
        {
            var apiId = context.Request.CallContext.Api.ApiId.Value;
            var apiClientId = context.Request.CallContext.Client.ApiClientId.Value;
            var customer = context.Request.CallContext.Customer;
            var apiClientCustomerId = (customer != null) ? customer.ApiClientCustomerId : 0;
            var response = context.Request.CallContext.ApiResponse;
            var result = false;

            context.Log.Trace(Category, Operation, "creating context for ApiService: CheckAccess");
            var ctxApi = await apiService.CheckAccess.InvokeAsync(context, new { ApiId = apiId, ApiClientId = apiClientId, ApiClientCustomerId = apiClientCustomerId });

            if (!ctxApi.Response.Success)
            {
                response.Status = ctxApi.ServiceName + "." + ctxApi.Response.GetStatus();

                goto exit_step;
            }

            result = true;
            exit_step:
            return result;
        }

    }
}