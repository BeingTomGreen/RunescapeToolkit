using Core.Enums;

namespace Core.Models
{
    public class Skill
    {
        public SkillName SkillName { get; private set; }

        public int Level { get; private set; }

        public long Experience { get; private set; }

        public int Rank { get; private set; }

        public Skill(SkillName skillName, int rank, int level, long experience)
        {
            SkillName = skillName;
            Rank = rank;
            Level = level;
            Experience = experience;
        }

    }
}
