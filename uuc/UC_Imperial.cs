namespace uuc
{
    public static class UC_Imperial
    {
        public static double FeetToRod(this double value)
        {
            return value / 16.499967f;
        }
        public static double FeetToLink(this double value)
        {
            return value / 0.66000132f;
        }
        public static double FeetToFathom(this double value)
        {
            return value * 60761f;
        }
        public static double FeetToLeague(this double value)
        {
            return value / 15840f;
        }
        public static double FeetToMile(this double value)
        {
            return value / 5280f;
        }
        public static double FeetToFurlong(this double value)
        {
            return value / 660f;
        }
        public static double FeetToChain(this double value)
        {
            return value / 66f;
        }
        public static double FeetToYard(this double value)
        {
            return value / 3f;
        }
        public static double FeetToFeet(this double value)
        {
            return value;
        }
        public static double FeetToInch(this double value)
        {
            return value / 0.0833333333f;
        }
        //--------------------------------------------------------------
        public static double RodToFeet(this double value)
        {
            return value * 16.499967f;
        }
        public static double LinkToFeet(this double value)
        {
            return value * 1.5151515152f;
        }
        public static double CableToFeet(this double value)
        {
            return value * 607.61f;
        }
        public static double FathomToFeet(this double value)
        {
            return value * 60761f;
        }
        public static double LeagueToFeet(this double value)
        {
            return value * 15840f;
        }
        public static double MileToFeet(this double value)
        {
            return value * 5280f;
        }
        public static double FurlongToFeet(this double value)
        {
            return value * 660f;
        }
        public static double ChainToFeet(this double value)
        {
            return value * 66f;
        }
        public static double YardToFeet(this double value)
        {
            return value * 3f;
        }
        public static double InchToFeet(this double value)
        {
            return value * 0.0833333333f;
        }
        public static double FeetToMeter(this double value)
        {
            return value * 0.3048f;
        }
        public static double ToBaseSetValue(double value, string set)
        {
            switch (set)
            {
                case "rd":
                    return value.RodToFeet();
                case "li":
                    return value.LinkToFeet();
                case "fath":
                    return value.FathomToFeet();
                case "lea":
                    return value.LeagueToFeet();
                case "mi":
                    return value.MileToFeet();
                case "fur":
                    return value.FurlongToFeet();
                case "ch":
                    return value.ChainToFeet();
                case "yd":
                    return value.YardToFeet();
                case "ft":
                    return value.FeetToFeet();
                case "ic":
                    return value.InchToFeet();
                default:
                    return -1;
            }
        }
        public static double ToSetValue(double value, string set)
        {
            switch (set)
            {
                case "rd":
                    return value.FeetToRod();
                case "li":
                    return value.FeetToLink();
                case "fath":
                    return value.FeetToFathom();
                case "lea":
                    return value.FeetToLeague();
                case "mi":
                    return value.FeetToMile();
                case "fur":
                    return value.FeetToFurlong();
                case "ch":
                    return value.FeetToChain();
                case "yd":
                    return value.FeetToYard();
                case "ft":
                    return value.FeetToFeet();
                case "ic":
                    return value.FeetToInch();
                default:
                    return -1;
            }
        }
    }
}
