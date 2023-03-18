using System.Text.Json.Serialization;

public record class Conversion(
    [property: JsonPropertyName("result")] string Result);