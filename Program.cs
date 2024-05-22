using System;
using System.IO;

namespace TurnBasedGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //Skapa spelare och fienden
            Player player = new Player("Player", 100, 20);
            Enemy enemy = new Enemy("Dvärgen Axel", 50, 10);

            bool gameRunning = true;

            while (gameRunning)
            {
                Console.WriteLine("1. Attackera");
                Console.WriteLine("2. Visa Hälsopoäng");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                    //Spelaren attackerar fienden
                        enemy.TakeDamage(player.AttackPower);
                        Console.WriteLine($"Du attackerade fienden {enemy.Name} och gjorde {player.AttackPower} skada!");

                    if (!enemy.IsAlive())
                    {
                        Console.WriteLine($"Du besegrade fienden {enemy.Name}");
                        SaveScore("Vinst");
                        gameRunning = false;
                        break;
                    }
                        //Fienden attackerar spelaren
                    player.TakeDamage(enemy.AttackPower);
                    Console.WriteLine($"{enemy.Name} gjorde {enemy.AttackPower} skada!");

                    if (!player.IsAlive())
                    {
                        Console.WriteLine("Du har blivit besegrad!");
                        SaveScore("Förlust");
                        gameRunning = false;
                    }
                    break;

                    case "2":   //Skriver ut spelarens hälsopoäng
                        Console.WriteLine($"Du har {player.Health} hälsopoäng");
                        Console.WriteLine($"Fienden har {enemy.Health} hälsopoäng");
                        break;

                    default:
                        Console.WriteLine("Felaktig inmatning");
                        break;
                }
            }
        }
        static void SaveScore(string result)   //Funktion för att spara poängen till en fil
        {
            using (StreamWriter writer = new StreamWriter("score.txt"))
            {
                writer.WriteLine($"Resultat: {result}");
            }
        }
    }
}