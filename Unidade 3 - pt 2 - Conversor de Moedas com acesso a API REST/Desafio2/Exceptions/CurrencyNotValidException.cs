using System.Runtime.Serialization;

namespace CurrencyExchangeAPI_RESTful.Exceptions
{
    [Serializable]
    internal class CurrencyNotValidException : MyCurrencyExchangeAPIException
    {
        public CurrencyNotValidException()
        {
        }

        public CurrencyNotValidException(string? message) : base(message)
        {
        }

        public CurrencyNotValidException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CurrencyNotValidException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}