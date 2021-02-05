using System;
using System.Reflection;

namespace uuc
{
    public static class UC_Modules
    {
        //Add new line and increese the first number of the array to add more types
        //0 = Tag, 1 = human readable name, 2 = Class name, 3 = found state
        public static string[,] UnitTypes = new string[3, 4] 
        {{"M","Metric", "UC_Metric", "0"},
        {"I","Imperial","UC_Imperial", "0"},
        {"B","Bytes","UC_Bytes", "0"} };

        /// <summary>
        /// Updates the UnitTypes found state.
        /// Is not needed to be able to use the converter
        /// </summary>
        public static void CheckModules()
        {
            for (int i = 0; i < UnitTypes.GetLength(0); i++)
            {
                UnitTypes[i,3] = CheckExists("uuc." + UnitTypes[i, 2].ToString());
            }
        }

        /// <summary>
        /// Returns 1 if found or 0 is not found
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        private static string CheckExists(string className)
        {
            System.Type type = System.Type.GetType(className);
            if (type != null)
                return "1";
            return "0";
        }

        /// <summary>
        /// Will return the type if found
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private static System.Type Exists(int index)
        {
            return System.Type.GetType("uuc." + UnitTypes[index,2].ToString());
        }

        /// <summary>
        /// Gets the UnitType based on the string key
        /// Example "M" will be Metric
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int GetType(string key)
        {
            for (int x = 0; x < UnitTypes.Length; x++)
            {
                if (UnitTypes[x, 0] == key) { return x; }
            }
            return -1;
        }

        /// <summary>
        /// Converts the value to the base value of its type,
        /// Example 1 KM will be 1000Meter.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <param name="set"></param>
        /// <returns></returns>
        public static double GetBaseValue(int type, double value, string set)
        {
            Type classType = Exists(type);
            MethodInfo myMethod = classType.GetMethod("ToBaseValue", new Type[] { typeof(double), typeof(string) }, null);
            Console.WriteLine(myMethod);
            return (double)myMethod.Invoke(classType, new Object[] { value, set });
        }

        /// <summary>
        /// Converts the Base value to its target within the selected type
        /// Example 1000m will be 1 km
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <param name="set"></param>
        /// <returns></returns>
        public static double GetSetValue(int type, double value, string set)
        {
            Type classType = Exists(type);
            MethodInfo myMethod = classType.GetMethod("ToSetValue", new Type[] { typeof(double), typeof(string) }, null);
            Console.WriteLine(myMethod);
            return (double)myMethod.Invoke(classType, new Object[] { value, set });
        }

        /// <summary>
        /// The switch between modules
        /// if no combo was found, it will return the same value
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double SwitchType(int from, int to, double value)
        {
            if (from == 0 && to == 1)             //Metric to imperial
                return value * 3.280839895f;
            if (from == 1 && to == 2)             //imperial to metric
                return value / 3.280839895f;
            return value;
        }
    }
}
