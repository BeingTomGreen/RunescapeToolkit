using Core.Enums;
using Core.Exceptions;
using System;

namespace Core.Helpers
{
    public static class SkillHelpers
    {
        public static bool ValidateSkillName(string skillName)
        {
            if (Enum.IsDefined(typeof(Skills), skillName))
                return true;

            return false;
        }

        public static bool (string skillName)
        {
            if (Enum.IsDefined(typeof(Skills), skillName))
                return true;

            return false;
        }

    }
}
