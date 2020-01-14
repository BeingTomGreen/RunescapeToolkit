using Core.Models;
using Core.Enums;

namespace Core.Extensions
{
    public static class SkillExtensions
    {
        public static bool IsMax(this PlayerSkill skill)
        {
            if ((skill.Skill == SkillType.Overall && skill.Level == 2277) || skill.Level == 99)
            {
                return true;
            }

            return false;

        }

    }
}
