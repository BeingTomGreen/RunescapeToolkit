using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Models
{
    public class HighscoreResult
    {
        public List<Skill> Skills { get; private set; }

        public List<Activity> Activities { get; private set; }

        public HighscoreResult(string apiResults)
        {
            string[] parsedHighscoreResults = apiResults.Split("\n");

            // Drop the last element which is an empty line
            parsedHighscoreResults = parsedHighscoreResults.Take(parsedHighscoreResults.Count() - 1).ToArray();

            string[] skillsArray = parsedHighscoreResults.Take(Enum.GetNames(typeof(Skills)).Length).ToArray();
            string[] activitiesArray = parsedHighscoreResults.TakeLast(Enum.GetNames(typeof(Activities)).Length).ToArray();

            this.Skills = parseSkills(skillsArray);
            this.Activities = parseActivities(activitiesArray);
        }

        private List<Skill> parseSkills(string[] highscoreSkillResults)
        {
            List<Skill> skills = new List<Skill>();

            foreach (var skill in highscoreSkillResults.Select((value, i) => new { i, value }))
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

        private List<Activity> parseActivities(string[] highscoreActivitiesResults)
        {
            List<Activity> activities = new List<Activity>();

            foreach (var activity in highscoreActivitiesResults.Select((value, i) => new { i, value }))
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
