using RunescapeConsole.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RunescapeConsole
{
    class HighscoreLookup
    {
        private readonly string HighscoreUrl = "https://secure.runescape.com/m=hiscore_oldschool_{0}/index_lite.ws?player={1}";

        private readonly string[] HighscoreSKills = { "overall", "attack", "defence", "strength", "hitpoints", "ranged", "prayer", "magic", "cooking", "woodcutting", "fletching", "fishing", "firemaking", "crafting", "smithing", "mining", "herblore", "agility", "thieving", "slayer", "farming", "runecraft", "hunter", "construction" };
        private readonly string[] HighscoreMinigames = { "clue_all", "clue_easy", "clue_medium", "clue_hard", "clue_elite", "clue_master ", "bounty_hunter_rogue_kills", "bounty_hunter_target_kills", "last_man_standing" };

        private Player Player;

        public string Username { get { return Player.Username; } }
        public string AccountType { get { return Player.AccountType; } }
        
        public HighscoreLookup(Player Player)
        {
            this.Player = Player;
        }

        public Player LookupPlayer()
        {
            string HighscoresResults = QueryHighscores(BuildHighscoresUrl(Username, AccountType)).Result;

            string[] ParsedHighscoreResults = HighscoresResults.Split("\n");

            // Drop the last element which is an empty line
            ParsedHighscoreResults = ParsedHighscoreResults.Take(ParsedHighscoreResults.Count() - 1).ToArray();
            
            // Pass the first x number of results to ParseSkills() where x is the total number of skills
            Player.Skills = ParseSkills(ParsedHighscoreResults.Take(HighscoreSKills.Count()).ToArray());

            // Skip x number of results, then pass remaining elements to ParseMinigames() where x is the total number of skills, this skips the skills and selects the minigames
            Player.Minigames = ParseMinigames(ParsedHighscoreResults.Skip(HighscoreSKills.Count()).ToArray());

            return Player;
        }

        private static async Task<string> QueryHighscores(string Url)
        {
            string Results = "";

            HttpClient HttpClient = new HttpClient();
            
            try
            {
                //string Results = await HttpClient.GetStringAsync(Url);
                Results = await HttpClient.GetStringAsync(Url);

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            HttpClient.Dispose();

            return Results.ToString();
        }

        private List<Skill> ParseSkills(string[] SkillResults)
        {
            List<Skill> Skills = new List<Skill>();

            int skillIndex = 0;

            foreach (string Skill in SkillResults)
            {
                string[] ParsedSkill = Skill.Split(',');

                string Name = HighscoreSKills[skillIndex];
                int Rank = int.Parse(ParsedSkill[0]);
                int Level = int.Parse(ParsedSkill[1]);
                int Experience = int.Parse(ParsedSkill[2]);

                Skills.Add(new Skill()
                {
                    Name = Name,
                    Rank = Rank,
                    Level = Level,
                    Experience = Experience
                });

                skillIndex++;
            }

            return Skills;
        }

        private List<Minigame> ParseMinigames(string[] MinigameResults)
        {
            List<Minigame> Minigames = new List<Minigame>();

            int minigameIndex = 0;

            foreach (string Minigame in MinigameResults)
            {
                string[] ParsedSkill = Minigame.Split(',');

                string Name = HighscoreMinigames[minigameIndex];
                int Rank = int.Parse(ParsedSkill[0]);
                int Number = int.Parse(ParsedSkill[1]);

                Minigames.Add(new Minigame()
                {
                    Name = Name,
                    Rank = Rank,
                    Number = Number,
                });

                minigameIndex++;
            }

            return Minigames;
        }

        private string BuildHighscoresUrl(string Username, string AccountType)
        {
            return string.Format(HighscoreUrl, AccountType, Username);
        }
    }
}
