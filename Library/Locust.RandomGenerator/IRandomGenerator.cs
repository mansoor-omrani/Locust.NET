namespace Locust.RandomGenerator
{
    public enum RandomCodeType
    {
        Alpha = 0,
        AlphaLow = 1,
        AlphaUp = 2,
        Num = 3,
        AlphaLowNum = 4,
        AlphaUpNum = 5,
        AlphaNum = 6,
        NumNoZero = 7
    }

    public class RandomGeneratorSetting
    {
        public RandomCodeType Type { get; set; }
        public short Length { get; set; }

        public RandomGeneratorSetting(RandomCodeType type, short length)
        {
            this.Type = type;
            this.Length = length;
        }
    }
    public interface IRandomGenerator
    {
        string Generate(RandomGeneratorSetting setting);
    }
}