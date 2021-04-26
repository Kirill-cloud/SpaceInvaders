using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game;

namespace ConsoleGame
{
    class ConsoleVisualizer : IVisualizer
    {
        public ConsoleVisualizer()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WindowHeight = 33;
            Console.WindowWidth = 10;
        }

        public void Drawer(object state)
        {
            GameParams param = (GameParams)state;
            param.moder++;
            bool k = false;

            Console.Clear();

            Console.WriteLine("Score: " + param.score[0]);

            for (int i = 0; i < param.field.GetLength(0); i++)
            {
                Console.WriteLine();

                for (int j = 0; j < param.field.GetLength(1); j++)
                {
                    if (param.field[i, j] != null)
                    {
                        Console.Write((param.field[i, j].Health == 0 ? "*" : param.field[i, j].Health.ToString()));
                    }
                    else Console.Write(" ");
                }
            }

            Console.WriteLine();
            if (k) Console.WriteLine("Ваш результат " + param.score);
        }
    }
}
