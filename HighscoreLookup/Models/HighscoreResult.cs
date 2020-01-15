using Core.Enums;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Highscore.Models
{
    public class HighscoreResult
    {
        private int SKILLCOUNT { get { return Enum.GetNames(typeof(SkillName)).Length; } }
        private int ACTIVITYCOUNT { get { return Enum.GetNames(typeof(ActivityName)).Length; } }
        private int BossKillCount { get { return Enum.GetNames(typeof(BossName)).Length; } }

        public List<Skill> Skills { get; private set; }

        public List<Activity> Activities { get; private set; }

        public List<BossKill> BossKills { get; private set; }

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

            Skills = buildSkillList(getSkillArray(parsedHighscoreResults));
            Activities = buildActivityList(getActivityArray(parsedHighscoreResults));
            BossKills = buildBossKillList(getBossKillArray(parsedHighscoreResults));
        }

        private string[] getSkillArray(string[] apiResults)
        {
            return apiResults.Take(SKILLCOUNT).ToArray();
        }

        private string[] getActivityArray(string[] apiResults)
        {
            return apiResults.Skip(SKILLCOUNT).Take(ACTIVITYCOUNT).ToArray();
        }

        private string[] getBossKillArray(string[] apiResults)
        {
            return apiResults.Skip(SKILLCOUNT + ACTIVITYCOUNT).Take(BossKillCount).ToArray();
        }

        private List<Skill> buildSkillList(string[] highscoreSkillResults)
        {
            List<Skill> skills = new List<Skill>();

            foreach (var skill in highscoreSkillResults.Select((value, i) => new { i, value }))
            {
                string[] parsedSkill = skill.value.Split(',');

                SkillName skillType = (SkillName)skill.i;
                int rank = int.Parse(parsedSkill[0]);
                int level = int.Parse(parsedSkill[1]);
                int experience = int.Parse(parsedSkill[2]);

                skills.Add(new Skill(skillType, rank, level, experience));
            }

            return skills;
        }

        private List<Activity> buildActivityList(string[] highscoreActivitiesResults)
        {
            List<Activity> activities = new List<Activity>();

            foreach (var activity in highscoreActivitiesResults.Select((value, i) => new { i, value }))
            {
                string[] parsedActivity = activity.value.Split(',');

                ActivityName activityType = (ActivityName)activity.i;
                int rank = int.Parse(parsedActivity[0]);
                int number = int.Parse(parsedActivity[1]);

                activities.Add(new Activity(activityType, rank, number));
            }

            return activities;
        }

        private List<BossKill> buildBossKillList(string[] highscoreBossKillsResults)
        {
            List<BossKill> bossKills = new List<BossKill>();

            foreach (var boss in highscoreBossKillsResults.Select((value, i) => new { i, value }))
            {
                string[] parsedBossKill= boss.value.Split(',');

                BossName bossKillType = (BossName)boss.i;
                int rank = int.Parse(parsedBossKill[0]);
                int number = int.Parse(parsedBossKill[1]);

                bossKills.Add(new BossKill(bossKillType, rank, number));
            }

            return bossKills;
        }

    }
}
