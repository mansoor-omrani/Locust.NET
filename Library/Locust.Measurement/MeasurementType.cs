using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Measurement
{
    // reference: https://www.convert-me.com/en/unitlist.html
    public enum MeasurementType
    {
        Distance,
        Area,
        Volume,
        Angle,
        Weight,
        Time,
        ComputerDataSize,
        ComputerTransferRate,
        Speed,
        Accelaration,
        Density,
        Pressure,
        Energy,
        Power,
        Force,
        Temperature,
        Radiation,
        RadioActivity,
        Currency,
        Fuel,
        Food,
        FoodPrice
    }
    public enum MeasurementUnit
    {
        Nano,
        Micro,
        Milli,
        Centi,
        Deci,
        Kilo,
        Mega,
        Giga,
        Peta,
        Exa
    }
}
