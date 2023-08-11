using System;
using System.Collections.Generic;
using System.IO;

namespace FileSeparator.Models
{
    public static class Writer
    {
        public static bool WriteFile(string filePath, List<Record> records)
        {
            try
            {
                string newFilePath = filePath.Replace(".txt", "_new.txt");

                using (StreamWriter writer = new StreamWriter(newFilePath, false))
                {
                    foreach (var record in records)
                    {
                        writer.WriteLine(record.ToString());
                    }
                }

                return true; // Writing was successful
            }
            catch (Exception)
            {
                return false; // Writing failed
            }
        }
    }
}
