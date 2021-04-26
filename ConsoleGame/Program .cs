using System;
using Game;


namespace ConsoleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length==1)
            {
                GameOne game = new GameOne(new ConsoleVisualizer(), new ConsoleInteraction(args[0]));
                game.Start();
            }
            else
            {
                Console.WriteLine("Укажите только файл с рекордами в параметрах запуска"); ;
                Console.ReadKey();
            }
        }
    }
}
