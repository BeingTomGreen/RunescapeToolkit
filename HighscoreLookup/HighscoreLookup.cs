using Core;
using Core.Enums;
using Core.Helpers;
using Core.Models;
using Highscore.Models;
using System;

namespace Highscore
{
    public class HighscoreLookup
    {
        public Player Player { get; private set; }

        public HighscoreLookup(string username, AccountType accountType)
        {
            Uri url = PlayerHelper.BuildHighscoreUrl(username, accountType);

            string apiResults = API.GetString(url).Result;

            HighscoreResult highscoreResult = new Models.HighscoreResult(apiResults);

            this.Player = new Player(username, accountType, highscoreResult.Skills, highscoreResult.Activities, highscoreResult.BossKills);
        }

    }
}
