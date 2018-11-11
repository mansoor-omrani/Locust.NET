using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Model;
using Locust.Modules.Base.Fields.AppCrossOrigin;

namespace Locust.Modules.Base.Model.AppCrossOrigin
{
    public class AdminGrid:BaseModel
    {
        private AppCrossOriginId _AppCrossOriginId;
        public AppCrossOriginId AppCrossOriginId
        {
            get
            {
                if (_AppCrossOriginId == null)
                    _AppCrossOriginId = new AppCrossOriginId();
                return _AppCrossOriginId;
            }
            set { _AppCrossOriginId = value; }
        }
        private WithCredentials _WithCredentials;
        public WithCredentials WithCredentials
        {
            get
            {
                if (_WithCredentials == null)
                    _WithCredentials = new WithCredentials();
                return _WithCredentials;
            }
            set { _WithCredentials = value; }
        }
        private Origin _Origin;
        public Origin Origin
        {
            get
            {
                if (_Origin == null)
                    _Origin = new Origin();
                return _Origin;
            }
            set { _Origin = value; }
        }
        private ExposeHeaders _ExposeHeaders;
        public ExposeHeaders ExposeHeaders
        {
            get
            {
                if (_ExposeHeaders == null)
                    _ExposeHeaders = new ExposeHeaders();
                return _ExposeHeaders;
            }
            set { _ExposeHeaders = value; }
        }
        private AllowHeaders _AllowHeaders;
        public AllowHeaders AllowHeaders
        {
            get
            {
                if (_AllowHeaders == null)
                    _AllowHeaders = new AllowHeaders();
                return _AllowHeaders;
            }
            set { _AllowHeaders = value; }
        }
        private MaxAge _MaxAge;
        public MaxAge MaxAge
        {
            get
            {
                if (_MaxAge == null)
                    _MaxAge = new MaxAge();
                return _MaxAge;
            }
            set { _MaxAge = value; }
        }
        protected override IEnumerable<KeyValuePair<string, object>> GetProperties()
        {
            var result = new List<KeyValuePair<string, object>>();

            result.Add(new KeyValuePair<string, object>("AppCrossOriginId", AppCrossOriginId.Value));
            result.Add(new KeyValuePair<string, object>("MaxAge", MaxAge.Value));
            result.Add(new KeyValuePair<string, object>("WithCredentials", WithCredentials.Value));
            result.Add(new KeyValuePair<string, object>("Origin", Origin.Value));
            result.Add(new KeyValuePair<string, object>("ExposeHeaders", ExposeHeaders.Value));
            result.Add(new KeyValuePair<string, object>("AllowHeaders", AllowHeaders.Value));

            return result;
        }
    }
}
