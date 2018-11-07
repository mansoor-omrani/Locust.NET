using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Locust.Conversion;
using Locust.Translation;
using Locust.ServiceLocator;

namespace Locust.Utils
{
    public class GlobalConfig
    {
        private static Locust.Utils.Convert _convert;
        private static Locust.Utils.ForceConvert _forceconvert;
        private static Locust.Utils.Translation _translation;
        private static IServiceLocator _locator;
        static GlobalConfig()
        {
            _convert = new Locust.Utils.Convert();
            _forceconvert = new Locust.Utils.ForceConvert();
            _translation = new Locust.Utils.Translation();
            _locator = Locust.ServiceLocator.Locator.Default;

            _locator.RegisterInstanceFor<Locust.Conversion.IConvert, Locust.Conversion.Convert, Locust.Utils.Convert>();
            _locator.RegisterInstanceFor<Locust.Conversion.IConvert, Locust.Conversion.ForceConvert, Locust.Utils.ForceConvert>();
            _locator.RegisterInstanceFor<Locust.Translation.ITranslator, Locust.Translation.FileBasedTranslator, Locust.Utils.Translation>();
        }
        public static void SetLocator(IServiceLocator locator)
        {
            Interlocked.Exchange(ref _locator, locator);
        }
        public static IServiceLocator Locator
        {
            get
            {
                return _locator;
            }
        }
        public static IConvert Convert
        {
            get
            {
                return _locator.GetServiceFor<IConvert>(_convert);
            }
        }
        public static IConvert ForceConvert
        {
            get
            {
                return _locator.GetServiceFor<IConvert>(_forceconvert);
            }
        }
        public static ITranslator Translation
        {
            get
            {
                return _locator.GetServiceFor<ITranslator>(_translation);
            }
        }
    }
}
