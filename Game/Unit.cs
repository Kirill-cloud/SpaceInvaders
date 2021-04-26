using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
   public class Unit
    {
		public string Type { get=>type; }
		protected string type;
		private int health;
		public Unit()
		{
			Health = 0;
			type = "Empty";
		}
		public Unit(string type, int health)
		{
			this.type = type;
			this.Health = health;
		}

		public int Health { get => health; set { health = value; if (health < 1) type = "Empty"; } }

		public bool Collision(int damage)
		{
            if (Type!= "Empty")
            {
				Health -= damage;
				return Type == "Empty";
			}

			return false;
		}

	}
}
