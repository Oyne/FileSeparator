using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace SnelFileSeparator.Models
{
    public static class Writer
    {
        public static bool WriteFileTxt(string filePath, List<Record> records)
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

        public static void WriteFileXlsx(string filePath, List<Record> records, string criterion = "criterion")
        {
            try
            {
                string saveFilePath = filePath.Replace(".txt", $"_{criterion}.xlsx");

                // Open the workbook
                using (var workbook = new XLWorkbook())
                {
                    // Get the first worksheet in the workbook
                    var worksheet = workbook.Worksheets.Add("Sheet1");
                    #region Filling headers
                    worksheet.Cell(1, 1).Value = "Date";

                    worksheet.Cell(1, 2).Value = "Time";

                    worksheet.Cell(1, 3).Value = "Satellite";

                    worksheet.Cell(1, 4).Value = "Vizir";

                    worksheet.Cell(1, 5).Value = "Azim";

                    worksheet.Cell(1, 6).Value = "Noise";

                    worksheet.Cell(1, 7).Value = "Pseudo";
                    #endregion

                    // Iterate over all elements of the list
                    for (int i = 0; i < records.Count; i++)
                    {
                        #region Filling rows with values from the list
                        worksheet.Cell(i + 2, 1).Value = records[i].Date;
                        worksheet.Cell(i + 2, 2).Value = records[i].Time;
                        worksheet.Cell(i + 2, 3).Value = records[i].Satellite + records[i].SatelliteNumber.ToString().PadLeft(2, '0');
                        worksheet.Cell(i + 2, 4).Value = records[i].ViewingAngle;
                        worksheet.Cell(i + 2, 5).Value = records[i].AzimuthAngle;
                        worksheet.Cell(i + 2, 6).Value = records[i].NoiseRatio;
                        worksheet.Cell(i + 2, 7).Value = records[i].PseudoRange;
                        #endregion
                    }

                    workbook.SaveAs(saveFilePath);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Файл зайнятий", $"Помилка зберігання: {e.Message}", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
