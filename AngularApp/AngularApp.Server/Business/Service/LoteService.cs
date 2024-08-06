using AngularApp.Server.Business.Interface;
using AngularApp.Server.Dtos;
using AngularApp.Server.Models;
using AngularApp.Server.Repositorio.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApp.Server.Business.Service
{
    public class LoteService : ILoteService
    {

        private readonly IPersitenceRepositorio _persitenceRepositorio;
        private readonly ILoteRepositotio _loteRepositorio;
        private readonly IEventoRepositorio _eventoRepositorio;
        private readonly IMapper _mapper;

        public LoteService(IPersitenceRepositorio persitenceRepositorio, IEventoRepositorio eventoRepositorio, ILoteRepositotio loteRepositorio, IMapper mapper)
        {
            _loteRepositorio = loteRepositorio;
            _persitenceRepositorio = persitenceRepositorio;
            _eventoRepositorio = eventoRepositorio;
            _mapper = mapper;

        }

        public async Task<bool> DeleteEvento(int eventoId, int loteId)
        {
            try
            {
                var lote = await _loteRepositorio.GetLoteByEventoId(eventoId, loteId);
                if (lote == null) throw new Exception("lote não encontrado.");

                _persitenceRepositorio.Delete(lote);

                return await _persitenceRepositorio.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<LoteDto> GetLoteById(int eventoId, int loteId)
        {
            try
            {
                var lote = await _loteRepositorio.GetLoteByEventoId(eventoId, loteId);

                if (lote == null) return null;


                var retorno = _mapper.Map<LoteDto>(lote);
                return retorno;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<LoteDto[]> GetlotesByEventoIdAsync(int eventoId)
        {
            try
            {
                var lote = await _loteRepositorio.GetLotesByEventoIdAsync(eventoId);

                if (lote == null) return null;


                var retorno = _mapper.Map<LoteDto[]>(lote);
                return retorno;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<LoteDto[]> SaveLote(int eventoId, LoteDto[] model)
        {
            try
            {
                // Verifique se o evento existe
                var eventoExistente = await _eventoRepositorio.GetEventosById(eventoId, false);
                if (eventoExistente == null)
                {
                    throw new Exception("Evento não encontrado.");
                }

                var lotesExistentes = await _loteRepositorio.GetLotesByEventoIdAsync(eventoId);

                foreach (var item in model)
                {
                    if (item.Id == 0)
                    {
                        await AddLote(eventoId, item);
                    }
                    else
                    {
                        var lote = lotesExistentes.FirstOrDefault(x => x.Id == item.Id);
                        if (lote != null)
                        {
                            item.EventoId = eventoId;
                            _mapper.Map(item, lote);
                            _persitenceRepositorio.Update<Lote>(lote);
                        }
                    }
                }

                await _persitenceRepositorio.SaveChangesAsync();

                var lotesAtualizados = await _loteRepositorio.GetLotesByEventoIdAsync(eventoId);
                return _mapper.Map<LoteDto[]>(lotesAtualizados);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task AddLote(int eventoId, LoteDto model)
        {
            try
            {
                var lote = _mapper.Map<Lote>(model);
                lote.EventoId = eventoId;

                _persitenceRepositorio.Add(lote);

                await _persitenceRepositorio.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}
