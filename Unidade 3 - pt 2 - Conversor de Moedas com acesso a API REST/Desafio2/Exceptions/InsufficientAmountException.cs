using System.Runtime.Serialization;

namespace CurrencyExchangeAPI_RESTful.Exceptions
{
    [Serializable]
    internal class InsufficientAmountException : MyCurrencyExchangeAPIException
    {
        public InsufficientAmountException()
        {
        }

        public InsufficientAmountException(string? message) : base(message)
        {
        }

        public InsufficientAmountException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InsufficientAmountException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}