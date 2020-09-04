namespace Locust.Base
{
    public class InstanceProvider<TAbstraction, TImplementation>
        where TImplementation : TAbstraction, new()
    {
        private static TAbstraction _instance;
        public static TAbstraction Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TImplementation();
                }
                return _instance;
            }
            set { _instance = value; }
        }
    }
}