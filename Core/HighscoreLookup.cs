using Core.Enums;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public class HighscoreLookup
    {
        public Player Player { get; private set; }

        public HighscoreLookup(string username, AccountType accountType)
        {
            string apiResults = API.QueryHighscores(username, accountType).Result;

            HighscoreResult highscoreResult = new HighscoreResult(apiResults);

            this.Player = new Player(username, accountType, ParseSkills(highscoreResult.Skills), ParseActivities(highscoreResult.Activities));
        }

        private List<Skill> ParseSkills(string[] highscoreResults)
        {
            List<Skill> skills = new List<Skill>();

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
