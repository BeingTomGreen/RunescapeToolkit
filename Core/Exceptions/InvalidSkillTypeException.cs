using System;
using System.Runtime.Serialization;

namespace Core.Exceptions
{
    [Serializable()]
    public class InvalidSkillTypeException : Exception
    {
        public InvalidSkillTypeException() { }

        public InvalidSkillTypeException(string message) : base(message) { }

        public InvalidSkillTypeException(string message, Exception innerException) : base(message, innerException) { }

        protected InvalidSkillTypeException(SerializationInfo info, StreamingContext context) : base(info, context) { }

    }
}