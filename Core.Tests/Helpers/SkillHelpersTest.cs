using System;
using Xunit;
using Core.Helpers;
using Core.Exceptions;

namespace Core.Tests.Helpers
{
    public class SkillHelpersTest
    {
        //private readonly _skill;

        public SkillHelpersTest()
        {
            //_skill= new Skill();
        }

        [Fact]
        public void throwsExceptionForInvalidSkillName()
        {
            var ex = Assert.Throws<InvalidSkillNameException>(() => SkillHelpers.validateSkillName("NotSlayer"));

            Assert.Equal("Skill name, NotSlayer, is invalid.", ex.Message);

        }
    }
}
