using Core.Enums;
using Core.Exceptions;
using System;

namespace Core.Helpers
{
    public static class SkillHelpers
    {
        public static bool validateSkillName(string skillName)
        {
            if (Enum.IsDefined(typeof(Skills), skillName))
            {
                return true;
            }

            throw new InvalidSkillNameException(String.Format("Skill name, {0}, is invalid.", skillName));
        }

    }
}
