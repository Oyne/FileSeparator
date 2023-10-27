using System.Collections.Generic;
using System.Linq;

namespace SnelFileSeparator.Models
{
    internal static class Separator
    {
        public static List<Record> AzimuthMinMax(double min, double max, List<Record> records)
        {
            var edited = from r in records
                         where r.AzimuthAngle >= min && r.AzimuthAngle <= max
                         select r;

            return edited.ToList();
        }

        public static List<Record> AzimuthFrom(double min, List<Record> records)
        {
            var edited = from r in records
                         where r.AzimuthAngle >= min
                         select r;

            return edited.ToList();
        }

        public static List<Record> AzimuthTo(double max, List<Record> records)
        {
            var edited = from r in records
                         where r.AzimuthAngle <= max
                         select r;

            return edited.ToList();
        }

        public static List<Record> VizirMinMax(double min, double max, List<Record> records)
        {
            var edited = from r in records
                         where r.ViewingAngle >= min && r.ViewingAngle <= max
                         select r;

            return edited.ToList();
        }

        public static List<Record> VizirFrom(double min, List<Record> records)
        {
            var edited = from r in records
                         where r.ViewingAngle >= min
                         select r;

            return edited.ToList();
        }

        public static List<Record> VizirTo(double max, List<Record> records)
        {
            var edited = from r in records
                         where r.ViewingAngle <= max
                         select r;

            return edited.ToList();
        }
    }
}
