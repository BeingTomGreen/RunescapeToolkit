using Core.Enums;

namespace Core.Models
{
    public class PlayerSkill
    {
        public PlayerSkill(SkillType skill, int rank, int level, long experience)
        {
            this.SkillType = skill;
            this.Rank = rank;
            this.Level = level;
            this.Experience = experience;
        }

        public SkillType SkillType { get; private set; }

        public int Level { get; private set; }

        public long Experience { get; private set; }
        
        public int Rank { get; private set; }

    }
}
