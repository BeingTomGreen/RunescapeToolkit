using System;
using System.Linq;
using RunescapeConsole.Enums;
using RunescapeConsole.Models;


namespace RunescapeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hi");

            HighscoreLookup highscoreLookup = new HighscoreLookup("ferrous_hugs", AccountType.Ironman);

            Player player = highscoreLookup.Player;

            foreach (Skill skill in player.Skills)
            {
                Console.WriteLine(skill.Name);
            }

            Console.ReadLine();
        }
    }
}
