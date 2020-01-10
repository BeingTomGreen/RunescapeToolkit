using System;
using System.Collections.Generic;
using System.Linq;
using RunescapeConsole.Enums;

namespace RunescapeConsole.Models
{
    class Player
    {
        private string username;

        public string Username
        {
            get { return username; }

            set {
                username = CleanUsername(value);
            }
        }

        public AccountType AccountType { get; set; }

        public List<Skill> Skills { get; set; }

        public List<Activity> Activities{ get; set; }

        public Player()
        {

        }

        public static string CleanUsername(string username)
        {
            string cleanUsername = new string(username.Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) || c == '-' || c == '_').ToArray());

            cleanUsername = cleanUsername.Replace(" ", "_");

            return cleanUsername;
        }
    }
}
