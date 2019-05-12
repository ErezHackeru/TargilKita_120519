using System;
using System.Runtime.Serialization;

namespace FileManager
{
    [Serializable]
    internal class InfectedFileDetectedException : Exception
    {
        public InfectedFileDetectedException(string message, string filepath) : base(message)
        {
        }

        public InfectedFileDetectedException(string message) : base(message)
        {
        }

        public InfectedFileDetectedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InfectedFileDetectedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}