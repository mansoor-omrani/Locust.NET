using System;
using System.Security.Cryptography;
namespace Locust.RandomGenerator
{
    public class SimpleRandomGenerator : IRandomGenerator
    {
        private static readonly RandomNumberGenerator rng = RandomNumberGenerator.Create();
        public string Generate(RandomGeneratorSetting setting)
        {
            var result = "";
            //var chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            var min = 0;
            var max = 62;
            var minEx = -1;
            var maxEx = -1;

            switch (setting.Type)
            {
                case RandomCodeType.AlphaLow:
                    min = 36;
                    break;
                case RandomCodeType.AlphaUp:
                    min = 10;
                    max = 36;
                    break;
                case RandomCodeType.Alpha:
                    min = 10;
                    break;
                case RandomCodeType.Num:
                    max = 10;
                    break;
                case RandomCodeType.NumNoZero:
                    min = 1;
                    max = 10;
                    break;
                case RandomCodeType.AlphaUpNum:
                    max = 36;
                    break;
                case RandomCodeType.AlphaLowNum:
                    minEx = 10;
                    maxEx = 36;
                    break;
            }

            byte[] seed = new byte[3];
            //var rng = RandomNumberGenerator.Create();
            rng.GetBytes(seed);
            int l = 1;
            for (var i = 0; i < seed.Length; i++)
                l *= seed[i];
            
            var r = new Random((int)DateTime.Now.Ticks * l);

            for (var i = 0; i < setting.Length; i++)
            {
                var ok = false;
                var index = -1;

                while (!ok)
                {
                    index = r.Next(min, max);
                    ok = !(minEx >= 0 && maxEx >= 0 && index >= minEx && index < maxEx);
                }
                var b = -1;
                if (index < 10)
                    b = 48;
                else if (index >= 10 && index < 36)
                    b = 55;
                else
                {
                    b = 61;
                }
                result += (char)(b + index);
            }

            return result;
        }
    }
}