namespace TurnBasedGame
{
    public abstract class Character
    {
        private string name;
        private int health;     //Lagrar karaktärens namn, hälsa och attackstyrka. 
        private int attackPower;

        public string Name   //Hämtar karaktärens namn
        {
            get { return name; }
            private set { name = value; }
        }

        public int Health   //Hämtar och sätter karaktärens hälsa
        {
            get { return health; }
            private set { health = value; }
        }

        public int AttackPower    //Hämtar och sätter karaktärens attackstyrka
        {
            get { return attackPower; }
            private set { attackPower = value; }
        }

        public Character(string name, int health, int attackPower)    //Konstruktor som initierar karaktär med namn, hälsa och attackstyrka
        {
            Name = name;
            Health = health;
            AttackPower = attackPower;
        }

        public void TakeDamage(int damage)    //Metod för att skada karaktären
        {
            Health -= damage;   //Minskar hälsan med mängden skada
            if (Health < 0) Health = 0;   //Förhindrar hälsan från att bli negativ
        }

        public bool IsAlive()    //Metod för att se om karaktären fortfarande är vid liv
        {
            return Health > 0;  //Returnerar true om hälsan är större än 0, annars false
        }
    }
}