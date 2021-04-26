using Microsoft.Win32;
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
    public partial class UserNamer : Page
    {
        MainWindow Main;
        public UserNamer(MainWindow main)
        {
            Main = main;

            InitializeComponent();

        }

        private void Name_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = (e.Text == " ");
        }

        private void ChooseFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Convert.ToString(Environment.SpecialFolder.MyDocuments);
            openFileDialog1.Filter = "TextFile (*.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                Path.Text = openFileDialog1.FileName;
            }
        }

        private void SaveToFile(object sender, RoutedEventArgs e)
        {
            if (Path.Text != "")
            {
                if (Name.Text != "")
                {

                    GameFileManager.SaveRecord(Path.Text, (Name.Text, Convert.ToInt32(Main.Score.Content.ToString().Split(' ')[1])));
                    Main.Dispatcher.Invoke(
                        () =>
                        {

                            Main.Frame1.Navigate(new RecordsTable());

                        }
                        );
                }
                else MessageBox.Show("Введите имя");
            }
            else MessageBox.Show("Укажите путь");
        }
    }
}
