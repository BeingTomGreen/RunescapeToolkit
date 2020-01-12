using Xunit;
using Core;
using Core.Enums;

namespace HighscoreTests
{
    public class APITest
    {
        [Fact]
        public void BuildHighscoresUrlTest()
        {
            string username = "ferrous_hugs";
            string urlString = "https://secure.runescape.com/m=hiscore_oldschool_{0}/index_lite.ws?player={1}";

            Assert.Equal(string.Format(urlString, "normal", username), API.BuildHighscoresUrl(username));
            Assert.Equal(string.Format(urlString, "normal", username), API.BuildHighscoresUrl(username, AccountType.Normal));
            Assert.Equal(string.Format(urlString, "ironman", username), API.BuildHighscoresUrl(username, AccountType.Ironman));
            Assert.Equal(string.Format(urlString, "ultimate", username), API.BuildHighscoresUrl(username, AccountType.UltimateIronman));
            Assert.Equal(string.Format(urlString, "hardcore", username), API.BuildHighscoresUrl(username, AccountType.HardcoreIronman));
            Assert.Equal(string.Format(urlString, "deadman", username), API.BuildHighscoresUrl(username, AccountType.DeadmanMode));
            Assert.Equal(string.Format(urlString, "seasonal", username), API.BuildHighscoresUrl(username, AccountType.SeasonalDeadmanMode));
        }

    }
}
