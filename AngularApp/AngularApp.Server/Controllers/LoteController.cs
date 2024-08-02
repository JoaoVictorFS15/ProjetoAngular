using AngularApp.Server.Business.Interface;
using AngularApp.Server.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace AngularApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoteController : ControllerBase
    {
        private readonly ILoteService _loteService;
        private readonly IEventoService _eventoService;

        public LoteController(ILoteService loteService, IEventoService eventoService)
        {
            this._loteService = loteService;
            _eventoService = eventoService;
        }

        [HttpGet("{eventoId}")]
        public async Task<IActionResult> Get(int eventoId)
        {
            try
            {
                var eventos = await _eventoService.GetEventosById(eventoId,true);
                if (eventos == null) return NoContent();

                return Ok(eventos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar Eventos. Error: {ex.Message}");
            }
        }

        [HttpPut("{eventoId}")]
        public async Task<IActionResult> AtualizarEvento(int eventoId, EventoDto model)
        {
            try
            {
                var evento = await _eventoService.UpdateEvento(eventoId, model);

                if (evento == null) return BadRequest("Erro ao tentar atualizar evento.");

                return Ok(evento);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar Eventos. Error: {ex.Message}");
            }
        }

        [HttpDelete("{eventoId}/{loteId}")]
        public async Task<IActionResult> DeleteEvento(int eventoId, int loteId)
        {
            try
            {
                return await _eventoService.DeleteEvento(eventoId) ? Ok(new { mensagem = "Evento deletado" }) : throw new Exception("Erro ao tentar deletar evento.");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar Eventos. Error: {ex.Message}");
            }
        }

    }
}
