using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System;

namespace FileSeparator.Models
{
    public static class Reader
    {
        public static bool ReadFile(string filePath, List<Record> records)
        {
            string regexPattern = @"(\d{4}\/\d{2}\/\d{2}) (\d{2}:\d{2}:\d{2}) - (\w+) +(\d{2}) +(\d+.\d+) +(\d+.\d+) = (\d+.\d+) +(\d+.\d+)";

            try
            {
                // Read the file line by line
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Check if the line matches the regex pattern
                        Match match = Regex.Match(line, regexPattern);
                        if (match.Success)
                        {
                            string date = match.Groups[1].Value;
                            string time = match.Groups[2].Value;
                            string satellite = match.Groups[3].Value;
                            string satelliteNumber = match.Groups[4].Value;
                            string viewingAngle = match.Groups[5].Value;
                            string azimuthAngle = match.Groups[6].Value;
                            string noiseRatio = match.Groups[7].Value;
                            string pseudoRange = match.Groups[8].Value;

                            records.Add(new Record(date, time, satellite, satelliteNumber, viewingAngle, azimuthAngle, noiseRatio, pseudoRange));
                        }
                    }
                }
                return true; // Reading was successful
            }
            catch (Exception)
            {
                return false; // Reading failed
            }
        }
    }
}