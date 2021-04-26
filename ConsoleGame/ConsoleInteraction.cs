using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game;
namespace ConsoleGame
{
    class ConsoleInteraction : IInteractor
    {
        string recordsPath;
        int showableRecordCount = 10;
        public ConsoleInteraction(string recordsPath)
        {
            this.recordsPath = recordsPath;

            Console.WriteLine("Таблица рекордов");
            ShowRecords();

            //else
            //{
            //    Console.WriteLine("Файл таблицы рекордов не найден, был создан новый");
            //    File.Create(recordsPath);
            //}
            
            Console.WriteLine("Нажмите любую клавишу чтобы продолжить");
            Console.ReadKey();

        }

        public string GetAction()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.A: return "MoveLeft";
                case ConsoleKey.D: return "MoveRight";
                case ConsoleKey.Spacebar: return "Shoot";
            }
            return "UnknownAction";
        }
        
        public void SaveRecord(int score)
        {            
            Console.WindowHeight = 33;
            Console.WindowWidth = 12;
            Console.WriteLine("Введите имя");
            string name = Console.ReadLine();

            GameFileManager.SaveRecord(recordsPath, (name ,score));


            Console.WindowHeight = 17;
            Console.WindowWidth = 20;
            Console.Clear();

            ShowPersonalRecord(name, score);
        }
        void ShowPersonalRecord(string name, int score) 
        {
            Console.WriteLine("Taблица рекордов");


            var records = GameFileManager.ReadRecordsFromFile(recordsPath);
            int pos = 0;

            for (int i = 0; i < records.Count; i++)
            {
                if (records.ElementAt(i).Key == name)
                {
                    pos = i;
                    break;
                }
            }

            for (int i = 0; i < (records.Count < showableRecordCount ? records.Count : showableRecordCount); i++)
            {
                Console.WriteLine((i + 1) + ") " + records.ElementAt(i).Key + " " + records.ElementAt(i).Value);
            }
            if (pos > showableRecordCount-1)
            {
                Console.WriteLine(".\n.\n.\n");
                Console.WriteLine((pos + 1) + ") " + name + " " + records[name]);
            }
            Console.ReadKey();
        }
        public void ShowRecords()
        {
            var records = GameFileManager.ReadRecordsFromFile(recordsPath);
            foreach (var item in records)
            {
                Console.WriteLine(item.Key+" "+item.Value);
            }
        }
    }
}
