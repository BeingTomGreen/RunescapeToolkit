using Core.Enums;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Highscores
{
    public class HighscoresLookup
    {
        public Player Player { get; private set; }

        public HighscoresLookup(string username, AccountType accountType)
        {
            Player = new Player() { Username = username, AccountType = accountType };

            string[] highscoreResults = ParsePlayerHighscores(Player);

            Player.Skills = ParseSkills(highscoreResults);

            Player.Activities = ParseActivities(highscoreResults);
        }
        
        private string[] ParsePlayerHighscores(Player player)
        {
            string highscoresResults = API.QueryHighscores(player).Result;

            string[] parsedHighscoreResults = highscoresResults.Split("\n");

            // Drop the last element which is an empty line
            parsedHighscoreResults = parsedHighscoreResults.Take(parsedHighscoreResults.Count() - 1).ToArray();

            return parsedHighscoreResults;
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
            highscoreResults = highscoreResults.Take(Enum.GetNames(typeof(Activities)).Length).ToArray();

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
    }
}
