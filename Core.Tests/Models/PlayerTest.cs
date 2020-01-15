using Core.Enums;
using Core.Models;
using System.Collections.Generic;
using Xunit;

namespace Core.Tests.Models
{
    public class PlayerTest
    {
        private Player _player;

        public PlayerTest()
        {
            _player = BuildPlayer();
        }

        [Fact]
        public void CanRetrivePlayerOverallSkillTest()
        {
            Assert.Equal(SkillType.Overall, _player.Overall().SkillName);
        }

        [Fact]
        public void CanRetrivePlayerSkillByNameTest()
        {
            Assert.IsType<Skill>(_player.getSkill(SkillType.Slayer));
        }

        [Fact]
        public void CanRetrivePlayerActivityByNameTest()
        {
            Assert.IsType<Activity>(_player.getActivity(ActivityName.ClueOverall));
        }

        [Fact]
        public void CanRetrivePlayerBossKillByNameTest()
        {
            Assert.IsType<BossKill>(_player.getBossKill(BossName.Kraken));
        }

        private Player BuildPlayer()
        {
            List<Skill> skills = new List<Skill>();
            List<Activity> activities = new List<Activity>();
            List<BossKill> bossKills = new List<BossKill>();

            skills.Add(new Skill(SkillType.Overall, 2277, 1, 24000000000));
            skills.Add(new Skill(SkillType.Slayer, 99, 1, 200000000));
            skills.Add(new Skill(SkillType.Attack, 99, 1, 200000000));
            skills.Add(new Skill(SkillType.Strength, 99, 1, 200000000));
            skills.Add(new Skill(SkillType.Defence, 99, 1, 200000000));
            skills.Add(new Skill(SkillType.Prayer, 99, 1, 200000000));
            skills.Add(new Skill(SkillType.Ranged, 99, 1, 200000000));
            skills.Add(new Skill(SkillType.Magic, 99, 1, 200000000));
            skills.Add(new Skill(SkillType.Hitpoints, 99, 1, 200000000));

            activities.Add(new Activity(ActivityName.ClueOverall, 1, 9999));

            bossKills.Add(new BossKill(BossName.Kraken, 1, 9999));

            Player player = new Player("ferrous_hugs", AccountType.Ironman, skills, activities, bossKills);

            return player;
        }
    }
}
