using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AngularApp.Server.Models
{
    public class Evento
    {
        public int Id { get; set; }  
        public string Local { get; set; }
        public DateTime? DataEvento { get; set; }
        public string Tema { get; set; }
        public int QTDPesssoas { get; set; }
        public string ImagemURL { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public IEnumerable<Lote> Lote { get; set; }
        public IEnumerable<RedeSocial> RedeSocials { get; set; }
        public IEnumerable<PalestranteEvento> PalestranteEvento { get; set; }


    }
}
