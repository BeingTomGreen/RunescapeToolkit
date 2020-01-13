using System;
using Xunit;
using Core.Helpers;
using Core.Exceptions;

namespace Core.Tests.Helpers
{
    public class SkillHelpersTest
    {
        public SkillHelpersTest() { }

        [Fact]
        public void ValidateSkillNameTest()
        {
            Assert.True(SkillHelpers.ValidateSkillName("Slayer"));
            Assert.False(SkillHelpers.ValidateSkillName("NotSlayer"));
        }
    }
}
