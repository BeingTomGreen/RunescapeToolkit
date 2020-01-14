using Core.Enums;
using System;

namespace Core.Helpers
{
    public static class SkillHelpers
    {
        public static bool ValidateSkillName(string skillName)
        {
            if (Enum.IsDefined(typeof(SkillName), skillName))
                return true;

            return false;
        }

    }
}
