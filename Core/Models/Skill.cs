using Core.Enums;
using Core.Exceptions;
using Core.Helpers;
using System;

namespace Core.Models
{
    public class Skill
    {
        public const int MAX_TOTAL_LEVEL = 2277;
        public const long MAX_TOTAL_EXPERIENCE = 4400000000;

        public string Name { get; private set; }

        public int Level { get; private set; }

        public int Experience { get; private set; }
        
        public bool IsMax
        {
            get
            {
                if ((this.Name == "Overall" && this.Level == MAX_TOTAL_LEVEL) || this.Level == 99)
                {
                    return true;
                }

                return false;
            }
        }

        public Skill(string name, int rank, int level, int experience)
        {
            this.Name = checkSkillName(name);
            this.Rank = rank;
            this.Level = level;
            this.Experience = experience;
        }

        private string checkSkillName(string name)
        {
            if (SkillHelpers.ValidateSkillName(name))
                return name;

            throw new InvalidSkillNameException(String.Format("Skill name, {0}, is invalid.", name));
        }

        private int _rank;

        public int Rank
        {
            get
            {
                if (_rank < 0)
                    return 0;

                return _rank;
            }
            private set { _rank = value; }
        }
        
    }
}
