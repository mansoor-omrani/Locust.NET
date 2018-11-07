using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Base;

namespace Locust.Model
{
    public class ModelReadTemplateItemEqualityComparer : IEqualityComparer<ModelReadTemplateItem>
    {
        public bool IgnoreCaseOnValue { get; set; }
        public ModelReadTemplateItemEqualityComparer()
        { }

        public ModelReadTemplateItemEqualityComparer(bool ignoreCaseOnValue)
        {
            IgnoreCaseOnValue = ignoreCaseOnValue;
        }
        public bool Equals(ModelReadTemplateItem x, ModelReadTemplateItem y)
        {
            if (x == null && y == null)
                return true;

            if (x == null || y == null)
                return false;

            if (x.SourceComparison != y.SourceComparison)
                return false;

            if (x.TargetIgnoreCase != y.TargetIgnoreCase)
                return false;
            var result = true;
            if (x.SourceComparison.HasValue)
            {
                result &= string.Compare(x.Source, y.Source, x.SourceComparison.Value) == 0 &&
                          x.Conversion == y.Conversion &&
                          (new ModelTemplateItemArgsEqualityComparer(IgnoreCaseOnValue)).Equals(x.Args, y.Args) &&
                          x.Ignore == y.Ignore;
            }
            else
            {
                result &= string.Compare(x.Source, y.Source, StringComparison.OrdinalIgnoreCase) == 0 &&
                          x.Conversion == y.Conversion &&
                          (new ModelTemplateItemArgsEqualityComparer(IgnoreCaseOnValue)).Equals(x.Args, y.Args) &&
                          x.Ignore == y.Ignore;
            }

            if (!result)
                return false;

            if (x.TargetIgnoreCase.HasValue)
            {
                result &= string.Compare(x.Target, y.Target, x.TargetIgnoreCase.Value) == 0;
            }
            else
            {
                result &= string.Compare(x.Target, y.Target, StringComparison.OrdinalIgnoreCase) == 0;
            }
            return result;
        }

        public int GetHashCode(ModelReadTemplateItem obj)
        {
            throw new NotImplementedException();
        }
    }
}
