using Core.Enums;
using Core.Helpers;

namespace Core.Models
{
    public class Skill
    {
        public const int MAX_TOTAL_LEVEL = 2277;

        public string Name { get; private set; }

        private int rank;

        public int Rank
        {
            get
            {
                if (rank < 0)
                    return 0;

                return rank;
            }
            private set { rank = value; }
        }

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
            this.Name = name;
            this.Rank = rank;
            this.Level = level;
            this.Experience = experience;
        }

    }
}
