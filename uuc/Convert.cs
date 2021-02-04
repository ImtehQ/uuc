using System;
using System.Collections.Generic;
using System.Text;
using static uuc.UC_Modules;

namespace uuc
{
    //Universal Unit Convert, yes it needs a better name!
    public static class uuc
    {
        public static double Convert(this double value, string format)
        {
            return value.InnerConvert(format);
        }

        private static double InnerConvert(this double value, string format)
        {
            ///format (xy:xy) x = metric/ imperial (M/I) & y = Type (cm or mm or m)
            ///Convert("Mm:Icm"); > Meteric meter to Imperial centimenr
            format = format.Replace(" ", "");
            string fromTypeStr = format.Substring(0, 1);
            string fromSetStr = format.Substring(1, format.IndexOf(":") - 1);

            string toTypeStr = format.Substring(format.IndexOf(":") + 1, 1);
            string toSetStr = format.Substring((format.IndexOf(":") + 2), (format.Length - (format.IndexOf(":") + 2)));

            UnitType fromType = UC_Modules.GetType(fromTypeStr);
            UnitType toType = UC_Modules.GetType(toTypeStr);

            double baseValue = 0;

            if (fromType == UnitType.None)
            {
                //Error catch here, Type not found!
            }
            if (toType == UnitType.None)
            {
                //Error catch here, Type not found!
            }


            if (fromType == UnitType.Metric)
            {
                //The value is from type Metric, we first need to convert it to base Metric
                baseValue = UC_Metric.ToBaseSetValue(value, fromSetStr);
            }
            else if (fromType == UnitType.Imperial)
            {
                //The value is from type Imperial, we first need to convert it to base Imperial
                baseValue = UC_Imperial.ToBaseSetValue(value, fromSetStr);
            }

            //If it needs to become metric, we then have to check the from set
            if (toType == UC_Modules.UnitType.Metric)
            {
                if (fromType == UC_Modules.UnitType.Imperial)
                    return UC_Metric.ToSetValue(baseValue.FeetToMeter(), toSetStr);

                return UC_Metric.ToSetValue(baseValue, toSetStr);
            }
            else if (toType == UC_Modules.UnitType.Imperial)
            {
                if (fromType == UC_Modules.UnitType.Metric)
                    return UC_Imperial.ToSetValue(baseValue.MeterToFeet(), toSetStr);

                return UC_Imperial.ToSetValue(baseValue, toSetStr);
            }

            return -1;
        }
    }
}
