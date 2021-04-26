using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame
{
    public class Player:Unit
    {
        public int Y = 29;
        int x = 5;
        public int X { get => x; }
        public Player()
        {
            this.type = "Player";
            this.Health = 1;
        }
        public Player(int y, int x) 
        {
            Y = y;
            this.x = x;
        }
        public void Move(int i) 
        {
            if (Math.Abs(i)==1)
            {
                x += i+10;
                x %= 10;
            }
        }

    }
}
