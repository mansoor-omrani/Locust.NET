using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Locust.StateProvider
{
    [Serializable]
    public class StateProviderItem
    {
        internal bool Removed { get; set; }
        internal bool Stored { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModified { get; set; }
        public StateProviderItem()
        {
            CreatedDate = DateTime.Now;
        }
    }
    public interface IStateProvider<T> where T: class, new()
    {
        string Name { get; }
        T Value { get; set; }
        StateProviderItem Stat { get; }
        void Remove();
        void Restore();
        void Store();
        bool Exists();
    }
}
