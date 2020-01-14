using Core.Extensions;
using Core.Models;
using Core.Enums;
using Xunit;

namespace Core.Tests.Extensions
{
    public class SkillExtensionsTest
    {

        [Fact]
        public void IsMaxTest()
        {
            Assert.True(new PlayerSkill(SkillType.Slayer, 1, 99, 200000).IsMax());
            Assert.True(new PlayerSkill(SkillType.Overall, 1, 2277, 200000).IsMax());
            Assert.False(new PlayerSkill(SkillType.Slayer, 1, 69, 200000).IsMax());
            Assert.False(new PlayerSkill(SkillType.Overall, 1, 150, 200000).IsMax());
        }
    }
}
