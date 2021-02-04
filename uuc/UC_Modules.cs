using System;
using System.Collections.Generic;
using System.Text;

namespace uuc
{
    public static class UC_Modules
    {
        //Add new line and increese the first number of the array to add more types
        private static string[,] UnitTypes = new string[2, 2] 
        {{"M","Metric"},
        {"I","Imperial"}};

        /// <summary>
        /// Those are the Types to convert from and to
        /// Make sure UnitTypes and UnitType have the same order
        /// </summary>
        public enum UnitType
        {
            Metric,
            Imperial,
            None // Make sure none is always last!
        }

        public static UnitType GetType(string key)
        {
            for (int x = 0; x < UnitTypes.Length; x++)
            {
                if (UnitTypes[x, 0] == key) { return (UnitType)x; }
            }
            return UnitType.None;
        }
    }
}
