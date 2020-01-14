using System;
using System.Collections.Generic;
using Core;
using Core.Enums;
using Core.Helpers;
using Core.Models;
using Core.Extensions;

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

            DisplayPlayerSkills(player.Skills);

            DisplayPlayerActivities(player.Activities);
        }

        private static void DisplayPlayerSkills(List<PlayerSkill> skills)
        {
            Console.WriteLine("Your Skills:");

            skills.ForEach(skill => Console.WriteLine($"{skill.Skill.ToString()} - Level: {skill.Level}{(skill.IsMax() ? " (Max)" : "")}, Experience: {skill.Experience.ToString("N0")}, Rank: {skill.Rank.ToString("N0")}"));
        }

        private static void DisplayPlayerActivities(List<PlayerActivity> activities)
        {
            Console.WriteLine("Your Activities:");

            activities.ForEach(activity => Console.WriteLine($"{activity.Activity.ToString()} - Rank: {activity.Rank.ToString("N0")}, Count: {activity.Number.ToString("N0")}"));
        }

        private static string AskForUsername()
        {
            string username;

            Console.Write("Please enter your OSRS username: ");
            
            username = Console.ReadLine();
            bool isValidUsername = false;

            do
            {
                if (PlayerHelper.ValidateUsername(username))
                {
                    isValidUsername = true;
                }
                else
                {
                    Console.WriteLine("That username isn't valid, please try again...");
                    Console.Write("Please enter your OSRS username: ");
                    username = Console.ReadLine();
                }
            } while (!isValidUsername);

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
