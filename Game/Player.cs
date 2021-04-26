using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public class Player : Unit
    {
        int fieldOverflow;
        public int Y;
        int x;
        public int X { get => x; }

        public Player(int y=29, int x=5, int fieldWidth=10)
        {
            fieldOverflow = fieldWidth;
            Y = y;
            this.x = x;
        }

        public void Move(int i)
        {
            if (Math.Abs(i) == 1)
            {
                x += (i + fieldOverflow);
                x %= fieldOverflow;
            }
        }

    }
}
