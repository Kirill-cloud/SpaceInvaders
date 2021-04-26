using System;



namespace ConsoleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            if (args.Length==1)
            {
                Game game = new Game(new ConsoleVisualizer(), new ConsoleInteraction(args[0]));
                Console.WindowHeight = 33;
                Console.WindowWidth = 10;
                game.Start();
                
            }
            else
            {
                Console.WriteLine("Укажите файл с рекордами в параметрах запуска"); ;
                Console.ReadKey();
            }
        }
    }
}
