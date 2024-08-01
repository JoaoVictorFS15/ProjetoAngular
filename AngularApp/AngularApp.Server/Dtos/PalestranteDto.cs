using AngularApp.Server.Models;
using System.Collections.Generic;

namespace AngularApp.Server.Dtos
{
    public class PalestranteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string MiniCurriculo { get; set; }
        public string ImagemURL { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public IEnumerable<RedeSocialDto> RedesSocials { get; set; }
        public IEnumerable<PalestranteEventoDto> PalestranteEvento { get; set; }
    }
}
