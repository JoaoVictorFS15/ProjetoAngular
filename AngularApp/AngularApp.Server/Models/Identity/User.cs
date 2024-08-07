using AngularApp.Server.Enum;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace AngularApp.Server.Models.Identity
{
    public class User : IdentityUser<int>
    {
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public Titulo Titulo { get; set; }
        public string Descricao { get; set; }
        public Funcao Funcao { get; set; }
        public string ImagemURL { get; set; }
        public IEnumerable<UserRole> UserRoles { get; set; }
        public IEnumerable<Palestrante> Palestrantes { get;  set; }
    }
}
