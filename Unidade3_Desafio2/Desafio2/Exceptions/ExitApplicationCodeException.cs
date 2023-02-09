using System.Runtime.Serialization;

namespace CurrencyExchangeAPI_RESTful.Exceptions
{
    [Serializable]
    internal class ExitApplicationCodeException : Exception
    {
        public ExitApplicationCodeException()
        {
        }

        public ExitApplicationCodeException(string? message) : base(message)
        {
        }

        public ExitApplicationCodeException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ExitApplicationCodeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}