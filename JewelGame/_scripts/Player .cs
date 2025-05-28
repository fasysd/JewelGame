using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelGame._scripts
{
    public class Player
    {
        public string Name { get; set; }
        public int HP { get; set; } = 100;

        public Player(string name)
        {
            Name = name;
        }

        public void TakeDamage(int damage)
        {
            HP -= damage;
            if (HP < 0) HP = 0;
        }

        public bool IsDefeated => HP <= 0;
    }
}
