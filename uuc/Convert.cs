using System;
using System.Collections.Generic;
using System.Text;

namespace uuc
{
    //Universal Unit Convert, yes it needs a better name!

    /// <summary>
    /// This enum will store the 2 options for type
    /// </summary>
    public enum UnitType
    {
        Metric,
        Imperial
    }

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
            string FromSet = format.Substring(0, 1);
            string FromType = format.Substring(1, format.IndexOf(":") - 1);

            string ToSet = format.Substring(format.IndexOf(":") + 1, 1);
            string ToType = format.Substring((format.IndexOf(":") + 2), (format.Length - (format.IndexOf(":") + 2)));

            double firstReturn = 0;
            double secondReturn = 0;

            UnitType firstReturntType = UnitType.Metric;

            if (FromSet == "M")
            {
                firstReturntType = UnitType.Metric;
                switch (FromType)
                {
                    case "Em":
                        firstReturn = value.ExameterMeter();
                        break;
                    case "Pm":
                        firstReturn = value.PetameterToMeter();
                        break;
                    case "Tm":
                        firstReturn = value.TerameterToMeter();
                        break;
                    case "Gm":
                        firstReturn = value.GigameterToMeter();
                        break;
                    case "Km":
                        firstReturn = value.KilometerToMeter();
                        break;
                    case "Hm":
                        firstReturn = value.HectometerToMeter();
                        break;
                    case "Dm":
                        firstReturn = value.DecameterToMeter();
                        break;
                    case "m":
                        firstReturn = value.MeterToMeter();
                        break;
                    case "dm":
                        firstReturn = value.DecimeterToMeter();
                        break;
                    case "cm":
                        firstReturn = value.CentimeterToMeter();
                        break;
                    case "mm":
                        firstReturn = value.MilimeterToMeter();
                        break;
                    case "Mm":
                        firstReturn = value.MicrometerToMeter();
                        break;
                    case "nm":
                        firstReturn = value.NanometerToMeter();
                        break;
                    case "pm":
                        firstReturn = value.PicometerToMeter();
                        break;
                    case "fm":
                        firstReturn = value.FemtometerToMeter();
                        break;
                    case "am":
                        firstReturn = value.AttometerToMeter();
                        break;
                    default:
                        break;
                }
            }
            else if (FromSet == "I")
            {
                firstReturntType = UnitType.Imperial;
                switch (FromType)
                {
                    case "rd":
                        firstReturn = value.RodToFeet();
                        break;
                    case "li":
                        firstReturn = value.LinkToFeet();
                        break;
                    case "fath":
                        firstReturn = value.FathomToFeet();
                        break;
                    case "lea":
                        firstReturn = value.LeagueToFeet();
                        break;
                    case "mi":
                        firstReturn = value.MileToFeet();
                        break;
                    case "fur":
                        firstReturn = value.FurlongToFeet();
                        break;
                    case "ch":
                        firstReturn = value.ChainToFeet();
                        break;
                    case "yd":
                        firstReturn = value.YardToFeet();
                        break;
                    case "ft":
                        firstReturn = value.FeetToFeet();
                        break;
                    case "ic":
                        firstReturn = value.InchToFeet();
                        break;
                    default:
                        break;
                }
            }

            if (ToSet == "M")
            {
                if (firstReturntType == UnitType.Imperial)
                    firstReturn = firstReturn.FeetToMeter();

                switch (ToType)
                {
                    case "Em":
                        secondReturn = firstReturn.MeterToExameter();
                        break;
                    case "Pm":
                        secondReturn = firstReturn.MeterToPetameter();
                        break;
                    case "Tm":
                        secondReturn = firstReturn.MeterToTerameter();
                        break;
                    case "Gm":
                        secondReturn = firstReturn.MeterToGigameter();
                        break;
                    case "Km":
                        secondReturn = firstReturn.MeterToKilometer();
                        break;
                    case "Hm":
                        secondReturn = firstReturn.MeterToHectometer();
                        break;
                    case "Dm":
                        secondReturn = firstReturn.MeterToDecameter();
                        break;
                    case "m":
                        secondReturn = firstReturn.MeterToMeter();
                        break;
                    case "dm":
                        secondReturn = firstReturn.MeterToDecimeter();
                        break;
                    case "cm":
                        secondReturn = firstReturn.MeterToCentimeter();
                        break;
                    case "mm":
                        secondReturn = firstReturn.MeterToMilimeter();
                        break;
                    case "Mm":
                        secondReturn = firstReturn.MeterToMicrometer();
                        break;
                    case "nm":
                        secondReturn = firstReturn.MeterToNanometer();
                        break;
                    case "pm":
                        secondReturn = firstReturn.MeterToPicometer();
                        break;
                    case "fm":
                        secondReturn = firstReturn.MeterToFemtometer();
                        break;
                    case "am":
                        secondReturn = firstReturn.MeterToAttometer();
                        break;
                    default:
                        break;
                }
            }
            else if (ToSet == "I")
            {
                if (firstReturntType == UnitType.Metric)
                    firstReturn = firstReturn.MeterToFeet();

                switch (ToType)
                {
                    case "rd":
                        secondReturn = firstReturn.FeetToRod();
                        break;
                    case "li":
                        secondReturn = firstReturn.FeetToLink();
                        break;
                    case "fath":
                        secondReturn = firstReturn.FeetToFathom();
                        break;
                    case "lea":
                        secondReturn = firstReturn.FeetToLeague();
                        break;
                    case "mi":
                        secondReturn = firstReturn.FeetToMile();
                        break;
                    case "fur":
                        secondReturn = firstReturn.FeetToFurlong();
                        break;
                    case "ch":
                        secondReturn = firstReturn.FeetToChain();
                        break;
                    case "yd":
                        secondReturn = firstReturn.FeetToYard();
                        break;
                    case "ft":
                        secondReturn = firstReturn.FeetToFeet();
                        break;
                    case "ic":
                        secondReturn = firstReturn.FeetToInch();
                        break;
                    default:
                        break;
                }
            }
            return secondReturn;
        }
    }

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

    }
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

    }
}
