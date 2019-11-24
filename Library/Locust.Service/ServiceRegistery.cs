using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Service
{
    public enum LifeTime
    {
        Transient,
        Singleton,
        PerRequest,
        PerThread,
        Custom
    }
    public class RegisteryEntry
    {
        public Type Abstraction { get; set; }
        public Type Concretion { get; set; }
        public LifeTime LifeTime { get; set; }
        public object Data { get; set; }
    }
    public abstract class ServiceRegistery
    {
        public List<RegisteryEntry> Registery { get; set; }
        public ServiceRegistery()
        {
            Registery = new List<RegisteryEntry>();
        }
        public void Add(Type asbtraction, Type concretion, LifeTime life = LifeTime.Transient, object data = null)
        {
            Registery.Add(new RegisteryEntry
            {
                Abstraction = asbtraction,
                Concretion = concretion,
                LifeTime = life,
                Data = data
            });
        }
    }
}
