using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Locust.Db;
using Locust.Tracing;
using MessageType = Locust.Tracing.MessageType;

namespace Locust.ServiceModel
{
    public interface IServiceStrategyContext
    {
        IBaseServiceRequest Request { get; set; }
        IBaseServiceResponse Response { get; set; }
        MessageList Log { get; set; }
        IBaseServiceStrategy Strategy { get; set; }
        IServiceStrategyContext Root { get; }
        IServiceStrategyContext Parent { get; set; }
        List<IServiceStrategyContext> Children { get; }
        bool Ready { get; set; }
        void Run();
        Task RunAsync();
        string ServiceName { get; }
    }
    public class ServiceStrategyContext<TResponse, UData, VStatus, WRequest> : IServiceStrategyContext
        where TResponse : BaseServiceResponse<UData, VStatus>, new()
        where WRequest : class, IBaseServiceRequest, new()
    {
        private WRequest request;
        public WRequest Request
        {
            get
            {
                if (request == null)
                {
                    request = new WRequest();
                }

                return request;
            }
            set { request = value as WRequest; }
        }
        IBaseServiceRequest IServiceStrategyContext.Request
        {
            get
            {
                if (request == null)
                {
                    request = new WRequest();
                }

                return request;
            }
            set { request = value as WRequest; }
        }
        private TResponse response;

        IBaseServiceResponse IServiceStrategyContext.Response
        {
            get
            {
                if (response == null)
                {
                    response = new TResponse();
                }

                return response;
            }
            set { response = value as TResponse; }
        }
        public TResponse Response
        {
            get
            {
                if (response == null)
                {
                    response = new TResponse();
                }

                return response;
            }
            set { response = value as TResponse; }
        }
        private MessageList log;

        public MessageList Log
        {
            get
            {
                if (log == null)
                {
                    log = new MessageList();
                }

                return log;
            }
            set { log = value; }
        }
        private IBaseServiceStrategy strategy;
        public IBaseServiceStrategy Strategy
        {
            get { return strategy; }
            set
            {
                if (strategy == null)
                {
                    strategy = value;
                }
            }
        }
        private IServiceStrategyContext parent;
        public IServiceStrategyContext Parent
        {
            get { return parent; }
            set
            {
                if (parent == null)
                {
                    parent = value;

                    if (parent != null)
                    {
                        var x = parent;
                        while (x.Parent != null)
                        {
                            x = x.Parent;
                        }
                        root = x;
                    }
                }
            }
        }
        private IServiceStrategyContext root;
        public IServiceStrategyContext Root
        {
            get { return root; }
        }
        private List<IServiceStrategyContext> children;
        public List<IServiceStrategyContext> Children
        {
            get { return children; }
            private set { children = value; }
        }
        public ServiceStrategyContext()
        {
            children = new List<IServiceStrategyContext>();
            Ready = true;
        }
        public ServiceStrategyContext(IBaseServiceStrategy strategy)
            : this()
        {
            this.strategy = strategy;
        }
        public bool Ready { get; set; }
        public void Run()
        {
            var category = Strategy.Store.Service.Name;
            var operation = Strategy.Name;

            try
            {
                Log.EnterScope();
                Log.Trace(new MessageItem { Category = category, Operation = operation, Code = "sys_trace_call_start" });
                Log.System(new MessageItem { Category = category, Operation = operation, Code = "request", GetInfo = () => Request.ToJson() });
                
                strategy.Run(this);

                // if we are using EntityFramework or SQL-Text in our strategies we can do auditing here.
                // this in turn requires to run strategy in a transaction context.
                // if we are using SPROCs in our strategies (e.g. ServiceModel.Babbage) we don't need to do
                // auditing here. we can do auditing in SPROCs

                if (this.Response.IsSuccessfull())
                {
                    // Audit(this.Response.Status);
                }
                
                Log.System(new MessageItem { Category = category, Operation = operation, Code = "response", GetInfo = () => Response.ToJson() });
                Log.Trace(new MessageItem { Category = category, Operation = operation, Code = "sys_trace_call_end" });
                Log.ExitScope();
            }
            catch (Exception e)
            {
                Response.Faulted();
                Log.Danger(new MessageItem { Category = category, Operation = operation, Code = Response.GetStatus(), Exception = e, Source = MessageSource.Framework });
                Log.Dialog(new MessageItem { Category = category, Operation = operation, Code = Response.GetStatus() });

                // logging the exception
                Strategy.Store.Service.Logger.LogException(e, category + "." + operation);

                // other than logging the exception we need to inform support team, administrators or developers
                // of the website regarding this exception so that they can resolve the issue soon.
                // Danger(this.Strategy.Name, e);

                // it is important to know that it would be much better to have a factorizing mechanism that prevents myriads of similar notifications.
                // Suppose there is a bug in our code such as Null reference exception. In a high-load website with thousands of users
                // thousands of exceptions will raise and thousands of notifications will be sent to administrators.
                // It would be much better to factorize similar events and notify administrators painstakingly.
                // for example we can use a Notifications(Event, Service, Strategy, Count) table, increase the counter
                // for an event and notify administrators only when the counter reaches a specific limit.
                // when an administrator resolves the issue, we reset the counter.
            }
        }
        public async Task RunAsync()
        {
            var category = Strategy.Store.Service.Name;
            var operation = Strategy.Name;

            try
            {
                Log.EnterScope();
                Log.Trace(new MessageItem { Category = category, Operation = operation, Code = "sys_trace_call_start" });
                Log.System(new MessageItem { Category = category, Operation = operation, Code = "request", GetInfo = () => Request.ToJson() });

                await strategy.RunAsync(this);

                Log.System(new MessageItem { Category = category, Operation = operation, Code = "response", GetInfo = () => Response.ToJson() });
                Log.Trace(new MessageItem { Category = category, Operation = operation, Code = "sys_trace_call_end" });
                Log.ExitScope();
            }
            catch (Exception e)
            {
                Response.Faulted();
                Log.Danger(new MessageItem { Category = category, Operation = operation, Code = Response.GetStatus(), Exception = e, Source = MessageSource.Framework });
                Log.Dialog(new MessageItem { Category = category, Operation = operation, Code = Response.GetStatus() });

                Strategy.Store.Service.Logger.LogException(e, category + "." + operation);
            }
        }

        public string ServiceName
        {
            get
            {
                return Strategy.ServiceName;
            }
        }

        public bool Succeeded
        {
            get { return Response.Success; }
        }
    }

    public class ServiceStrategyContextWeb<TResponse, UData, VStatus, WRequest> : ServiceStrategyContext<TResponse, UData, VStatus, WRequest>
        where TResponse : BaseServiceResponse<UData, VStatus>, new()
        where WRequest : class, IBaseServiceRequest, new()
    {
        private HttpContextBase _httpContext;

        public HttpContextBase HttpContext
        {
            get
            {
                if (_httpContext == null)
                {
                    _httpContext = new HttpContextWrapper(System.Web.HttpContext.Current);
                }
                
                return _httpContext;
            }
            set { _httpContext = value; }
        }
    }
}
