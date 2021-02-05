namespace uuc
{
    public static class UC_Bytes
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
