using Microsoft.Win32;
using SnelFileSeparator.Models;
using SnelFileSeparator.View;
using System.Collections.Generic;
using System.Windows;

namespace SnelFileSeparator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string? filePath;
        List<Record> records;

        public MainWindow()
        {
            InitializeComponent();
            records = new List<Record>();
            OpenFileWindow.Visibility = Visibility.Visible;
            FileDisplayWindow.Visibility = Visibility.Collapsed;
        }

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);

            //Calculate half of the offset to move the form

            if (sizeInfo.HeightChanged)
                this.Top += (sizeInfo.PreviousSize.Height - sizeInfo.NewSize.Height) / 2;

            if (sizeInfo.WidthChanged)
                this.Left += (sizeInfo.PreviousSize.Width - sizeInfo.NewSize.Width) / 2;
        }

        private void DropFilePanel_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] filePathes = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string file in filePathes)
                {
                    if (Reader.ReadFile(file, records))
                    {
                        MessageBox.Show("Файл було відкрито", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        Writer.WriteFileTxt(file, records);
                    }
                    else MessageBox.Show("Файл не було відкрито", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"; // Filter for specific file types
            if (openFileDialog.ShowDialog() == true)
            {
                filePath = openFileDialog.FileName;
                if (Reader.ReadFile(filePath, records))
                {
                    MessageBox.Show("Файл було відкрито", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    OpenFileWindow.Visibility = Visibility.Collapsed;
                    FileDisplayWindow.Visibility = Visibility.Visible;
                    FileNameTextBlock.Text = filePath;

                    RecordsGrid.ItemsSource = null;
                    RecordsGrid.ItemsSource = records;
                }
                else MessageBox.Show("Файл не було відкрито", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void AzimuthSeparatorOpen(object sender, RoutedEventArgs e)
        {
            AzimuthSeparator separator = new AzimuthSeparator(records, filePath);
            separator.Show();
        }
    }
}
