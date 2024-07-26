using CursoAngular.Data;
using CursoAngular.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoAngular.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly context _context;

        //public IEnumerable<Evento> Eventos = new List<Evento>() {

        //    new Evento
        //    {
        //        EventoID = 1,
        //        Local = "teste",
        //        DataEvento = DateTime.Now.ToString(),
        //        Tema = "teste",
        //        Lote = "1º lote",
        //        ImagemURL = "image/teste.png",
        //        QTDPesssoas = 30

        //    },

        //    new Evento
        //    {
        //        EventoID = 2,
        //        Local = "teste2",
        //        DataEvento = DateTime.Now.AddDays(5).ToString(),
        //        Tema = "teste2",
        //        Lote = "2º lote",
        //        ImagemURL = "image/teste2.png",
        //        QTDPesssoas = 50

        //    }
        //};

        public EventoController(context context)
        {
            this._context = context;
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _context.Eventos;
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id)
        {
            return _context.Eventos.Where(x => x. EventoID== id);
        }
    }
}
