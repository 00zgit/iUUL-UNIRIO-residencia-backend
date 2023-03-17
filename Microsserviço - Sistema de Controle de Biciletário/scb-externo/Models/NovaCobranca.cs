using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace scb_externo.Models
{
    public class NovaCobranca
    {
        [Required]
        [JsonPropertyName("valor")]
        public double Valor { get; set; }
        [Required]
        [JsonPropertyName("ciclista")]
        public int IdCiclista { get; set; }

        public NovaCobranca() { }
    }
}
