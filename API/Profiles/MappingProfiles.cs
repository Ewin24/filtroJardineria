using API.Dtos;
using AutoMapper;
using Persistence.Entities;

namespace API.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<Pedido, PedidoDto>().ReverseMap();
        }
    }
}