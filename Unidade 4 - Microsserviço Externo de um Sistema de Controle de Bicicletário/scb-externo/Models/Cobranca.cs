using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using scb_externo.Data;
using scb_externo.Extensions;
using scb_externo.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace scb_externo.Models
{
    public class Cobranca : ObjetoSalvavel
    {
        [Key]
        [Required]
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [Required]
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [Required]
        [JsonPropertyName("horaSolicitacao")]
        public DateTime HoraSolicitacao { get; set; }
        [Required]
        [JsonPropertyName("horaFinalizacao")]
        public DateTime HoraFinalizacao { get; set; }
        [Required]
        [JsonPropertyName("valor")]
        public double Valor { get; set; }
        [Required]
        [JsonPropertyName("ciclista")]
        public int IdCiclista { get; set; }

        public Cobranca() { }
    }
}
