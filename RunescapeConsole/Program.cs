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

            ParsePlayerSkills(player.Skills);

            ParsePlayerActivities(player.Activities);
        }

        private static void ParsePlayerSkills(List<Skill> skills)
        {
            Console.WriteLine("Your Skills:");

            // Yes, foreach {Console.Write} isn't the best way to handle this I'm sure, but it works for this... sue me...
            foreach (Skill skill in skills)
            {
                Console.Write(skill.Name + " - ");
                Console.Write("Level: " + skill.Level);

                if (skill.IsMax)
                {
                    Console.Write(" (Max)");
                }

                Console.Write(", ");
                Console.Write("Experience: " + skill.Experience.ToString("N0") + ", ");
                Console.Write("Rank: " + skill.Rank.ToString("N0"));
                Console.WriteLine();
            }
        }

        private static void ParsePlayerActivities(List<Activity> activities)
        {
            Console.WriteLine("Your Activities:");

            // Yes, foreach {Console.Write} isn't the best way to handle this I'm sure, but it works for this... sue me...
            foreach (Activity activity in activities)
            {
                Console.Write(activity.Name + " - ");
                Console.Write("Rank: " + activity.Rank + ", ");
                Console.Write("Count: " + activity.Number.ToString("N0") + ", ");
                Console.WriteLine();
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
