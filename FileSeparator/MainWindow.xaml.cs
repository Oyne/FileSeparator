using FileSeparator.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FileSeparator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string filePath;
        List<Record> records = new List<Record>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DropFilePanel_Drop(object sender, DragEventArgs e)
        {

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
                    Writer.WriteFile(filePath, records);
                }
                else MessageBox.Show("Файл не було відкрито", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
