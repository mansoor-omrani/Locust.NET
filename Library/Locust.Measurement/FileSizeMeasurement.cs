using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Measurement
{
    public enum FileSizeUnit
    {
        Auto,
        Bit,
        Byte,
        KiloByte,
        MegaByte,
        GigaByte,
        TeraByte,
        PetaByte,
        ExaByte
    }
    public struct FileSizeValue
    {
        public double Value { get; set; }
        public FileSizeUnit Unit { get; set; }
        public string Render(string lang)
        {
            var result = "";



            return result;
        }
    }
    public class FileSize
    {
        private long size;
        private double? calculatedSize;
        private FileSizeUnit unit;
        private FileSizeUnit calculatedUnit;
        public FileSize()
            : this(0)
        {
        }
        public FileSize(long size)
        {
            this.size = size;
            this.unit = FileSizeUnit.Auto;

            calculatedSize = calculate(this.size, this.unit, out calculatedUnit);
        }
        public FileSize(long size, FileSizeUnit unit)
        {
            this.unit = unit;

            Size = size;
        }
        public long Size
        {
            get { return size; }
            set
            {
                size = value;

                calculatedSize = calculate(this.size, this.unit, out calculatedUnit);
            }
        }
        public FileSizeUnit Unit
        {
            get { return unit; }
            set
            {
                this.unit = value;

                calculatedSize = calculate(this.size, this.unit, out calculatedUnit);
            }
        }
        private double calculate(long size, FileSizeUnit unit, out FileSizeUnit calculatedUnit)
        {
            double result = 0;

            calculatedUnit = unit;

            if (unit == FileSizeUnit.Byte)
            {
                result = size;
            }
            else if (unit == FileSizeUnit.KiloByte)
            {
                result = size / Math.Pow(2, 10);
            }
            else if (unit == FileSizeUnit.MegaByte)
            {
                result = size / Math.Pow(2, 20);
            }
            else if (unit == FileSizeUnit.GigaByte)
            {
                result = size / Math.Pow(2, 30);
            }
            else if (unit == FileSizeUnit.TeraByte)
            {
                result = size / Math.Pow(2, 40);
            }
            else if (unit == FileSizeUnit.PetaByte)
            {
                result = size / Math.Pow(2, 50);
            }
            else if (unit == FileSizeUnit.ExaByte)
            {
                result = size / Math.Pow(2, 60);
            }
            else if (unit == FileSizeUnit.Auto)
            {
                if (size >= Math.Pow(2, 60))
                {
                    result = size / Math.Pow(2, 60);

                    calculatedUnit = FileSizeUnit.ExaByte;
                }
                else if (size >= Math.Pow(2, 50))
                {
                    result = size / Math.Pow(2, 50);

                    calculatedUnit = FileSizeUnit.PetaByte;
                }
                else if (size >= Math.Pow(2, 40))
                {
                    result = size / Math.Pow(2, 40);

                    calculatedUnit = FileSizeUnit.TeraByte;
                }
                else if (size >= Math.Pow(2, 30))
                {
                    result = size / Math.Pow(2, 30);

                    calculatedUnit = FileSizeUnit.GigaByte;
                }
                else if (size >= Math.Pow(2, 20))
                {
                    result = size / Math.Pow(2, 20);

                    calculatedUnit = FileSizeUnit.MegaByte;
                }
                else if (size >= Math.Pow(2, 10))
                {
                    result = size / Math.Pow(2, 10);

                    calculatedUnit = FileSizeUnit.KiloByte;
                }
                else
                {
                    result = size;

                    calculatedUnit = FileSizeUnit.Byte;
                }
            }

            return result;
        }
        public FileSizeValue Render()
        {
            var result = new FileSizeValue { Value = calculatedSize.Value, Unit = calculatedUnit };

            return result;
        }
    }
}
