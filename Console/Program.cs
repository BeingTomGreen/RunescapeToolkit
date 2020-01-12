using System;
using System.Collections.Generic;
using Core;
using Core.Enums;
using Core.Helpers;
using Core.Models;

namespace Tools
{
    class Program
    {
        static void Main(string[] args)
        {
            string username;
            AccountType accountType;

            //username = AskForUsername();
            //accountType = AskForAccountType();

            username = "ferrous_hugs";
            accountType = AccountType.Ironman;

            Player player = new HighscoreLookup(username, accountType).Player;

            DisplayAccountInformation(player);

            Console.ReadLine();
        }

        private static void DisplayAccountInformation(Player player)
        {
            Console.Clear();

            Console.WriteLine($"Welcome, { player.Username } ({ player.AccountType })");

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
                Console.Write("Rank: " + activity.Rank.ToString("N0") + ", ");
                Console.Write("Count: " + activity.Number.ToString("N0") + ", ");
                Console.WriteLine();
            }
        }

        private static string AskForUsername()
        {
            string username;

            Console.Write("Please enter your OSRS username: ");
            username = Console.ReadLine();

            return PlayerHelper.CleanUsername(username);
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
