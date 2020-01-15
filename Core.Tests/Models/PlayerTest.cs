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
            List<Skill> skills = new List<Skill>();
            List<Activity> activities = new List<Activity>();
            List<BossKill> bossKills = new List<BossKill>();

            skills.Add(new Skill(SkillName.Overall, 2277, 1, 24000000000));
            skills.Add(new Skill(SkillName.Slayer, 99, 1, 200000000));

            activities.Add(new Activity(ActivityName.ClueOverall, 1, 9999));

            bossKills.Add(new BossKill(BossName.Kraken, 1, 9999));

            Player player = new Player("ferrous_hugs", AccountType.Ironman, skills, activities, bossKills);

            this._player = player;
        }

        [Fact]
        public void CanRetrivePlayerOverallSkillTest()
        {
            Assert.Equal(SkillName.Overall, _player.Overall().SkillName);
        }

        [Fact]
        public void CanRetrivePlayerSkillByNameTest()
        {
            Assert.IsType<Skill>(_player.Skill(SkillName.Slayer));
        }

        [Fact]
        public void CanRetrivePlayerActivityByNameTest()
        {
            Assert.IsType<Activity>(_player.Activity(ActivityName.ClueOverall));
        }

        [Fact]
        public void CanRetrivePlayerBossKillByNameTest()
        {
            Assert.IsType<BossKill>(_player.BossKill(BossName.Kraken));
        }
    }
}
