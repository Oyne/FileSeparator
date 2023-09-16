using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;

namespace SnelFileSeparator.Models
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
                    writer.WriteLine(Record.Description);
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

        public static void WriteTextBlock(Object sender, List<Record> records)
        {
            TextBlock textBlock = (TextBlock)sender;
            textBlock.Text = "";
            textBlock.Text += Record.Description;
            foreach (var record in records)
            {
                textBlock.Text += "\n" + record.ToString();
            }
        }
    }
}
