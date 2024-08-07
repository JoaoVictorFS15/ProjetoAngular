using AngularApp.Server.Models.Identity;
using System.Collections;
using System.Collections.Generic;

namespace AngularApp.Server.Models
{
    public class Palestrante
    {
      
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string MiniCurriculo { get; set; }
        public IEnumerable<RedeSocial> RedesSocials { get; set; }
        public IEnumerable<PalestranteEvento> PalestranteEvento { get; set; }

    }
}