using System;
using System.Runtime.Serialization;

namespace Core.Exceptions
{
    [Serializable()]
    public class InvalidActivityTypeException : Exception
    {
        public InvalidActivityTypeException() { }

        public InvalidActivityTypeException(string message) : base(message) { }

        public InvalidActivityTypeException(string message, Exception innerException) : base(message, innerException) { }

        protected InvalidActivityTypeException(SerializationInfo info, StreamingContext context) : base(info, context) { }

    }
}