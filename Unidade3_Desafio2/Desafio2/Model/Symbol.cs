using System.Text.Json.Serialization;

namespace CurrencyExchangeAPI_RESTful.Model
{
    public record class Symbol(
        [property: JsonPropertyName("code")] string Code);
}
