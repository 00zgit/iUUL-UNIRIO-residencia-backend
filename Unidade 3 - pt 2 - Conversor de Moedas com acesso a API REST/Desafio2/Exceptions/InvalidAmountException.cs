using System.Runtime.Serialization;

namespace CurrencyExchangeAPI_RESTful.Exceptions
{
    [Serializable]
    internal class InvalidAmountException : MyCurrencyExchangeAPIException
    {
        public InvalidAmountException()
        {
        }

        public InvalidAmountException(string? message) : base(message)
        {
        }

        public InvalidAmountException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidAmountException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}