using System.Windows.Controls;
using Game;
using System.Windows.Shapes;
using System.Windows.Media;
using System;

namespace WpfApp1
{
    class WpfVisualizer : IVisualizer
    {
        MainWindow Main;
        Canvas canvas;
        SolidColorBrush Space = Brushes.White;
        public WpfVisualizer(Canvas canva, MainWindow main)
        {
            Main = main;
            canvas = canva;
        }
        public void Drawer(object state)
        {
            var space = Space;
            Main.Dispatcher.Invoke(() => NewMethod(space, state)); 
        }

        private void NewMethod(SolidColorBrush space, object state)
        {
           
                canvas.Children.Clear();
                var st = (GameParams)state;

                double height = canvas.Height / st.field.GetLength(0);
                double width = canvas.Width / st.field.GetLength(1);

                for (int i = 0; i < st.field.GetLength(0); i++)
                {

                    for (int j = 0; j < st.field.GetLength(1); j++)
                    {
                        Rectangle rectangle = new Rectangle() { Height = height, Width = width };
                        Canvas.SetLeft(rectangle, j * rectangle.Width);
                        Canvas.SetTop(rectangle, i * rectangle.Height);
                        rectangle.Width += 1;
                        rectangle.Height += 1;
                        if (st.field[i, j] != null)
                        {
                            if (st.field[i, j].Type == "Enemy1")
                            {
                                rectangle.Fill = EnemyColorPicker(st.field[i, j].Health);
                            }
                            else
                            {
                                rectangle.Fill = new SolidColorBrush(Color.FromRgb(30, 30, 30)); // Не использовать переменные с кистью, мрет производительность  
                            }
                        }
                        else rectangle.Fill =  new SolidColorBrush(Color.FromRgb(230, 230, 230)); // Не использовать переменные с кистью, мрет производительность      

                        canvas.Children.Add(rectangle);
                    }
                }
                Main.Score.Content = "Score: " + st.score[0];


          
        }

        SolidColorBrush EnemyColorPicker(int hp)
        {
            return new SolidColorBrush(Color.FromRgb((byte)(hp * 27), (byte)(255 - hp * 27), 0));
        }
    }
}
