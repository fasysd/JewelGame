namespace JewelGame._Scripts
{
    public class Player
    {
        public string Name { get; set; }
        public int HP { get; set; } = 100;
        public int Shield { get; set; } = 0;
        public int controlMana { get; set; } = 0;
        public bool addShield = false;
        public bool isControl = false;
        private bool isDamage = false;

        public void TakeDamage(int damage)
        {
            if (addShield && damage != 0)
            {
                HP -= 0;
                Shield = 0;
                addShield = false;
            }
            else
            {
                HP -= damage;
                if (HP < 0) HP = 0;
            }

        }
        public void Control(int mana)
        {
            controlMana += mana;
            if (controlMana >= 10)
            {
                isControl = true;
                controlMana = 0;
            }
        }
        public void takeHealth(int health)
        {
            if (HP + health > 100)
            {
                HP = 100;
            }
            else HP += health;
        }
        public void TakeShield(int s)
        {
            Shield += s;
            if (Shield >= 10)
            {
                addShield = true;
            }


        }
        public bool IsDefeated()
        {
            return HP <= 0;
        }
    }
}
