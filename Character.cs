namespace TurnBasedGame
{
    public abstract class Character
    {
        private string name;
        private int health;
        private int attackPower;

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public int Health
        {
            get { return health; }
            private set { health = value; }
        }

        public int AttackPower
        {
            get { return attackPower; }
            private set { attackPower = value; }
        }

        public Character(string name, int health, int attackPower)
        {
            Name = name;
            Health = health;
            AttackPower = attackPower;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
        }

        public bool IsAlive()
        {
            return Health > 0;
        }
    }
}