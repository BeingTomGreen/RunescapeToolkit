using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Request
using System.Net;
using System.IO;

namespace OSRSHiscoreData
{
    delegate void Callback(HiscoreData data);

    class Skill
    {
        public Skill()
        {
            Rank = 0;
            Level = 0;
            XP = 0;
        }

        public void Update(int _rank, int _level, int _xp)
        {
            Rank = _rank;
            Level = _level;
            XP = _xp;
        }

        public int XP { get; private set; }
        public int Level { get; private set; }
        public int Rank { get; private set; }
    }

    class Clue
    {
        public Clue()
        {
            Amount = 0;
            Rank = 0;
        }

        public void Update(int _rank, int _amount)
        {
            Rank = _rank;
            Amount = _amount;
        }

        public int Amount { get; private set; }
        public int Rank { get; private set; }
    }

    class Minigame
    {
        public Minigame()
        {
            Score = 0;
            Rank = 0;
        }

        public void Update(int _rank, int _score)
        {
            Rank = _rank;
            Score = _score;
        }

        public int Score { get; private set; }
        public int Rank { get; private set; }
    }

    class HiscoreData
    {
        static string[] SkillStrings = {"Total", "Attack", "Defence", "Strength", "Hitpoints", "Ranged", "Prayer", "Magic", "Cooking",
            "Woodcutting", "Fletching", "Fishing", "Firemaking", "Crafting", "Smithing", "Mining", "Herblore", "Agility",
            "Thieving", "Slayer", "Farming", "Runecraft", "Hunter", "Construction" };
        static string[] ClueStrings = { "ClueEasy", "ClueMedium", "ClueHard", "ClueElite", "ClueMaster", "ClueTotal" };
        static int[] clueOrder = { 24, 25, 29, 31, 32, 26 };
        static string[] MinigameStrings = { "BHRogue", "BHHunter", "LMS" };
        static int[] minigameOrder = { 27, 28, 30 };

        Callback callbackMethod;

        public HiscoreData(Callback callback)
        {
            callbackMethod = callback;
            InitSkills();
        }

        public string PlayerName { get; private set; }

        public Skill Total { get; private set; }
        public Skill Attack { get; private set; }
        public Skill Defence { get; private set; }
        public Skill Strength { get; private set; }
        public Skill Hitpoints { get; private set; }
        public Skill Ranged { get; private set; }
        public Skill Prayer { get; private set; }
        public Skill Magic { get; private set; }
        public Skill Cooking { get; private set; }
        public Skill Woodcutting { get; private set; }
        public Skill Fletching { get; private set; }
        public Skill Fishing { get; private set; }
        public Skill Firemaking { get; private set; }
        public Skill Crafting { get; private set; }
        public Skill Smithing { get; private set; }
        public Skill Mining { get; private set; }
        public Skill Herblore { get; private set; }
        public Skill Agility { get; private set; }
        public Skill Thieving { get; private set; }
        public Skill Slayer { get; private set; }
        public Skill Farming { get; private set; }
        public Skill Runecraft { get; private set; }
        public Skill Hunter { get; private set; }
        public Skill Construction { get; private set; }

        public Clue ClueEasy { get; private set; }
        public Clue ClueMedium { get; private set; }
        public Clue ClueHard { get; private set; }
        public Clue ClueElite { get; private set; }
        public Clue ClueMaster { get; private set; }
        public Clue ClueTotal { get; private set; }

        public Minigame BHRogue { get; private set; }
        public Minigame BHHunter { get; private set; }
        public Minigame LMS { get; private set; }

        public async Task<bool> Lookup(string name)
        {
            PlayerName = name;

            string html = string.Empty;
            string url = "http://services.runescape.com/m=hiscore_oldschool/index_lite.ws?player=" + PlayerName;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    html = reader.ReadToEnd();
                }
            }
            catch (Exception)
            {
                return false;
            }

            UpdateStats(html);
            callbackMethod(this);
            return true;
        }

        public void UpdateCallback(Callback callback)
        {
            callbackMethod = callback;
        }

        private void UpdateStats(string response)
        {
            string[] FullData = response.Split('\n');
            string[] data;

            // Skills
            for (int i = 0; i < SkillStrings.Length; i++)
            {
                data = FullData[i].Split(',');
                (GetType().GetProperty(SkillStrings[i]).GetValue(this, null) as Skill).Update(Int32.Parse(data[0]), Int32.Parse(data[1]), Int32.Parse(data[2]));
            }

            // Clues
            for (int i = 0; i < clueOrder.Length; i++)
            {
                data = FullData[clueOrder[i]].Split(',');
                (GetType().GetProperty(ClueStrings[i]).GetValue(this, null) as Clue).Update(Int32.Parse(data[0]), Int32.Parse(data[1]));
            }

            // Minigames
            for (int i = 0; i < minigameOrder.Length; i++)
            {
                data = FullData[minigameOrder[i]].Split(',');
                (GetType().GetProperty(MinigameStrings[i]).GetValue(this, null) as Minigame).Update(Int32.Parse(data[0]), Int32.Parse(data[1]));
            }
        }

        private void WipeStats()
        {
            // Skills
            for (int i = 0; i < SkillStrings.Length; i++)
            {
                (GetType().GetProperty(SkillStrings[i]).GetValue(this, null) as Skill).Update(0, 0, 0);
            }

            // Clues
            for (int i = 0; i < clueOrder.Length; i++)
            {
                (GetType().GetProperty(ClueStrings[i]).GetValue(this, null) as Clue).Update(0, 0);
            }

            // Minigames
            for (int i = 0; i < minigameOrder.Length; i++)
            {
                (GetType().GetProperty(MinigameStrings[i]).GetValue(this, null) as Minigame).Update(0, 0);
            }
        }

        private void InitSkills()
        {
            Total = new Skill();
            Attack = new Skill();
            Defence = new Skill();
            Strength = new Skill();
            Hitpoints = new Skill();
            Ranged = new Skill();
            Prayer = new Skill();
            Magic = new Skill();
            Cooking = new Skill();
            Woodcutting = new Skill();
            Fletching = new Skill();
            Fishing = new Skill();
            Firemaking = new Skill();
            Crafting = new Skill();
            Smithing = new Skill();
            Mining = new Skill();
            Herblore = new Skill();
            Agility = new Skill();
            Thieving = new Skill();
            Slayer = new Skill();
            Farming = new Skill();
            Runecraft = new Skill();
            Hunter = new Skill();
            Construction = new Skill();

            ClueEasy = new Clue();
            ClueMedium = new Clue();
            ClueHard = new Clue();
            ClueElite = new Clue();
            ClueMaster = new Clue();
            ClueTotal = new Clue();

            BHRogue = new Minigame();
            BHHunter = new Minigame();
            LMS = new Minigame();
        }
    }
}