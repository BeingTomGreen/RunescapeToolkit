using RunescapeConsole.Enums;
using RunescapeConsole.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RunescapeConsole
{
    class HighscoreLookup
    {
        private static readonly string highscoreUrl = "https://secure.runescape.com/m=hiscore_oldschool_{0}/index_lite.ws?player={1}";

        //private readonly string[] HighscoreSKills = { "overall", "attack", "defence", "strength", "hitpoints", "ranged", "prayer", "magic", "cooking", "woodcutting", "fletching", "fishing", "firemaking", "crafting", "smithing", "mining", "herblore", "agility", "thieving", "slayer", "farming", "runecraft", "hunter", "construction" };
        //private readonly string[] HighscoreMinigames = { "clue_all", "clue_easy", "clue_medium", "clue_hard", "clue_elite", "clue_master ", "bounty_hunter_rogue_kills", "bounty_hunter_target_kills", "last_man_standing" };

        public Player Player { get; private set; }

        public HighscoreLookup(string username, AccountType accountType)
        {
            Player = new Player() { Username = username, AccountType = accountType };

            UpdatePlayerStats();
        }

        private void UpdatePlayerStats()
        {
            // Get Highscores results
            string[] highscoreResults = LookupPlayerHighscores(Player);

            Player.Skills = ParseSkills(highscoreResults);

            Player.Activities = ParseActivities(highscoreResults);
        }

        private string[] LookupPlayerHighscores(Player player)
        {
            string highscoresResults = QueryHighscores(BuildHighscoresUrl(player.Username, player.AccountType)).Result;

            string[] parsedHighscoreResults = highscoresResults.Split("\n");

            // Drop the last element which is an empty line
            parsedHighscoreResults = parsedHighscoreResults.Take(parsedHighscoreResults.Count() - 1).ToArray();

            return parsedHighscoreResults;
        }

        private async Task<string> QueryHighscores(string url)
        {
            string results = "";

            HttpClient httpClient = new HttpClient();

            try
            {
                //string Results = await HttpClient.GetStringAsync(Url);
                results = await httpClient.GetStringAsync(url);

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            httpClient.Dispose();

            return results.ToString();
        }

        private List<Skill> ParseSkills(string[] highscoreResults)
        {
            List<Skill> skills = new List<Skill>();

            // Grab the first x number of results where x is the total number of skills
            highscoreResults = highscoreResults.Take(Enum.GetNames(typeof(Skills)).Length).ToArray();

            foreach (var skill in highscoreResults.Select((value, i) => new { i, value }))
            {
                string[] parsedSkill = skill.value.Split(',');

                string name = Enum.GetName(typeof(Skills), skill.i);
                int rank = int.Parse(parsedSkill[0]);
                int level = int.Parse(parsedSkill[1]);
                int experience = int.Parse(parsedSkill[2]);

                skills.Add(new Skill() { Name = name, Rank = rank, Level = level, Experience = experience });
            }

            return skills;
        }

        private List<Activity> ParseActivities(string[] highscoreResults)
        {
            List<Activity> activities = new List<Activity>();

            // Skip x number of elements, then select remaining elements where x is the total number of skills, this skips the skills and selects the minigames
            highscoreResults = highscoreResults.Skip(Enum.GetNames(typeof(Activities)).Length).ToArray();

            foreach (var activity in highscoreResults.Select((value, i) => new { i, value }))
            {
                string[] parsedActivity = activity.value.Split(',');

                string name = Enum.GetName(typeof(Activities), activity.i);
                int rank = int.Parse(parsedActivity[0]);
                int number = int.Parse(parsedActivity[1]);

                activities.Add(new Activity() { Name = name, Rank = rank, Number = number });
            }

            return activities;
        }

        private string BuildHighscoresUrl(string username, AccountType accountType)
        {
            string accountTypeString = GetAccountTypeString(accountType);

            return string.Format(highscoreUrl, accountTypeString, username);
        }

        public static string GetAccountTypeString(AccountType accountType)
        {
            string accountTypeString;

            switch (accountType)
            {
                case AccountType.Normal:
                    accountTypeString = "normal";
                    break;
                case AccountType.Ironman:
                    accountTypeString = "ironman";
                    break;
                case AccountType.UltimateIronman:
                    accountTypeString = "ultimate";
                    break;
                case AccountType.HardcoreIronman:
                    accountTypeString = "hardcore";
                    break;
                case AccountType.DeadmanMode:
                    accountTypeString = "deadman";
                    break;
                case AccountType.SeasonalDeadmanMode:
                    accountTypeString = "seasonal";
                    break;
                default:
                    accountTypeString = "normal";
                    break;
            }

            return accountTypeString;
        }
    }
}
