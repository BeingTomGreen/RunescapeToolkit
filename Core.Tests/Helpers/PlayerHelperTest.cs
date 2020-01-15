using Xunit;
using Core.Helpers;

namespace Core.Tests.Helpers
{
    public class PlayerHelperTest
    {
        public PlayerHelperTest() { }

        [Fact]
        public void ValidatesPlayerUsername()
        { 
            Assert.True(PlayerHelper.ValidateUsername("ferrous_hugs"));
            Assert.True(PlayerHelper.ValidateUsername(" ferrous_hugs"));
            Assert.True(PlayerHelper.ValidateUsername("fer__hugs"));
            Assert.True(PlayerHelper.ValidateUsername("ferrous hugs"));
            Assert.True(PlayerHelper.ValidateUsername("fer  hugs"));
            Assert.True(PlayerHelper.ValidateUsername("69_hugs"));

            Assert.False(PlayerHelper.ValidateUsername("ThisUserNameIsToooooLong"));
            Assert.False(PlayerHelper.ValidateUsername("$%$£!()*&^'"));
        }

        [Fact]
        public void CleansUsername()
        {
            Assert.Equal("Ferrous_hugs", PlayerHelper.CleanUsername(" Ferrous hugs"));
        }

    }
}
