using System.Text.Json.Serialization;

namespace AngularApp.Server.Models
{
    public class RedeSocial
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; } 
        public string Nome { get; set; }
        public string URl { get; set; }
        public int? EventoId { get; set; }
        public Evento Evento { get; set; }
        public int? PalestranteId { get; set; }
        public Palestrante palestrante { get; set; }
    }
}