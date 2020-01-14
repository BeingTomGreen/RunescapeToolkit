using Core.Exceptions;
using Core.Extensions;
using Core.Models;
using Xunit;

namespace Core.Tests.Models
{
    public class SkillTest
    {
        public SkillTest() { }

        [Fact]
        public void ThrowsInvalidSkillNameExceptionForInvalidSkillName()
        {
            InvalidSkillNameException ex = Assert.Throws<InvalidSkillNameException>(() => new Skill("NotSlayer", 1, 99, 200000));

            Assert.Equal("Skill name, NotSlayer, is invalid.", ex.Message);
        }
    }
}
