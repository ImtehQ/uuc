namespace uuc
{
    public static class UC_Metric
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
        public static double MeterToFeet(this double value)
        {
            return value * 3.280839895f;
        }
        public static double ToBaseSetValue(double value, string set)
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
}
