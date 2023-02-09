using System.Runtime.Serialization;

namespace CurrencyExchangeAPI_RESTful.Exceptions
{
    [Serializable]
    internal class SameCurrencyException : MyCurrencyExchangeAPIException
    {
        public SameCurrencyException()
        {
        }

        public SameCurrencyException(string? message) : base(message)
        {
        }

        public SameCurrencyException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected SameCurrencyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}