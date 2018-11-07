using System;

namespace Locust.Web.Html
{
    public class HtmlHeading : HtmlElement
    {
        public virtual int Number { get; set; }
        public override string TagName
        {
            get
            {
                return "h" + Number;
            }

            protected set
            {
                throw new Exception("This property is readonly");
            }
        }
    }
}
