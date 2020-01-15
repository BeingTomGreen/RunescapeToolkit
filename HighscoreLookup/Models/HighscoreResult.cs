using Core.Enums;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Highscore.Models
{
    public class HighscoreResult
    {
        public List<PlayerSkill> Skills { get; private set; }

        public List<PlayerActivity> Activities { get; private set; }

        public List<PlayerBossKill> BossKills { get; private set; }

        public HighscoreResult(string apiResults)
        {
            if (apiResults == null)
            {
                throw new ArgumentNullException(nameof(apiResults));

            }

            if (apiResults.Trim().Length == 0)
            {
                throw new ArgumentException("Value cannot be empty.", nameof(apiResults));

            }

            ProcessApiResults(apiResults);
        }

        private void ProcessApiResults(string apiResults)
        {
            string[] parsedHighscoreResults = apiResults.Split("\n");

            // Drop the last element which is an empty line
            parsedHighscoreResults = parsedHighscoreResults.Take(parsedHighscoreResults.Length - 1).ToArray();

            string[] skillsArray = parsedHighscoreResults.Take(Enum.GetNames(typeof(SkillType)).Length).ToArray();
            string[] activitiesArray = parsedHighscoreResults.Skip(Enum.GetNames(typeof(SkillType)).Length).Take(Enum.GetNames(typeof(ActivityType)).Length).ToArray();
            string[] bossKillsArray = parsedHighscoreResults.Skip(Enum.GetNames(typeof(SkillType)).Length + Enum.GetNames(typeof(ActivityType)).Length).Take(Enum.GetNames(typeof(BossKillType)).Length).ToArray();

            this.Skills = parseSkills(skillsArray);
            this.Activities = parseActivities(activitiesArray);
            this.BossKills = parseBossKills(bossKillsArray);
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

        private List<PlayerBossKill> parseBossKills(string[] highscoreBossKillsResults)
        {
            List<PlayerBossKill> bossKills = new List<PlayerBossKill>();

            foreach (var boss in highscoreBossKillsResults.Select((value, i) => new { i, value }))
            {
                string[] parsedBossKill= boss.value.Split(',');

                BossKillType bossKillType = (BossKillType)boss.i;
                int rank = int.Parse(parsedBossKill[0]);
                int number = int.Parse(parsedBossKill[1]);

                bossKills.Add(new PlayerBossKill(bossKillType, rank, number));
            }

            return bossKills;
        }

    }
}
