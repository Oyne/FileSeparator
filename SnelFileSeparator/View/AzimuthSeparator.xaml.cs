using SnelFileSeparator.Models;
using System.Collections.Generic;
using System.Windows;

namespace SnelFileSeparator.View
{
    /// <summary>
    /// Interaction logic for AzimuthSeparator.xaml
    /// </summary>
    public partial class AzimuthSeparator : Window
    {
        private List<Record> records;
        string filePath;
        public AzimuthSeparator(List<Record> records, string filePath)
        {

            InitializeComponent();
            this.records = records;
            this.filePath = filePath;
        }

        private void MinMaxRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            MinimumLabel.Visibility = Visibility.Visible;
            MinimumTextBox.Visibility = Visibility.Visible;
            MaximumLabel.Visibility = Visibility.Visible;
            MaximumTextBox.Visibility = Visibility.Visible;
        }

        private void FromRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            MinimumLabel.Visibility = Visibility.Visible;
            MinimumTextBox.Visibility = Visibility.Visible;

            MaximumLabel.Visibility = Visibility.Hidden;
            MaximumTextBox.Visibility = Visibility.Hidden;
            MaximumTextBox.Text = "";

        }

        private void ToRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            MinimumLabel.Visibility = Visibility.Hidden;
            MinimumTextBox.Visibility = Visibility.Hidden;
            MinimumTextBox.Text = "";

            MaximumLabel.Visibility = Visibility.Visible;
            MinimumTextBox.Visibility = Visibility.Visible;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            double min, max;
            List<Record> separatedRecords;
            if (MinMaxRadioButton.IsChecked.Value == true)
            {
                min = double.Parse(MinimumTextBox.Text);
                max = double.Parse(MaximumTextBox.Text);
                separatedRecords = Separator.AzimuthMinMax(min, max, records);
                Writer.WriteFileXlsx(filePath, separatedRecords, "AzimuthMinMax");
            }
            else if (FromRadioButton.IsChecked.Value == true)
            {
                min = double.Parse(MinimumTextBox.Text);
                separatedRecords = Separator.AzimuthFrom(min, records);
                Writer.WriteFileXlsx(filePath, separatedRecords, "AzimuthFrom");
            }
            else if (ToRadioButton.IsChecked.Value == true)
            {
                max = double.Parse(MaximumTextBox.Text);
                separatedRecords = Separator.AzimuthTo(max, records);
                Writer.WriteFileXlsx(filePath, separatedRecords, "AzimuthTo");
            }
        }
    }
}
