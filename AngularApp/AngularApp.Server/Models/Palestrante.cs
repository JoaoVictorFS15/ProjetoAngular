using System.Collections;
using System.Collections.Generic;

namespace AngularApp.Server.Models
{
    public class Palestrante
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string MiniCurriculo { get; set; }
        public string ImagemURL { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public IEnumerable<RedeSocial> RedesSocials { get; set; }
        public IEnumerable<PalestranteEvento> PalestranteEvento { get; set; }

    }
}