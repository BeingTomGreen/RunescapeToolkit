using System;

namespace Core.Exceptions
{
    [Serializable]
    public class InvalidSkillNameException : Exception
    {
        public InvalidSkillNameException(string message) : base(message) { }

    }
}
