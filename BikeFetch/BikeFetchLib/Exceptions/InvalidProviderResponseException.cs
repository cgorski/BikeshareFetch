using System;
using System.Runtime.Serialization;

namespace BikeFetchLib.Exceptions
{
    [Serializable]
    public class InvalidProviderResponseException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public InvalidProviderResponseException()
        {
        }

        public InvalidProviderResponseException(string message) : base(message)
        {
        }

        public InvalidProviderResponseException(string message, Exception inner) : base(message, inner)
        {
        }

        protected InvalidProviderResponseException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}