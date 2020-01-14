using Xunit;
using Core.Helpers;
using Core.Enums;

namespace Core.Tests.Helpers
{
    public class PlayerHelperTest
    {
        public PlayerHelperTest() { }

        [Fact]
        public void GetAccountTypeDisplayStringTest()
        {
            Assert.Equal("Normal", PlayerHelper.GetAccountTypeDisplayString(Enums.AccountType.Normal));
            Assert.Equal("Ironman", PlayerHelper.GetAccountTypeDisplayString(Enums.AccountType.Ironman));
            Assert.Equal("Ultimate Ironman", PlayerHelper.GetAccountTypeDisplayString(Enums.AccountType.UltimateIronman));
            Assert.Equal("Hardcore Ironman", PlayerHelper.GetAccountTypeDisplayString(Enums.AccountType.HardcoreIronman));
            Assert.Equal("Deadman", PlayerHelper.GetAccountTypeDisplayString(Enums.AccountType.DeadmanMode));
            Assert.Equal("Seasonal Deadman", PlayerHelper.GetAccountTypeDisplayString(Enums.AccountType.SeasonalDeadmanMode));
        }

        [Fact]
        public void ValidateUsernameTest()
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
        public void CleanUsernameTest()
        {
            Assert.Equal("Ferrous_hugs", PlayerHelper.CleanUsername(" Ferrous hugs"));
        }

        [Fact]
        public void BuildHighscoreUrlTest()
        {
            string username = "ferrous_hugs";
            string urlString = "https://secure.runescape.com/m=hiscore_oldschool_{0}/index_lite.ws?player={1}";

            Assert.Equal(string.Format(urlString, "normal", username), PlayerHelper.BuildHighscoreUrl(username).ToString());
            Assert.Equal(string.Format(urlString, "normal", username), PlayerHelper.BuildHighscoreUrl(username, AccountType.Normal).ToString());
            Assert.Equal(string.Format(urlString, "ironman", username), PlayerHelper.BuildHighscoreUrl(username, AccountType.Ironman).ToString());
            Assert.Equal(string.Format(urlString, "ultimate", username), PlayerHelper.BuildHighscoreUrl(username, AccountType.UltimateIronman).ToString());
            Assert.Equal(string.Format(urlString, "hardcore", username), PlayerHelper.BuildHighscoreUrl(username, AccountType.HardcoreIronman).ToString());
            Assert.Equal(string.Format(urlString, "deadman", username), PlayerHelper.BuildHighscoreUrl(username, AccountType.DeadmanMode).ToString());
            Assert.Equal(string.Format(urlString, "seasonal", username), PlayerHelper.BuildHighscoreUrl(username, AccountType.SeasonalDeadmanMode).ToString());
        }
    }
}
