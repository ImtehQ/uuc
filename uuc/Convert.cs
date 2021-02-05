using static uuc.UC_Modules;

namespace uuc
{
    //Universal Unit Convert, yes it needs a better name!
    public static class uuc
    {
        /// <summary>
        /// Converts the value to another unit
        /// </summary>
        /// <param name="value"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static double Convert(this double value, string format)
        {
            return value.InnerConvert(format);
        }

        /// <summary>
        /// Does the logic to convert the data.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        private static double InnerConvert(this double value, string format)
        {
            ///format (xy:xy) x = metric/ imperial (M/I) & y = Type (cm or mm or m)
            ///Convert("Mm:Icm"); > Meteric meter to Imperial centimenr
            format = format.Replace(" ", "");
            string fromTypeStr = format.Substring(0, 1);
            string fromSetStr = format.Substring(1, format.IndexOf(":") - 1);

            string toTypeStr = format.Substring(format.IndexOf(":") + 1, 1);
            string toSetStr = format.Substring(format.IndexOf(":") + 2, format.Length - (format.IndexOf(":") + 2));

            int fromType = UC_Modules.GetType(fromTypeStr);
            int toType = UC_Modules.GetType(toTypeStr);

            if (fromType < 0)
            {
                //Error catch here, Type not found!
            }
            if (toType < 0)
            {
                //Error catch here, Type not found!
            }

            //1, Convert the value to the base of its type
            double baseValue = UC_Modules.GetBaseValue(fromType, value, fromSetStr);

            //2, Check to see if we need to convert the basevalue to a new type
            double switchedValue = UC_Modules.SwitchType(fromType, toType, baseValue);

            //3, Convert the new base value to the target set.
            return UC_Modules.GetSetValue(toType, switchedValue, toSetStr);

        }
    }
}
