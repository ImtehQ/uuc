using System;
using System.Collections.Generic;
using System.Text;

namespace uuc
{
    public static class UC_Modules
    {
        //Add new line and increese the first number of the array to add more types
        private static string[,] UnitTypes = new string[3, 2] 
        {{"M","Metric"},
        {"I","Imperial"},
        {"B","Bytes" } };

        /// <summary>
        /// Those are the Types to convert from and to
        /// Make sure UnitTypes and UnitType have the same order
        /// </summary>
        public enum UnitType
        {
            Metric,
            Imperial,
            Bytes,
            None // Make sure none is always last!
        }

        /// <summary>
        /// Gets the UnitType based on the string key
        /// Example "M" will be Metric
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static UnitType GetType(string key)
        {
            for (int x = 0; x < UnitTypes.Length; x++)
            {
                if (UnitTypes[x, 0] == key) { return (UnitType)x; }
            }
            return UnitType.None;
        }

        /// <summary>
        /// Converts the value to the base value of its type,
        /// Example 1 KM will be 1000Meter.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <param name="set"></param>
        /// <returns></returns>
        public static double GetBaseValue(UnitType type, double value, string set)
        {
            switch (type)
            {
                case UnitType.Metric:
                    return UC_Metric.ToBaseSetValue(value, set);
                case UnitType.Imperial:
                    return UC_Imperial.ToBaseSetValue(value, set);
                case UnitType.Bytes:
                    return UC_Bytes.ToBaseSetValue(value, set);
                case UnitType.None:
                    return -1;
                default:
                    return -1;
            }
        }

        /// <summary>
        /// Converts the Base value to its target within the selected type
        /// Example 1000m will be 1 km
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <param name="set"></param>
        /// <returns></returns>
        public static double GetSetValue(UnitType type, double value, string set)
        {
            switch (type)
            {
                case UnitType.Metric:
                    return UC_Metric.ToSetValue(value, set);
                case UnitType.Imperial:
                    return UC_Imperial.ToSetValue(value, set);
                case UnitType.Bytes:
                    return UC_Bytes.ToSetValue(value, set);
                case UnitType.None:
                    return -1;
                default:
                    return -1;
            }
        }

        /// <summary>
        /// The switch between modules
        /// if no combo was found, it will return the same value
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double SwitchType(UnitType from, UnitType to, double value)
        {
            if (from == UnitType.Metric && to == UnitType.Imperial)
                return value * 3.280839895f;
            if (from == UnitType.Imperial && to == UnitType.Metric)
                return value * 3.280839895f;
            return value;
        }
    }
}
