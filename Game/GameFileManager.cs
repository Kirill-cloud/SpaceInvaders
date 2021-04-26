using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Game
{
    public static class GameFileManager
    {
        public static Dictionary<string, int> ReadRecordsFromFile(string recordsPath)
        {
            Dictionary<string, int> records = new Dictionary<string, int>();
            if (File.Exists(recordsPath))
            {

                using (StreamReader sr = new StreamReader(recordsPath))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        records.Add(line.Split(" ")[0], Convert.ToInt32(line.Split(" ")[1]));
                    }
                }

            }
            else
            {
                File.Create(recordsPath);
            }
            return records;
        }
        public static void SaveRecord(string recordsPath, (string name, int score) playerInfo)
        {
            string name = playerInfo.name;
            int score = playerInfo.score;

            Dictionary<string, int> RecordsTable;
            if (!File.Exists(recordsPath))
            {
                File.Create(recordsPath);
            }

            try
            {
                RecordsTable = ReadRecordsFromFile(recordsPath);

                RecordsTable = RefreshRecords(RecordsTable, (name, score));

                WriteRecord(recordsPath, RecordsTable);
            }
            catch (Exception)
            {

            }


        }
        static void WriteRecord(string recordsPath, Dictionary<string, int> temp)
        {
            using (StreamWriter sw = new StreamWriter(recordsPath))
            {
                foreach (var item in temp)
                {
                    sw.WriteLine(item.Key + " " + item.Value);
                }
            }
        }
        //добавляет запись в таблицу, учитывает уникальность имен игроков
        static Dictionary<string, int> RefreshRecords(Dictionary<string, int> temp, (string name, int score) playerInfo)
        {
            string name = playerInfo.name;
            int score = playerInfo.score;

            if (temp.ContainsKey(name))
            {
                if (temp[name] < score)
                {
                    temp[name] = score;
                }
            }
            else
            {
                temp.Add(name, score);
            }

            temp = temp.OrderBy(x => x.Value).Reverse().ToDictionary(x => x.Key, x => x.Value);
            return temp;
        }
    }
}
