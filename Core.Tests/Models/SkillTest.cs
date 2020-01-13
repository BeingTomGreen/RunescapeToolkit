using Core.Exceptions;
using Core.Helpers;
using Core.Models;
using System;
using Xunit;

namespace Core.Tests.Models
{
    public class SkillTest
    {
        public SkillTest() { }

        [Fact]
        public void IsMaxTest()
        {
            Assert.True(new Skill("Slayer", 1, 99, 200000).IsMax);
            Assert.False(new Skill("Slayer", 1, 69, 200000).IsMax);
            Assert.True(new Skill("Overall", 1, 2277, 200000).IsMax);
            Assert.False(new Skill("Overall", 1, 69, 200000).IsMax);
        }

        [Fact]
        public void CorrectlyChecksSkillName()
        {
            InvalidSkillNameException ex = Assert.Throws<InvalidSkillNameException>(() => new Skill("NotSlayer", 1, 99, 200000));

            Assert.Equal("Skill name, NotSlayer, is invalid.", ex.Message);
            Assert.Equal("Slayer", new Skill("Slayer", 1, 99, 200000).Name);
        }
    }
}
