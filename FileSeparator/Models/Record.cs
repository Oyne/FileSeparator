using System;

namespace FileSeparator.Models
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

        public Record(string date, string time, string satellite,
            string satelliteNumber, string viewingAngle, string azimuthAngle, string noiseRatio, string pseudoRange)
        {
            Date = date;
            Time = time;
            Satellite = satellite;
            SatelliteNumber = Convert.ToInt32(satelliteNumber);
            ViewingAngle = Convert.ToDouble(viewingAngle.Replace(".", ","));
            AzimuthAngle = Convert.ToDouble(azimuthAngle.Replace(".", ","));
            NoiseRatio = Convert.ToDouble(noiseRatio.Replace(".", ","));
            PseudoRange = Convert.ToDouble(pseudoRange.Replace(".", ","));
        }

        public string ToString()
        {
            string formattedTimestamp = $"{Date}||{Time}";
            string formattedSatellite = $"{Satellite}" + SatelliteNumber.ToString().PadLeft(2, '0');
            return formattedTimestamp + "  " + formattedSatellite + "  " + ViewingAngle.ToString("F4") + "  "
                + AzimuthAngle.ToString("F4") + "  " + NoiseRatio.ToString("F2") + "  " + PseudoRange.ToString("F3");
        }
    }
}
