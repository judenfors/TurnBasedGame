using System;
using System.IO;
using TurnBasedGame;

namespace TurnBasedGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("Player", 100, 25);
            Enemy enemy = new Enemy("Dvärg", 50, 10);

            bool gameRunning = true;

            while (gameRunning)
            {
                Console.WriteLine("1. Attackera");
                Console.WriteLine("2. Visa Hälsopoäng");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case 1: 
                    enemy.TakeDamage(player.AttackPower);
                    Console.WriteLine($"Du attackerade fienden {enemy.Name} och gjorde {player.AttackPower} skada!");

                    if (!enemy.IsAlive())
                    {
                        Console.WriteLine($"Du besegrade fienden {enemy.Name}");
                        SaveScore("Vinst");
                        gameRunning = false;
                        break;
                    }

                    
                }
            }
        }
    }
}