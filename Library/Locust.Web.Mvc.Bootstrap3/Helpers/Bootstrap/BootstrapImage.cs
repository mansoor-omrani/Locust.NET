using Locust.Web.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Web.Mvc.Bootstrap3.Helpers.Bootstrap
{
    public enum ImageShape { none, rounded, circle, thumbnail }
    public class BootstrapImage : HtmlImage
    {
        private string GetClass(ImageShape shape)
        {
            return shape != ImageShape.none ? "img-" + Shape.ToString() : "";
        }
        private ImageShape shape;
        public ImageShape Shape
        {
            get
            {
                return shape;
            }
            set
            {
                var @class = GetClass(shape);
                if (!string.IsNullOrEmpty(@class))
                    Classes.Remove(@class);

                shape = value;

                @class = GetClass(shape);
                if (!string.IsNullOrEmpty(@class))
                    Classes.Add(@class);
            }
        }
        private bool responsive;
        public bool Responsive
        {
            get
            {
                return responsive;
            }
            set
            {
                responsive = value;

                if (!value)
                    Classes.Remove("img-responsive");
                else
                    Classes.Add("img-responsive");
            }
        }
    }
}
