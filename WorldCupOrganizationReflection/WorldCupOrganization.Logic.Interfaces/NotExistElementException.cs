using System;
using System.Runtime.Serialization;

namespace WorldCupOrganization.Logic.Interfaces
{
    [Serializable]
    public class NotExistElementException : Exception
    {
        public NotExistElementException()
        {
        }

        public NotExistElementException(string message) : base(message)
        {
        }

        public NotExistElementException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotExistElementException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}