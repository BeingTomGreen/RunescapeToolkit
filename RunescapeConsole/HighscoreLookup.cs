using Core.Enums;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Highscore.Models;

namespace Highscore
{
    public class HighscoreLookup
    {
        public HighscoreResult HighscoreResult { get; private set;}

        public HighscoreLookup(string username, AccountType accountType)
        {
            Player player = new Player(username, accountType);

            string apiResults = API.QueryHighscores(player).Result;

            string[] highscoreResults = API.ParseAPIResults(apiResults);

            player.Skills = ParseSkills(highscoreResults);

            player.Activities = ParseActivities(highscoreResults);
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

                skills.Add(new Skill(name, rank, level, experience));
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

                activities.Add(new Activity(name, rank, number));
            }

            return activities;
        }
    }
}
