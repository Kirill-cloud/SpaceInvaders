using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class GameParams
    {
        public int moder;
        public int[] score;
        public Unit[,] field;
        public List<Player> projectiles;
        public GameParams(int moder, int[] score, Unit[,] field, List<Player> projectiles) 
        {
            this.moder = moder;
            this.score = score;
            this.field = field;
            this.projectiles = projectiles;
        }
    }
}
