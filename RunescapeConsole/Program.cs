using System;
using System.Linq;
using RunescapeConsole.Models;


namespace RunescapeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int AccountType = 0;

            Console.Write("Enter your OSRS Username: ");
            string Username = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Enter your OSRS Account Type: ");
            Console.WriteLine("Normal = 0");
            Console.WriteLine("Ironman = 1");
            Console.WriteLine("Ultimate Ironman = 2");
            Console.WriteLine("Hardcore Ironman = 3");
            Console.WriteLine("Deadman = 4");
            Console.WriteLine("Seasonal = 5");
            AccountType = int.Parse(Console.ReadLine());

            Player Player = new HighscoreLookup(new Player(Username, AccountType)).LookupPlayer();

            Console.Clear();

            Console.WriteLine("\n" + Player.Username + ", your Slayer rank is:");

            Skill slayer = Player.Skills.Where(c => c.Name == "slayer").First();

            Console.WriteLine(slayer.Rank);

            Console.WriteLine("\n\n");

            foreach (Skill skill in Player.Skills)
            {
                Console.WriteLine(skill.Name + ": " + " Level: " + skill.Level + ", Exp:  " + skill.Experience + ", Rank: " + skill.Rank);
            }

            Console.WriteLine("\n\n");

            foreach (Minigame minigame in Player.Minigames)
            {
                Console.WriteLine(minigame.Name + ": " + " Number: " + minigame.Number + ", Rank: " + minigame.Rank);
            }

            Console.ReadLine();
        }
    }
}
