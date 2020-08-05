using System;
using System.Collections.Generic;
using System.Text;

namespace Locust.Collections
{
    public static class CollectionsExtensions
    {
        public static void MergeWith<T>(this CaseInsensitiveDictionary<T> target, IDictionary<string, T> settings)
        {
            if (settings?.Count > 0)
            {
                foreach (var item in settings)
                {
                    target[item.Key] = item.Value;
                }
            }
        }
    }
}
