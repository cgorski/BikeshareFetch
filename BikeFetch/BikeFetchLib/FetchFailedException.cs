using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BikeFetchLib
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
