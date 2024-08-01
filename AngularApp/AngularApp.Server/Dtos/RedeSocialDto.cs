using AngularApp.Server.Models;
using System.Text.Json.Serialization;

namespace AngularApp.Server.Dtos
{
    public class RedeSocialDto
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string URl { get; set; }
        public int? EventoId { get; set; }
        public EventoDto Evento { get; set; }
        public int? PalestranteId { get; set; }
        public PalestranteDto palestrante { get; set; }
    }
}
