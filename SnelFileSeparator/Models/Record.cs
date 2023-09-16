using System.Globalization;

namespace SnelFileSeparator.Models
{
    public class Record
    {

        public string Date { get; set; }

        public string Time { get; set; }

        public string Satellite { get; set; }

        public int SatelliteNumber { get; set; }

        public double ViewingAngle { get; set; }

        public double AzimuthAngle { get; set; }

        public double NoiseRatio { get; set; }

        public double PseudoRange { get; set; }

        public static string Description { get; } = "   Date     Time     Satellite   Vizir      Azim      Noise     Pseudo";


        public Record(string date, string time, string satellite,
            string satelliteNumber, string viewingAngle, string azimuthAngle, string noiseRatio, string pseudoRange)
        {
            Date = date;
            Time = time;
            Satellite = satellite;
            SatelliteNumber = int.Parse(satelliteNumber);
            ViewingAngle = double.Parse(viewingAngle, CultureInfo.InvariantCulture);
            AzimuthAngle = double.Parse(azimuthAngle, CultureInfo.InvariantCulture);
            NoiseRatio = double.Parse(noiseRatio, CultureInfo.InvariantCulture);
            PseudoRange = double.Parse(pseudoRange, CultureInfo.InvariantCulture);
        }

        public override string ToString()
        {
            string formattedTimestamp = $"{Date}_{Time}";
            string formattedSatellite = $"{Satellite}" + SatelliteNumber.ToString().PadLeft(2, '0');
            return formattedTimestamp + "    " 
                + formattedSatellite + "    "
                + ViewingAngle.ToString("F4", CultureInfo.InvariantCulture) + "    "
                + AzimuthAngle.ToString("F4", CultureInfo.InvariantCulture) + "    " 
                + NoiseRatio.ToString("F2", CultureInfo.InvariantCulture) + "    " 
                + PseudoRange.ToString("F3", CultureInfo.InvariantCulture);
        }
    }
}
