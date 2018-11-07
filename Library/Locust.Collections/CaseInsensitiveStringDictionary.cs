using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Collections
{
    public enum ChangeStatus
    {
        NotChange,
        KeyNotFound,
        ValueNotFound,
        Added,
        Updated
    };
    public class ChangeArgs
    {
        public string DefaultValue { get; set; }
        public StringComparison ValueComparison { get; set; }
        public string[] Values { get; set; }
        public bool AllowReplace { get; set; }
        public ChangeStatus Status { get; set; }
        public string Result { get; set; }
        public ChangeArgs()
        {
            ValueComparison = StringComparison.OrdinalIgnoreCase;
        }
    }
    public class CaseInsensitiveStringDictionary: CaseInsensitiveDictionary<string>
    {
        public CaseInsensitiveStringDictionary(bool ignoreNotExistingKeys):base(ignoreNotExistingKeys)
        {
        }
        public CaseInsensitiveStringDictionary()
        {
        }
        public override string Get(string key, string defaultValue = null)
        {
            var result = defaultValue;

            if (items.ContainsKey(key))
            {
                result = items[key];

                if (string.IsNullOrEmpty(result) || string.IsNullOrWhiteSpace(result))
                {
                    result = defaultValue;
                }
            }

            return result;
        }

        public string Change(string key, ChangeArgs lookup)
        {
            var result = lookup.DefaultValue;
            var keyNotFound = true;
            var valueNotFound = true;

            if (items.ContainsKey(key))
            {
                keyNotFound = false;
                result = items[key];

                if (lookup.Values != null)
                {
                    foreach (var value in lookup.Values)
                    {
                        if (string.Compare(result, value, lookup.ValueComparison) == 0)
                        {
                            valueNotFound = false;
                            result = value;
                            break;
                        }
                    }

                    if (valueNotFound)
                    {
                        result = lookup.DefaultValue;
                    }
                }
                
                if (string.IsNullOrEmpty(result) || string.IsNullOrWhiteSpace(result))
                {
                    result = lookup.DefaultValue;
                }
            }

            if (lookup.AllowReplace)
            {
                if (keyNotFound)
                {
                    items.Add(key, result);
                }
                else
                {
                    if (valueNotFound)
                    {
                        items[key] = result;
                    }
                }
            }

            if (keyNotFound)
            {
                if (lookup.AllowReplace)
                {
                    lookup.Status = ChangeStatus.Added;
                }
                else
                {
                    lookup.Status = ChangeStatus.KeyNotFound;
                }
            }
            else
            {
                if (lookup.AllowReplace)
                {
                    if (valueNotFound)
                    {
                        lookup.Status = ChangeStatus.Updated;
                    }
                    else
                    {
                        lookup.Status = ChangeStatus.NotChange;
                    }
                }
                else
                {
                    if (valueNotFound)
                    {
                        lookup.Status = ChangeStatus.ValueNotFound;
                    }
                    else
                    {
                        lookup.Status = ChangeStatus.NotChange;
                    }
                }
            }

            lookup.Result = result;

            return result;
        }
    }

    public class CaseInsensitiveStringDictionaryEqualityComparer : IEqualityComparer<CaseInsensitiveStringDictionary>
    {
        public bool IgnoreCaseOnValues { get; set; }
        public CaseInsensitiveStringDictionaryEqualityComparer()
        { }

        public CaseInsensitiveStringDictionaryEqualityComparer(bool ignoreCaseOnValues)
        {
            IgnoreCaseOnValues = ignoreCaseOnValues;
        }
        public bool Equals(CaseInsensitiveStringDictionary x, CaseInsensitiveStringDictionary y)
        {
            if (x == null && y == null)
                return true;

            if (x == null || y == null)
                return false;

            foreach (var item in x)
            {
                if (!y.ContainsKey(item.Key))
                {
                    return false;
                }
                if (string.Compare(item.Value, y[item.Key], IgnoreCaseOnValues) != 0)
                {
                    return false;
                }
            }

            return true;
        }

        public int GetHashCode(CaseInsensitiveStringDictionary obj)
        {
            throw new NotImplementedException();
        }
    }
}
