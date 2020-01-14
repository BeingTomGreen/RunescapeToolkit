using Core.Models;

namespace Core.Extensions
{
    public static class SkillExtensions
    {
        public static bool IsMax(this Skill skill)
        {
            if ((skill.Name == "Overall" && skill.Level == 2277) || skill.Level == 99)
            {
                return true;
            }

            return false;

        }

    }
}
