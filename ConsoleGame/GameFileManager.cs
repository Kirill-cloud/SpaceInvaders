using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleGame
{
    class GameFileManager
    {
        public static void SaveRecord(string recordsPath, int score , string name)
        {
            List<string> temp = new List<string>();
            if (!File.Exists(recordsPath))
            {
                File.Create(recordsPath);
            }
            try
            {
                using (StreamReader sr = new StreamReader(recordsPath))
                {
                    while (!sr.EndOfStream)
                    {
                        temp.Add(sr.ReadLine());

                    }
                }
                Dictionary<string, int> temp2 = new Dictionary<string, int>();
                foreach (var item in temp)
                {
                    temp2.Add(item.Split(' ')[0], Convert.ToInt32(item.Split(' ')[1]));
                }
                Console.WindowHeight = 33;
                Console.WindowWidth = 12;

                Console.Clear();
                if (temp2.ContainsKey(name))
                {
                    if (temp2[name] < score)
                    {
                        temp2[name] = score;
                    }
                }
                else
                {
                    temp2.Add(name, score);
                }

                temp2 = temp2.OrderBy(x => x.Value).Reverse().ToDictionary(x => x.Key, x => x.Value);
                int pos = 0;
                using (StreamWriter sw = new StreamWriter(recordsPath))
                {
                    int i = 0;
                    foreach (var item in temp2)
                    {
                        if (item.Key == name)
                        {
                            pos = i;
                        }
                        i++;
                        sw.WriteLine(item.Key + " " + item.Value);
                    }
                }
            }
            catch (Exception)
            {

            }
            

        }

        public static Dictionary<string, int> ReadRecords(string recordsPath)
        {
            Dictionary<string, int> records = new Dictionary<string, int>();
            if (File.Exists(recordsPath))
            {

                using (StreamReader sr = new StreamReader(recordsPath))
                {
                    string line;
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        records.Add(line.Split(" ")[0], Convert.ToInt32(line.Split(" ")[1]));
                    }
                }

            }
            return records;
        }
    }
}
