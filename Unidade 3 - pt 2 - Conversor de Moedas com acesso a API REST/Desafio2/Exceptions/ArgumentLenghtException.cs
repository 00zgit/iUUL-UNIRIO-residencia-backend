using System.Runtime.Serialization;

namespace CurrencyExchangeAPI_RESTful.Exceptions
{
    [Serializable]
    internal class ArgumentLenghtException : MyCurrencyExchangeAPIException
    {
        public ArgumentLenghtException()
        {
        }

        public ArgumentLenghtException(string? message) : base(message)
        {
        }

        public ArgumentLenghtException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ArgumentLenghtException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}