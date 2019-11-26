using Locust.Base;
using System;
using System.Collections;
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
        public IEqualityComparer DataComparer { get; set; }
        public ServiceRegistery()
        {
            Registery = new List<RegisteryEntry>();
            DataComparer = new DefaultObjectEqualityComparer();
        }
        public void Add(Type asbtraction, Type concretion, LifeTime life = LifeTime.Transient, object data = null)
        {
            if (Registery.FindIndex(r => r.Abstraction == asbtraction && r.Concretion == concretion && r.LifeTime == life && DataComparer.Equals(r.Data, data)) < 0)
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
}
