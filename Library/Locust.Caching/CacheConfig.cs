using Locust.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Caching
{
    public class CacheConfig
    {
        public string Name { get; set; }            // name of cache
        public IEncryption Encryption { get; set; } // encryption service that encrypts/decrypts items
        public bool EncryptData { get; set; }       // should the items be encrypted or not
        public int MaxSize { get; set; }            // maximum number of items can be cached
        public int Duration { get; set; }           // how long can items stay in the cache (in seconds)?
        public bool AutoExpire { get; set; }        // should the cache manager automatically mark expired items as Expired or not
        public bool AutoRemoveDeadItems { get; set; }   // should the cache manager automatically remove dead items (those items whose remaining life is zero) and free the memory allocated to expired items or not
        public int Interval { get; set; }           // how frequent does the cache manager's life-time service run (in seconds)?
    }
}
