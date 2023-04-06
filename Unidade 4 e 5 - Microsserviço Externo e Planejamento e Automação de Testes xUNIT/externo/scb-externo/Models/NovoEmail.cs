using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace scb_externo.Models
{
    public class NovoEmail
    {
        [Required]
        [JsonPropertyName("email")]
        public string Endereco { get; set; }
        [Required]
        [JsonPropertyName("mensagem")]
        public string Mensagem { get; set; }
        [Required]
        [JsonPropertyName("assunto")]
        public string Assunto { get; set; }


        public NovoEmail() { }
    }
}