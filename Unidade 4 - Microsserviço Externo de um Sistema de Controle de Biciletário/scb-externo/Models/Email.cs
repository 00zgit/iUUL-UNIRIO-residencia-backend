using Newtonsoft.Json;
using scb_externo.Data;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace scb_externo.Models
{
    public class Email : ObjetoSalvavel
    {
        [Key]
        [Required]
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [Required]
        [JsonPropertyName("email")]
        public string Endereco { get; set; }
        [Required]
        [JsonPropertyName("mensagem")]
        public string Mensagem { get; set; }
        [Required]
        [JsonPropertyName("assunto")]
        public string Assunto { get; set; }

        public Email() { }
    }
}