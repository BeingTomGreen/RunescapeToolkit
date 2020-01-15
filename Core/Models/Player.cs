using System.Collections.Generic;
using Core.Enums;
using Core.Helpers;

namespace Core.Models
{
    public class Player
    {
        public string Username { get; private set; }

        public AccountType AccountType { get; private set; }

        public List<Skill> Skills { get; private set; }

        public List<Activity> Activities{ get; private set; }

        public List<BossKill> BossKills { get; private set; }

        public Player(string username, AccountType accountType, List<Skill> skills, List<Activity> activities, List<BossKill> bossKills)
        {
            this.Username = PlayerHelper.CleanUsername(username);
            this.AccountType = accountType;
            this.Skills = skills;
            this.Activities = activities;
            this.BossKills = bossKills;
        }

        public Skill Overall()
        {
            return this.Skills.Find(x => x.SkillName.Equals(SkillName.Overall));
        }

        public Skill Skill(SkillName skillType)
        {
            return this.Skills.Find(x => x.SkillName.Equals(skillType));
        }

        public Activity Activity(ActivityName activityName)
        {
            return this.Activities.Find(x => x.ActivityName.Equals(activityName));
        }

        public BossKill BossKill(BossName bossName)
        {
            return this.BossKills.Find(x => x.BossName.Equals(bossName));
        }
    }
}
