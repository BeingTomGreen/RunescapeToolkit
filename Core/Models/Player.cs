using System.Collections.Generic;
using Core.Enums;
using Core.Helpers;

namespace Core.Models
{
    public class Player
    {
        public string Username { get; private set; }

        public AccountType AccountType { get; private set; }

        public List<PlayerSkill> Skills { get; private set; }

        public List<PlayerActivity> Activities{ get; private set; }

        public List<PlayerBossKill> BossKills { get; private set; }

        public Player(string username, AccountType accountType, List<PlayerSkill> skills, List<PlayerActivity> activities, List<PlayerBossKill> bossKills)
        {
            this.Username = PlayerHelper.CleanUsername(username);
            this.AccountType = accountType;
            this.Skills = skills;
            this.Activities = activities;
            this.BossKills = bossKills;
        }

        public PlayerSkill Overall()
        {
            return this.Skills.Find(x => x.SkillType.Equals(SkillType.Overall));
        }

        public PlayerSkill Skill(SkillType skillType)
        {
            return this.Skills.Find(x => x.SkillType.Equals(skillType));
        }

    }
}
