using System.Collections.Generic;
using Core.Enums;
using Core.Helpers;

namespace Core.Models
{
    public class Player
    {
        public string Username { get; private set; }

        public AccountType AccountType { get; private set; }

        public List<PlayerSkill> Skills { get; private set; }

        public List<PlayerActivity> Activities{ get; private set; }

        public Player(string username, AccountType accountType, List<PlayerSkill> skills, List<PlayerActivity> activities)
        {
            this.Username = PlayerHelper.CleanUsername(username);
            this.AccountType = accountType;
            this.Skills = skills;
            this.Activities = activities;
        }

    }
}
