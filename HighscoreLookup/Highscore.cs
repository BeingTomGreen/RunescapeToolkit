using Core;
using Core.Enums;
using Core.Helpers;
using Core.Models;
using Hiscores.Models;
using System;
using System.Threading.Tasks;

namespace Hiscores
{
    public static class Lookup
    {
        public static async Task<Player> FindPlayer(string username, AccountType accountType)
        {
            Uri url = PlayerHelper.BuildHighscoreUrl(username, accountType);

            string apiResults = await API.GetRequest(url).ConfigureAwait(false);

            HighscoreResult highscoreResult = new HighscoreResult(apiResults);

            return new Player(username, accountType, highscoreResult.Skills, highscoreResult.Activities, highscoreResult.BossKills);
        }

    }
}
