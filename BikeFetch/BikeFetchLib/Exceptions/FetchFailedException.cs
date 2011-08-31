using System;
using System.Runtime.Serialization;

namespace BikeFetchLib.Exceptions
{
    [Serializable]
    public class FetchFailedException : Exception
    {
        //


        public FetchFailedException()
        {
        }

        public FetchFailedException(string message) : base(message)
        {
        }

        public FetchFailedException(string message, Exception inner) : base(message, inner)
        {
        }

        protected FetchFailedException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}