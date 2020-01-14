using Core.Extensions;
using Core.Models;
using Xunit;

namespace Core.Tests.Extensions
{
    public class SkillExtensionsTest
    {

        [Fact]
        public void IsMaxTest()
        {
            Assert.True(new Skill("Slayer", 1, 99, 200000).IsMax());
            Assert.True(new Skill("Overall", 1, 2277, 200000).IsMax());
            Assert.False(new Skill("Slayer", 1, 69, 200000).IsMax());
            Assert.False(new Skill("Overall", 1, 69, 200000).IsMax());
        }
    }
}
