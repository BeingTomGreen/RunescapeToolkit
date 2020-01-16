using System;
using System.Collections.Generic;
using Core.Enums;
using Core.Helpers;
using Core.Models;
using Core.Extensions;
using Hiscores;
using System.Threading.Tasks;

namespace Tools
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string username;
            AccountType accountType;

            //username = AskForUsername();
            //accountType = AskForAccountType();

            username = "iron_mammal";
            accountType = AccountType.Ironman;

            Player player = await Lookup.FindPlayer(username, accountType);

            DisplayAccountInformation(player);

            Console.ReadLine();
        }

        private static void DisplayAccountInformation(Player player)
        {
            Console.Clear();

            Console.WriteLine($"Welcome, { player.Username } ({ player.AccountType.DisplayValue() })");

            Console.WriteLine("Your combat level is: " + player.CombatLevel);

            DisplayPlayerSkills(player.Skills);

            DisplayPlayerActivities(player.Activities);

            DisplayPlayerBossKills(player.BossKills);
        }

        private static void DisplayPlayerSkills(List<Skill> skills)
        {
            Console.WriteLine("Your Skills:");

            skills.ForEach(skill => Console.WriteLine($"{skill.SkillName.ToString()} - Level: {skill.Level}{(skill.IsMax() ? " (Max)" : "")}, Experience: {skill.Experience.ToString("N0")}, Rank: {skill.Rank.ToString("N0")}"));
        }

        private static void DisplayPlayerActivities(List<Activity> activities)
        {
            Console.WriteLine("Your Activities:");

            activities.ForEach(activity => Console.WriteLine($"{activity.ActivityName.DisplayValue()} - Rank: {activity.Rank.ToString("N0")}, Count: {activity.Number.ToString("N0")}"));
        }

        private static void DisplayPlayerBossKills(List<BossKill> bossKills)
        {
            Console.WriteLine("Your Boss Kills:");

            bossKills.ForEach(bossKill => Console.WriteLine($"{bossKill.BossName.ToString()} - Rank: {bossKill.Rank.ToString("N0")}, Count: {bossKill.Number.ToString("N0")}"));
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
