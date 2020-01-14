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

            skills.Add(new PlayerSkill(SkillType.Slayer, 99, 1, 200000));

            activities.Add(new PlayerActivity(ActivityType.ClueEasy, 1, 1));

            Player player = new Player("ferrous_hugs", AccountType.Ironman, skills, activities);

            this._player = player;
        }

        [Fact]
        public void CanRetrivePlayerSkillByType()
        {
            Assert.IsType<PlayerSkill>(_player.Skill(SkillType.Slayer));
        }

    }
}
