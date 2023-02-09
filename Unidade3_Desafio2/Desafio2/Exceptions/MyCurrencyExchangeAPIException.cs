using System.Runtime.Serialization;

namespace CurrencyExchangeAPI_RESTful.Exceptions
{
    [Serializable]
    internal class MyCurrencyExchangeAPIException : Exception
    {
        public MyCurrencyExchangeAPIException()
        {
        }

        public MyCurrencyExchangeAPIException(string? message) : base(message)
        {
        }

        public MyCurrencyExchangeAPIException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected MyCurrencyExchangeAPIException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}