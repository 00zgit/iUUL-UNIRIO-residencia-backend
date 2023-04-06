using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using scb_externo.Data;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace scb_externo.Models
{
    public class Erro : ObjetoSalvavel
    {
        [Key]
        [Required]
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [Required]
        [JsonPropertyName("codigo")]
        public string Codigo { get; set; }
        [Required]
        [JsonPropertyName("mensagem")]
        public string Mensagem { get; set; }

        public Erro() { }
    }
}
