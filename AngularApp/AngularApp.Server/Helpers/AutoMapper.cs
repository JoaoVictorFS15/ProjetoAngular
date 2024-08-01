using AngularApp.Server.Dtos;
using AngularApp.Server.Models;
using AutoMapper;

namespace AngularApp.Server.Helpers
{
    public class AutoMapper : Profile
    {
        public AutoMapper() {

            CreateMap<Evento, EventoDto>().ReverseMap();
            CreateMap<Lote, LoteDto>().ReverseMap();
            CreateMap<RedeSocial, RedeSocialDto>().ReverseMap();
            CreateMap<PalestranteEvento, PalestranteEventoDto>().ReverseMap();
        }
    }
}
