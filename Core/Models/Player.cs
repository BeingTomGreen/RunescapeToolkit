using System;
using System.Collections.Generic;
using System.Linq;
using Core.Enums;
using Core.Helpers;
using Core.Models;

namespace Core.Models
{
    public class Player
    {
        public string Username { get; private set; }

        public AccountType AccountType { get; private set; }

        public List<Skill> Skills { get; private set; }

        public List<Activity> Activities{ get; private set; }

        public Player(string username, AccountType accountType, List<Skill> skills, List<Activity> activities)
        {
            this.Username = PlayerHelpers.CleanUsername(username);
            this.AccountType = accountType;
            this.Skills = skills;
            this.Activities = activities;
        }

    }
}
