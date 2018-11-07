using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Locust.Conversion;

namespace Locust.Caching
{
    public class CacheItem
    {
        protected ICacheManager Parent { get; set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime LastAccessed { get; private set; }
        protected int accessCount;

        public int AccessCount
        {
            get { return accessCount; }
        }
        public int LifeLength { get; private set; }
        public int ExpireSpan { get; private set; }
        public object Data { get; set; }

        public CacheItem(ICacheManager parent) : this(parent, 0, 0)
        { }
        public CacheItem(ICacheManager parent, int expireSpan, int lifeLength)
        {
            this.Parent = parent;
            CreatedDate = LastAccessed = Parent.Now.Value;

            if (lifeLength > 0)
            {
                LifeLength = lifeLength;
            }

            if (expireSpan > 0)
            {
                ExpireSpan = expireSpan;
            }
        }
        public int RemainingLife
        {
            get
            {
                var result = SafeClrConvert.ToInt32(LifeLength - (Parent.Now.Value - CreatedDate).TotalSeconds);

                if (result < 0)
                    result = 0;

                return result;
            }
        }

        public int Elapsed
        {
            get
            {
                var result = SafeClrConvert.ToInt32((Parent.Now.Value - LastAccessed).TotalSeconds);

                if (result < 0)
                    result = 0;

                return result;
            }
        }

        private bool? isDead;
        public bool IsDead
        {
            get
            {
                return (isDead.HasValue && isDead.Value) || (LifeLength > 0 && RemainingLife == 0);
            }
            set { isDead = value; }
        }
        public bool IsExpired
        {
            get
            {
                if (ExpireSpan == 0)
                    return false;

                var result = (Parent.Now.Value - LastAccessed).TotalSeconds;

                if (result < 0)
                    result = 0;

                return result > ExpireSpan;
            }
        }
        public void IncAccess()
        {
            LastAccessed = Parent.Now.Value;
            Interlocked.Increment(ref accessCount);
        }
    }
    public class CacheItem<T> : CacheItem
    {
        public new T Data { get; set; }
        public CacheItem(ICacheManager parent) : base(parent, 0, 0)
        { }
        public CacheItem(ICacheManager parent, int expireSpan, int lifeLength) : base(parent, expireSpan, lifeLength)
        {
        }
    }
}
