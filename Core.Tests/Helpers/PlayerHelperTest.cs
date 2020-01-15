using Xunit;
using Core.Helpers;
using Core.Enums;
using System;
using Core.Extensions;

namespace Core.Tests.Helpers
{
    public class PlayerHelperTest
    {
        public PlayerHelperTest() { }

        [Fact]
        public void CleansUsername()
        {
            Assert.Equal("Ferrous_hugs", PlayerHelper.CleanUsername(" Ferrous hugs"));
        }

        [Fact]
        public void ValidatesPlayerUsername()
        { 
            Assert.True(PlayerHelper.ValidateUsername("ferrous_hugs"));
            Assert.True(PlayerHelper.ValidateUsername(" ferrous_hugs"));
            Assert.True(PlayerHelper.ValidateUsername("fer__hug   s"));
            Assert.True(PlayerHelper.ValidateUsername("ferrous hugs"));
            Assert.True(PlayerHelper.ValidateUsername("fer  hugs"));
            Assert.True(PlayerHelper.ValidateUsername("69_hugs"));

            Assert.False(PlayerHelper.ValidateUsername("ThisUserNameIsToooooLong"));
            Assert.False(PlayerHelper.ValidateUsername("$%$£!()*&^'"));
        }

        [Fact]
        public void BuildsHighscoreUrl()
        {
            string username = "ferrous_hugs";
            string highscoreUrl = "https://secure.runescape.com/m=hiscore_oldschool_{0}/index_lite.ws?player={1}";

            Assert.Equal(new Uri(string.Format(highscoreUrl, AccountType.Normal.UrlValue(), username)), PlayerHelper.BuildHighscoreUrl(username, AccountType.Normal));
            Assert.Equal(new Uri(string.Format(highscoreUrl, AccountType.Ironman.UrlValue(), username)), PlayerHelper.BuildHighscoreUrl(username, AccountType.Ironman));
            Assert.Equal(new Uri(string.Format(highscoreUrl, AccountType.HardcoreIronman.UrlValue(), username)), PlayerHelper.BuildHighscoreUrl(username, AccountType.HardcoreIronman));
            Assert.Equal(new Uri(string.Format(highscoreUrl, AccountType.UltimateIronman.UrlValue(), username)), PlayerHelper.BuildHighscoreUrl(username, AccountType.UltimateIronman));
            Assert.Equal(new Uri(string.Format(highscoreUrl, AccountType.DeadmanMode.UrlValue(), username)), PlayerHelper.BuildHighscoreUrl(username, AccountType.DeadmanMode));
            Assert.Equal(new Uri(string.Format(highscoreUrl, AccountType.SeasonalDeadmanMode.UrlValue(), username)), PlayerHelper.BuildHighscoreUrl(username, AccountType.SeasonalDeadmanMode));
        }

        [Fact]
        public void CalculatesCombatLevel()
        {
            Assert.Equal(3.4, PlayerHelper.CalculateCombatLevel(1, 1, 1, 1, 1, 1, 10));
            Assert.Equal(31.75, PlayerHelper.CalculateCombatLevel(25, 25, 25, 25, 25, 25, 25));
            Assert.Equal(63.75, PlayerHelper.CalculateCombatLevel(50, 50, 50, 50, 50, 50, 50));
            Assert.Equal(117.30000000000001, PlayerHelper.CalculateCombatLevel(92, 92, 92, 92, 92, 92, 92));
            Assert.Equal(126.10000000000001, PlayerHelper.CalculateCombatLevel(99, 99, 99, 99, 99, 99, 99));
        }
    }
}
