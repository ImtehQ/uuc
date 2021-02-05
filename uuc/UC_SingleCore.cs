namespace uuc
{

    public static class UC_SingleCore
    {

        public static string[,] UnitTypes = new string[3, 4]
                                            {{"M","Metric", "UC_Metric", "0"},
                                            {"I","Imperial","UC_Imperial", "0"},
                                            {"B","Bytes","UC_Bytes", "0"} };

        public static double GetBaseValue(int type, double value, string set)
        {
            if (type == 0) // or UnitTypes[type,1] == Metric
                return UCSC_Metric.ToBaseValue(value, set);
            if (type == 1) // or UnitTypes[type,1] == Imperial
                return UCSC_Imperial.ToBaseValue(value, set);
            if (type == 2) // or UnitTypes[type,1] == Bytes
                return UCSC_Bytes.ToBaseValue(value, set);
            return -1;
        }

        public static double GetSetValue(int type, double value, string set)
        {
            if (type == 0) // or UnitTypes[type,1] == Metric
                return UCSC_Metric.ToSetValue(value, set);
            if (type == 1) // or UnitTypes[type,1] == Imperial
                return UCSC_Imperial.ToSetValue(value, set);
            if (type == 2) // or UnitTypes[type,1] == Bytes
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

    public static class UCSC_Imperial
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
        public static double ToBaseValue(double value, string set)
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
    public static class UCSC_Metric
    {
        public static double MeterToExameter(this double value)
        {
            return value * 0.000000000000000001f;
        }
        public static double MeterToPetameter(this double value)
        {
            return value * 0.000000000000001f;
        }
        public static double MeterToTerameter(this double value)
        {
            return value * 0.000000000001f;
        }
        public static double MeterToGigameter(this double value)
        {
            return value * 0.000000001f;
        }
        public static double MeterToMegameter(this double value)
        {
            return value * 0.000001f;
        }
        public static double MeterToKilometer(this double value)
        {
            return value * 0.001f;
        }
        public static double MeterToHectometer(this double value)
        {
            return value * 0.01f;
        }
        public static double MeterToDecameter(this double value)
        {
            return value * 0.1f;
        }
        public static double MeterToMeter(this double value)
        {
            return value;
        }
        public static double MeterToDecimeter(this double value)
        {
            return value * 10f;
        }
        public static double MeterToCentimeter(this double value)
        {
            return value * 100f;
        }
        public static double MeterToMilimeter(this double value)
        {
            return value * 1000f;
        }
        public static double MeterToMicrometer(this double value)
        {
            return value * 1000000f;
        }
        public static double MeterToNanometer(this double value)
        {
            return value * 1000000000f;
        }
        public static double MeterToPicometer(this double value)
        {
            return value * 1000000000000f;
        }
        public static double MeterToFemtometer(this double value)
        {
            return value * 1000000000000000f;
        }
        public static double MeterToAttometer(this double value)
        {
            return value * 1000000000000000000f;
        }
        //--------------------------------------------------------------
        public static double ExameterMeter(this double value)
        {
            return value * 1000000000000000000f;
        }
        public static double PetameterToMeter(this double value)
        {
            return value * 1000000000000000f;
        }
        public static double TerameterToMeter(this double value)
        {
            return value * 1000000000000f;
        }
        public static double GigameterToMeter(this double value)
        {
            return value * 1000000000f;
        }
        public static double MegameterToMeter(this double value)
        {
            return value / 1000000f;
        }
        public static double KilometerToMeter(this double value)
        {
            return value / 1000f;
        }
        public static double HectometerToMeter(this double value)
        {
            return value / 100f;
        }
        public static double DecameterToMeter(this double value)
        {
            return value / 10f;
        }
        public static double DecimeterToMeter(this double value)
        {
            return value * 0.1f;
        }
        public static double CentimeterToMeter(this double value)
        {
            return value * 0.01f;
        }
        public static double MilimeterToMeter(this double value)
        {
            return value * 0.001f;
        }
        public static double MicrometerToMeter(this double value)
        {
            return value * 0.000001f;
        }
        public static double NanometerToMeter(this double value)
        {
            return value * 0.000000001f;
        }
        public static double PicometerToMeter(this double value)
        {
            return value * 0.000000000001f;
        }
        public static double FemtometerToMeter(this double value)
        {
            return value * 0.000000000000001f;
        }
        public static double AttometerToMeter(this double value)
        {
            return value * 0.000000000000000001f;
        }
        public static double ToBaseValue(double value, string set)
        {
            switch (set)
            {
                case "Em":
                    return value.ExameterMeter();
                case "Pm":
                    return value.PetameterToMeter();
                case "Tm":
                    return value.TerameterToMeter();
                case "Gm":
                    return value.GigameterToMeter();
                case "Km":
                    return value.KilometerToMeter();
                case "Hm":
                    return value.HectometerToMeter();
                case "Dm":
                    return value.DecameterToMeter();
                case "m":
                    return value.MeterToMeter();
                case "dm":
                    return value.DecimeterToMeter();
                case "cm":
                    return value.CentimeterToMeter();
                case "mm":
                    return value.MilimeterToMeter();
                case "Mm":
                    return value.MicrometerToMeter();
                case "nm":
                    return value.NanometerToMeter();
                case "pm":
                    return value.PicometerToMeter();
                case "fm":
                    return value.FemtometerToMeter();
                case "am":
                    return value.AttometerToMeter();
                default:
                    return -1;
            }
        }
        public static double ToSetValue(double value, string set)
        {
            switch (set)
            {
                case "Em":
                    return value.MeterToExameter();
                case "Pm":
                    return value.MeterToPetameter();
                case "Tm":
                    return value.MeterToTerameter();
                case "Gm":
                    return value.MeterToGigameter();
                case "Km":
                    return value.MeterToKilometer();
                case "Hm":
                    return value.MeterToHectometer();
                case "Dm":
                    return value.MeterToDecameter();
                case "m":
                    return value.MeterToMeter();
                case "dm":
                    return value.MeterToDecimeter();
                case "cm":
                    return value.MeterToCentimeter();
                case "mm":
                    return value.MeterToMilimeter();
                case "Mm":
                    return value.MeterToMicrometer();
                case "nm":
                    return value.MeterToNanometer();
                case "pm":
                    return value.MeterToPicometer();
                case "fm":
                    return value.MeterToFemtometer();
                case "am":
                    return value.MeterToAttometer();
                default:
                    return -1;
            }
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
