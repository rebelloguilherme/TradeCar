using RentACar.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentACar.Application.Interfaces
{
    public interface IMarcaService
    {
        Task<IEnumerable<MarcaDTO>> GetMarcas();
        Task<MarcaDTO> GetById(Guid id);
        Task Add(MarcaDTO marcaDTO);
        Task Update(MarcaDTO marcaDTO);
        Task Remove(Guid id);
    }
}
