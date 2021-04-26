using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    interface IInteractor
    {
        void ShowRecords();
        string GetAction();
        void SaveRecord(int score);
    }
}
