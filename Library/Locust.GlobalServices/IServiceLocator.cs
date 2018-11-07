using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.GlobalServices
{
    public interface IServiceLocator
    {
        void Register(Type abstraction, Type concretion, string lifetimeType);
        void Register(Type abstraction, string lifetimeType, Func<IServiceLocator, object> factory);
        void RegisterFor(Type abstraction, Type concretion, Type requester, string lifetimeType);
        void RegisterFor(Type abstraction, Type requester, string lifetimeType, Func<IServiceLocator, object> factory);
        void Unregister(Type abstraction);
        void Unregister(Type abstraction, Type requester);
        object GetService(Type abstraction);
        object GetServiceFor(Type abstraction, object x);
        object GetServiceFor(Type abstraction, Type requester);
        bool Contains(Type abstraction);
        bool ContainsFor(Type abstraction, Type requester);
        bool ContainsFor(Type abstraction, object requester);
    }
}
