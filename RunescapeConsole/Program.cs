using System;
using System.Collections.Generic;
using System.Linq;
using RunescapeConsole.Enums;
using RunescapeConsole.Models;


namespace RunescapeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string username;
            AccountType accountType;

            username = "ferrous_hugs";//AskForUsername();

            accountType = AccountType.Ironman;//AskForAccountType();

            Player player = new HighscoreLookup(username, accountType).Player;

            DisplayPlayerInformation(player);

            Console.ReadLine();
        }

        private static void DisplayPlayerInformation(Player player)
        {
            Console.WriteLine($"Welcome, { player.Username }, you're an { player.AccountType }");

            Console.WriteLine("Your Skills:");

            foreach (Skill skill in player.Skills)
            {
                Console.WriteLine(skill.Name + " - Level: " + skill.Level + ", Experience: " + skill.Experience.ToString("N0") + ", Rank: " + skill.Rank.ToString("N0"));
            }

            Console.WriteLine("Your Activities:");

            foreach (Activity activity in player.Activities)
            {
                Console.WriteLine(activity.Name + " - Rank: " + activity.Rank.ToString("N0") + ", Count: " + activity.Number.ToString("N0"));
            }

        }

        private static string AskForUsername()
        {
            string username;

            Console.Write("Please enter your OSRS username: ");
            username = Console.ReadLine();

            return Player.CleanUsername(username);
        }

        private static AccountType AskForAccountType()
        {
            int accountTypeInt;

            Console.WriteLine("Please enter your Account type: ");

            Array accountTypes = Enum.GetValues(typeof(AccountType));

            foreach (AccountType type in accountTypes)
            {
                string typeString = type.ToString();
                int typeInt = Convert.ToInt32(type);

                Console.WriteLine(typeString + ": " + typeInt);
            }

            accountTypeInt = int.Parse(Console.ReadLine());

            AccountType accountType = (AccountType)accountTypeInt;

            return accountType;
        }
    }
}
