using System;
using Locust.Caching;
using Locust.Compression;
using Locust.Cryptography;
using Locust.Db;
using Locust.Logging;
using Locust.Modules.Api.Service;
using Locust.Modules.Base.Service;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Tracing;
using Locust.Translation;

namespace Locust.Modules.Api.Strategies
{
	public abstract class ApiEngineRunStrategyBase : BaseServiceStrategy<ApiEngineRunResponse, object, ApiEngineRunStatus, ApiEngineRunRequest, ApiEngineRunContext>
	{
        protected ApiEngineServiceBase Service
        {
            get { return Store.Service as ApiEngineServiceBase; }
        }
        protected ApplicationServiceBase appService;
	    protected AppCrossOriginServiceBase appCrossOriginService;
	    protected ApiClientServiceBase clientService;
	    protected ApiClientCustomerHubService customerHubService;
	    protected ApiClientCustomerServiceBase customerService;
	    protected ApiClientIPServiceBase clientIPService;
	    protected ApiServiceBase apiService;
	    protected ApiSettingServiceBase apiSettingService;
	    protected IBase64Compression compression;

        protected IDebugRequestGetter debugger;
	    protected IEncryption crypt;
	    protected IExceptionLogger logger;
	    protected ITranslation translator;
	    protected ICacheFactory cacheFactory;
        public ApiEngineRunStrategyBase(ApplicationServiceBase appService,
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
		{
            if (appService == null)
                throw new ArgumentNullException("appService");
            if (appCrossOriginService == null)
                throw new ArgumentNullException("appCrossOriginService");
            if (clientService == null)
                throw new ArgumentNullException("clientService");
            if (customerHubService == null)
                throw new ArgumentNullException("customerHubService");
            if (customerService == null)
                throw new ArgumentNullException("customerService");
            if (clientIPService == null)
                throw new ArgumentNullException("clientIPService");
            if (apiService == null)
                throw new ArgumentNullException("apiService");
            if (apiSettingService == null)
                throw new ArgumentNullException("apiSettingService");
            if (compression == null)
                throw new ArgumentNullException("compression");
            if (debugger == null)
                throw new ArgumentNullException("debugger");
            if (crypt == null)
                throw new ArgumentNullException("crypt");
            if (logger == null)
                throw new ArgumentNullException("logger");
            if (translator == null)
                throw new ArgumentNullException("translator");
            if (cacheFactory == null)
                throw new ArgumentNullException("cacheFactory");

		    this.appService = appService;
            this.appCrossOriginService = appCrossOriginService;
            this.clientService = clientService;
            this.customerHubService = customerHubService;
            this.customerService = customerService;
            this.clientIPService = clientIPService;
            this.apiService = apiService;
		    this.compression = compression;
            this.debugger = debugger;
            this.crypt = crypt;
            this.logger = logger;
            this.translator = translator;
            this.cacheFactory = cacheFactory;
		    this.apiSettingService = apiSettingService;
		}
    }
}