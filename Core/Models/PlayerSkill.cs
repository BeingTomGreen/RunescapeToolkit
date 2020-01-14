using Core.Enums;

namespace Core.Models
{
    public class PlayerSkill
    {
        public PlayerSkill(SkillType skill, int rank, int level, int experience)
        {
            this.Skill = skill;
            this.Rank = rank;
            this.Level = level;
            this.Experience = experience;
        }

        public SkillType Skill { get; private set; }

        public int Level { get; private set; }

        public int Experience { get; private set; }
        
        public int Rank { get; private set; }

    }
}
