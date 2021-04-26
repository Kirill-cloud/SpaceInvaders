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
using Game;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        GameOne game;
        public UserNamer UserNamer;
        public MainWindow()
        {
            InitializeComponent();

            UserNamer = new UserNamer(this);

             game = new GameOne(new WpfVisualizer(Canvas,this), new WpfInteraction(this));
            game.Start();

            Frame1.Navigate(new RecordsTable());
        }

        private void User_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.A: game.Execute("MoveLeft"); break;
                case Key.D: game.Execute("MoveRight"); break;
                case Key.W: game.Execute("Shoot"); break;
            }
        }



    }
}
