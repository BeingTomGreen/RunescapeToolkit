using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Models
{
    public class HighscoreResult
    {
        public List<PlayerSkill> Skills { get; private set; }

        public List<PlayerActivity> Activities { get; private set; }

        public HighscoreResult(string apiResults)
        {
            string[] parsedHighscoreResults = apiResults.Split("\n");

            // Drop the last element which is an empty line
            parsedHighscoreResults = parsedHighscoreResults.Take(parsedHighscoreResults.Length - 1).ToArray();

            string[] skillsArray = parsedHighscoreResults.Take(Enum.GetNames(typeof(SkillType)).Length).ToArray();
            string[] activitiesArray = parsedHighscoreResults.TakeLast(Enum.GetNames(typeof(ActivityType)).Length).ToArray();

            this.Skills = parseSkills(skillsArray);
            this.Activities = parseActivities(activitiesArray);
        }

        private List<PlayerSkill> parseSkills(string[] highscoreSkillResults)
        {
            List<PlayerSkill> skills = new List<PlayerSkill>();

            foreach (var skill in highscoreSkillResults.Select((value, i) => new { i, value }))
            {
                string[] parsedSkill = skill.value.Split(',');

                SkillType skillType = (SkillType)skill.i;
                int rank = int.Parse(parsedSkill[0]);
                int level = int.Parse(parsedSkill[1]);
                int experience = int.Parse(parsedSkill[2]);

                skills.Add(new PlayerSkill(skillType, rank, level, experience));
            }

            return skills;
        }

        private List<PlayerActivity> parseActivities(string[] highscoreActivitiesResults)
        {
            List<PlayerActivity> activities = new List<PlayerActivity>();

            foreach (var activity in highscoreActivitiesResults.Select((value, i) => new { i, value }))
            {
                string[] parsedActivity = activity.value.Split(',');

                ActivityType activityType = (ActivityType)activity.i;
                int rank = int.Parse(parsedActivity[0]);
                int number = int.Parse(parsedActivity[1]);

                activities.Add(new PlayerActivity(activityType, rank, number));
            }

            return activities;
        }
    }
}
