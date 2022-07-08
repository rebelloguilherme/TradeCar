using AutoMapper;
using RentACar.Application.DTOs;
using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Proprietario,ProprietarioDTO>().ReverseMap();
            CreateMap<Veiculo,VeiculoDTO>().ReverseMap();
            CreateMap<Marca, MarcaDTO>().ReverseMap();
        }
    }
}
