using AngularApp.Server.Business.Interface;
using AngularApp.Server.Business.Service;
using AngularApp.Server.Data;
using AngularApp.Server.Dtos;
using AngularApp.Server.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AngularApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly IEventoService _eventoService;
        private readonly IWebHostEnvironment _hostEnvironment;

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

        public EventoController(IEventoService eventoService, IWebHostEnvironment hostEnvironment)
        {
            this._eventoService = eventoService;
            this._hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var eventos = await _eventoService.GetAllEventosAsync(true);
                if (eventos == null) return NoContent();

                return Ok(eventos);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar Eventos. Error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var evento = await _eventoService.GetEventosById(id, true);
                if (evento == null) return NoContent();
                return Ok(evento);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar Eventos. Error: {ex.Message}");
            }
        }

        [HttpGet("{tema}/tema")]
        public async Task<IActionResult> GetByTema(string tema)
        {
            try
            {
                var evento = await _eventoService.GetAllEventosByTemaAsync(tema, true);
                if (evento == null) return NoContent();

                return Ok(evento);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar Eventos. Error: {ex.Message}");
            }
        }


        [HttpPost("upload-image/{eventoId}")]
        public async Task<IActionResult> UploadImage(int eventoId)
        {
            try
            {
                var evento = await _eventoService.GetEventosById(eventoId, true);
                if (evento == null) return BadRequest("Erro ao tentar adicionar evento.");

                var file = Request.Form.Files[0];

                if (file.Length > 0)
                {
                    DeletarImagem(evento.ImagemURL);
                    evento.ImagemURL = await SalvarImagem(file);
                }

                var eventoRetorno = await _eventoService.UpdateEvento(eventoId, evento);

                return Ok(evento);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar Eventos. Error: {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(EventoDto model)
        {
            try
            {
                var evento = await _eventoService.AddEvento(model);
                if (evento == null) return BadRequest("Erro ao tentar adicionar evento.");

                return Ok(evento);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar Eventos. Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarEvento(int id, EventoDto model)
        {
            try
            {

                //var eventos = await _eventoService.GetEventosById(id, false);

                var evento = await _eventoService.UpdateEvento(id, model);

                //var evento = await service.UpdateEvento(eventos.Id, eventos);
                if (evento == null) return BadRequest("Erro ao tentar atualizar evento.");

                return Ok(evento);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar Eventos. Error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvento(int id)
        {
            try
            {
                return await _eventoService.DeleteEvento(id) ? Ok(new { mensagem = "Evento deletado" }) : throw new Exception("Erro ao tentar deletar evento.");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar Eventos. Error: {ex.Message}");
            }
        }

        [NonAction]
        private void DeletarImagem(string imagemURL)
        {
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, @"Resources/images", imagemURL);
            if (System.IO.File.Exists(imagePath)) System.IO.File.Delete(imagePath);
        }

        [NonAction]
        private async Task<string> SalvarImagem(IFormFile imagemURL)
        {

            var imageName = new string(Path.GetFileNameWithoutExtension(imagemURL.FileName).Take(10).ToArray()).Replace(" ", "-");

            imageName = $"{imageName}{DateTime.UtcNow.ToString("yymmssfff")}{Path.GetExtension(imagemURL.FileName)}";

            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, @"Resources/images", imageName);

            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imagemURL.CopyToAsync(fileStream);
            }

            return imageName;
        }
    }
}
