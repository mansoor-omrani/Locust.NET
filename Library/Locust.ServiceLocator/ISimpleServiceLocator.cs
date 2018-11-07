using System;
namespace Locust.ServiceLocator
{
    public interface ISimpleServiceLocator
    {
        T GetService<T>();
        object GetService(Type type);
        bool Unregister<T>();
        bool Unregister(Type type);
        bool Register<T, U>(bool stat = false) where U : new();
        bool Register<T, U>(bool singleton, bool stat) where U : new();
        bool Register<T, U>(U u, bool stat = false);
        bool Register<T, U>(Func<U> factory, bool stat = false);
        bool Register<T, U>(Func<U> factory, bool singleton, bool stat);
        Tuple<long, long> GetStat<T>();
        Tuple<long, long> GetStat(Type t);
    }
}