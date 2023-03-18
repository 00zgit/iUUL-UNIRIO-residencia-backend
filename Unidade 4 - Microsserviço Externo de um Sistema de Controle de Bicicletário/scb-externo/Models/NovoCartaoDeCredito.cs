using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace scb_externo.Models
{
    public class NovoCartaoDeCredito
    {
        [Required]
        [JsonPropertyName("nomeTitular")]
        public string NomeTitular { get; set; }
        [Required]
        [JsonPropertyName("numero")]
        public string Numero { get; set; }
        [Required]
        [JsonPropertyName("validade")]
        public string Validade { get; set; }
        [Required]
        [JsonPropertyName("cvv")]
        public string Cvv { get; set; }
        [Required]
        [JsonPropertyName("ciclista")]
        public int IdCiclista { get; set; }

        public NovoCartaoDeCredito() { }
    }
}
