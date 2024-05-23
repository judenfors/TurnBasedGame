using System;
using System.IO;

namespace TurnBasedGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //Skapa spelare och fienden
            Player player = new Player("Eric", 100, 20);

            List<Enemy> enemies= new List<Enemy>()
            {
                new Enemy("Dvärgen Axel", 50, 10)

            };

            bool gameRunning = true;

            while (gameRunning)
            {    //Meny för vilka val du kan välja mellan under en drabbning. 
                Console.WriteLine("1. Attackera");
                Console.WriteLine("2. Visa Hälsopoäng");

                string choice = Console.ReadLine();  //Läser av vad spelaren valt. 

                switch (choice)
                {
                    case "1":

                    Console.WriteLine("Välj en fiende: ");
                    for (int i = 0; i < enemies.Count; i+++)
                    {
                        Console.WriteLine($"{i + 1}. {enemies[i].Name} (Health: {enemies[i].Health})");
                    }

                    int enemyIndex;
                    while ((!int.TryParse(Console.ReadLine(), out enemyIndex) || enemyIndex < 1 || enemyIndex > enemies.Count))
                    {
                        Console.WriteLine("Ogiltligt val. Välj en giltig fiende. ");
                    }

                    Enemy targetEnemy = enemies[enemyIndex - 1];

                    targetEnemy.TakeDamage(player.AttackPower);
                    Console.WriteLine($"Du attackerade {targetEnemy.Name} och gjorde  {player.AttackPower} skada!");

                    if (!targetEnemy.IsAlive())
                    {
                        
                    }

                    //Spelaren attackerar fienden
                        enemy.TakeDamage(player.AttackPower);
                        Console.WriteLine($"Du attackerade fienden {enemy.Name} och gjorde {player.AttackPower} skada!");

                    if (!enemy.IsAlive())
                    {
                        Console.WriteLine($"Du besegrade fienden {enemy.Name}");   //Berättar när fienden har blivit besegrad. 
                        SaveScore("Vinst");
                        gameRunning = false;
                        break;
                    }
                        //Fienden attackerar spelaren
                    player.TakeDamage(enemy.AttackPower);
                    Console.WriteLine($"{enemy.Name} gjorde {enemy.AttackPower} skada!");

                    if (!player.IsAlive())  //Berättar för spelaren när den har blivit besegrad. 
                    {
                        Console.WriteLine("Du har blivit besegrad!");
                        SaveScore("Förlust");
                        gameRunning = false;
                    }
                    break;

                    case "2":   //Skriver ut spelaren och fiendens hälsopoäng
                        Console.WriteLine($"Du har {player.Health} hälsopoäng");
                        Console.WriteLine($"Fienden har {enemy.Health} hälsopoäng");
                        break;

                    default:  //Meddelandet som kommer om du har matat in fel sorts input i menyn. 
                        Console.WriteLine("Felaktig inmatning");
                        break;
                }
            }
        }
        static void SaveScore(string result)   //Funktion för att spara poängen till en fil
        {
            using (StreamWriter writer = new StreamWriter("score.txt"))   //Väljer vilken fil det ska sparas till. 
            {
                writer.WriteLine($"Resultat: {result}");    //Skriver ut resultatet. 
            }
        }
    }
}