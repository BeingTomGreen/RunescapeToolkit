using System;
using System.Runtime.Serialization;

namespace Core.Exceptions
{
    [Serializable()]
    public class InvalidSkillNameException : Exception
    {
        public InvalidSkillNameException() { }

        public InvalidSkillNameException(string message) : base(message) { }

        public InvalidSkillNameException(string message, Exception innerException) : base(message, innerException) { }

        protected InvalidSkillNameException(SerializationInfo info, StreamingContext context) : base(info, context) { }

    }
}