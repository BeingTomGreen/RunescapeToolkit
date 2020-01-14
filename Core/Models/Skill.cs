using Core.Exceptions;
using Core.Helpers;

namespace Core.Models
{
    public class Skill
    {
        public const long MAX_TOTAL_EXPERIENCE = 4400000000;

        public Skill(string name, int rank, int level, int experience)
        {
            this.Name = name;
            this.Rank = rank;
            this.Level = level;
            this.Experience = experience;
        }

        private string _name;

        public string Name {
            get
            {
                return this._name;
            }

            private set
            {
                if (SkillHelpers.ValidateSkillName(value) == false)
                {
                    throw new InvalidSkillNameException($"Skill name, {value}, is invalid.");
                }

                this._name = value;
            }
        }

        public int Level { get; private set; }

        public int Experience { get; private set; }
        
        public int Rank { get; private set; }

    }
}
