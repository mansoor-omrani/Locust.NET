using System;

namespace Locust.Web.Html
{
	public class HtmlHeading1 : HtmlHeading
    {
        public override int Number
        {
            get
            {
                return 1;
            }
            set
            {
                throw new Exception("This property is readonly");
            }
        }
    }
	public class HtmlHeading2 : HtmlHeading
    {
        public override int Number
        {
            get
            {
                return 2;
            }
            set
            {
                throw new Exception("This property is readonly");
            }
        }
    }
	public class HtmlHeading3 : HtmlHeading
    {
        public override int Number
        {
            get
            {
                return 3;
            }
            set
            {
                throw new Exception("This property is readonly");
            }
        }
    }
	public class HtmlHeading4 : HtmlHeading
    {
        public override int Number
        {
            get
            {
                return 4;
            }
            set
            {
                throw new Exception("This property is readonly");
            }
        }
    }
	public class HtmlHeading5 : HtmlHeading
    {
        public override int Number
        {
            get
            {
                return 5;
            }
            set
            {
                throw new Exception("This property is readonly");
            }
        }
    }
	public class HtmlHeading6 : HtmlHeading
    {
        public override int Number
        {
            get
            {
                return 6;
            }
            set
            {
                throw new Exception("This property is readonly");
            }
        }
    }
}