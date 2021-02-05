namespace uuc
{

    public static class UC_SingleCore_Bytes
    {

        public static string[,] UnitTypes = new string[1, 4]
                                            {{"B","Bytes","UC_Bytes", "0"} };

        public static double GetBaseValue(int type, double value, string set)
        {
            if (type == 0) // or UnitTypes[type,1] == Bytes
                return UCSC_Bytes.ToBaseValue(value, set);
            return -1;
        }

        public static double GetSetValue(int type, double value, string set)
        {
            if (type == 0) // or UnitTypes[type,1] == Metric
                return UCSC_Bytes.ToSetValue(value, set);
            return -1;
        }

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
            string toSetStr = format.Substring(format.IndexOf(":") + 2, format.Length - (format.IndexOf(":") + 2));

            int fromType = GetType(fromTypeStr);
            int toType = GetType(toTypeStr);

            if (fromType < 0)
            {
                //Error catch here, Type not found!
            }
            if (toType < 0)
            {
                //Error catch here, Type not found!
            }

            //1, Convert the value to the base of its type
            double baseValue = GetBaseValue(fromType, value, fromSetStr);

            //2, Check to see if we need to convert the basevalue to a new type
            double switchedValue = SwitchType(fromType, toType, baseValue);

            //3, Convert the new base value to the target set.
            return GetSetValue(toType, switchedValue, toSetStr);

        }

        public static int GetType(string key)
        {
            for (int x = 0; x < UnitTypes.Length; x++)
            {
                if (UnitTypes[x, 0] == key) { return x; }
            }
            return -1;
        }

        public static double SwitchType(int from, int to, double value)
        {
            if (from == 0 && to == 1)             //Metric to imperial
                return value * 3.280839895f;
            if (from == 1 && to == 2)             //imperial to metric
                return value / 3.280839895f;
            return value;
        }
    }
    public static class UCSC_Bytes
    {
        public static double BitTobyte(this double value)
        {
            return value / 8;
        }
        //--------------------------------------------------------------
        public static double byteToBit(this double value)
        {
            return value * 8;
        }
        public static double ToBaseValue(double value, string set)
        {
            switch (set)
            {
                case "B":
                    return value.BitTobyte();
                default:
                    return -1;
            }
        }
        public static double ToSetValue(double value, string set)
        {
            switch (set)
            {
                case "b":
                    return value.byteToBit();
                default:
                    return -1;
            }
        }
    }
}
