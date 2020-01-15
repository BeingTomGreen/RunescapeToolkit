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
            List<PlayerSkill> skills = new List<PlayerSkill>();
            List<PlayerActivity> activities = new List<PlayerActivity>();
            List<PlayerBossKill> bossKills = new List<PlayerBossKill>();

            skills.Add(new PlayerSkill(SkillType.Overall, 2277, 1, 24000000000));
            skills.Add(new PlayerSkill(SkillType.Slayer, 99, 1, 200000));

            activities.Add(new PlayerActivity(ActivityType.ClueEasy, 1, 1));

            bossKills.Add(new PlayerBossKill(BossKillType.BarrowsChests, 1, 9999));

            Player player = new Player("ferrous_hugs", AccountType.Ironman, skills, activities, bossKills);

            this._player = player;
        }

        [Fact]
        public void CanRetrivePlayerOverallSkillTest()
        {
            Assert.Equal(SkillType.Overall, _player.Overall().SkillType);
        }

        [Fact]
        public void CanRetrivePlayerSkillByTypeTest()
        {
            Assert.IsType<PlayerSkill>(_player.Skill(SkillType.Slayer));
        }

    }
}
