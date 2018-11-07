using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Model
{
    public class ModelReadTemplateEqualityComparer : IEqualityComparer<ModelReadTemplate>
    {
        public bool IgnoreCaseOnValues { get; set; }
        public ModelReadTemplateEqualityComparer()
        { }

        public ModelReadTemplateEqualityComparer(bool ignoreCaseOnValues)
        {
            IgnoreCaseOnValues = ignoreCaseOnValues;
        }
        public bool Equals(ModelReadTemplate x, ModelReadTemplate y)
        {
            if (x == null && y == null)
                return true;

            if (x == null || y == null)
                return false;

            if (x.Items.Count != y.Items.Count)
                return false;

            var mrtiec = new ModelReadTemplateItemEqualityComparer(IgnoreCaseOnValues);

            for (var i = 0; i < x.Items.Count; i++)
            {
                if (mrtiec.Equals(x.Items[i], y.Items[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public int GetHashCode(ModelReadTemplate obj)
        {
            throw new NotImplementedException();
        }
    }
}
