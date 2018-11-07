using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Model
{
    public class ModelTemplateItemArgsEqualityComparer : IEqualityComparer<ModelTemplateItemArgs>
    {
        public bool IgnoreCaseOnValues { get; set; }
        public ModelTemplateItemArgsEqualityComparer()
        { }

        public ModelTemplateItemArgsEqualityComparer(bool ignoreCaseOnValues)
        {
            IgnoreCaseOnValues = ignoreCaseOnValues;
        }
        public bool Equals(ModelTemplateItemArgs x, ModelTemplateItemArgs y)
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

        public int GetHashCode(ModelTemplateItemArgs obj)
        {
            throw new NotImplementedException();
        }
    }
}
