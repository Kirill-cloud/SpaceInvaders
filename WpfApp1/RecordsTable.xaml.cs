using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Game;

namespace WpfApp1
{
    public partial class RecordsTable : Page
    {
        Dictionary<string, int> records;
        List<String> recordsStringer;
        public RecordsTable()
        {

            InitializeComponent();

            records = GameFileManager.ReadRecordsFromFile("records.txt");
            recordsStringer = new List<string>();
            int i = 0;
            foreach (var item in records)
            {
                i++;
                recordsStringer.Add(i+" ) "+item.Key + " " + item.Value);
            }
            RecordsTable1.ItemsSource = recordsStringer;
        }
    }
}
