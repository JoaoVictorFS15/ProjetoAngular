namespace AngularApp.Server.Models
{
    public class PalestranteEvento
    {
        public int PalestranteId { get; set; }
        public PalestranteDto Palestrante  { get; set; }
        public int EventoId { get; set; }
        public Evento Evento { get; set; }
    }
}
