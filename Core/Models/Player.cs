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

        public float CombatLevel { get; private set; }

        public Player(string username, AccountType accountType, List<Skill> skills, List<Activity> activities, List<BossKill> bossKills)
        {
            Username = PlayerHelper.CleanUsername(username);
            AccountType = accountType;
            Skills = skills;
            Activities = activities;
            BossKills = bossKills;

            CombatLevel = calculatePlayerCombatLevel();
        }

        public Skill Overall()
        {
            return this.Skills.Find(x => x.SkillName.Equals(SkillType.Overall));
        }

        public Skill getSkill(SkillType skillType)
        {
            return this.Skills.Find(x => x.SkillName.Equals(skillType));
        }

        public Activity getActivity(ActivityName activityName)
        {
            return this.Activities.Find(x => x.ActivityName.Equals(activityName));
        }

        public BossKill getBossKill(BossName bossName)
        {
            return this.BossKills.Find(x => x.BossName.Equals(bossName));
        }

        private float calculatePlayerCombatLevel()
        {
            int attackLevel = getSkill(SkillType.Attack).Level;
            int strengthLevel = getSkill(SkillType.Strength).Level;
            int defenceLevel = getSkill(SkillType.Defence).Level;
            int prayerLevel = getSkill(SkillType.Prayer).Level;
            int rangedLevel = getSkill(SkillType.Ranged).Level;
            int magicLevel = getSkill(SkillType.Magic).Level;
            int hitpointsLevel = getSkill(SkillType.Hitpoints).Level;

            return PlayerHelper.CalculateCombatLevel(attackLevel, strengthLevel, defenceLevel, prayerLevel, rangedLevel, magicLevel, hitpointsLevel);
        }
    }
}
