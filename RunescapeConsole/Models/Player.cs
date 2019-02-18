using System.Collections.Generic;
using System.Linq;

namespace RunescapeConsole.Models
{
    class Player
    {
        public string Username { get; private set; }

        public string AccountType { get; private set; }

        public List<Skill> Skills { get; set; } //= new List<Skill>()

        public List<Minigame> Minigames { get; set; } //= new List<Minigame>();

        public Player(string aUsername, int aAccountType = 0)
        {
            Username = CleanUsername(aUsername);

            AccountType = GetAccountTypeString(aAccountType);
        }

        public string GetAccountTypeString(int AccountType)
        {
            string AccountTypeString = "";

            switch (AccountType)
            {
                case 0:
                    AccountTypeString = "normal";
                    break;
                case 1:
                    AccountTypeString = "ironman";
                    break;
                case 2:
                    AccountTypeString = "ultimate";
                    break;
                case 3:
                    AccountTypeString = "hardcore";
                    break;
                case 4:
                    AccountTypeString = "deadman";
                    break;
                case 5:
                    AccountTypeString = "seasonal";
                    break;
                default:
                    AccountTypeString = "normal";
                    break;
            }

            return AccountTypeString;
        }

        private string CleanUsername(string Username)
        {
            string CleanUsername = new string(Username.Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) || c == '-' || c == '_').ToArray());

            CleanUsername = CleanUsername.Replace(" ", "_");

            return CleanUsername;
        }
    }
}
