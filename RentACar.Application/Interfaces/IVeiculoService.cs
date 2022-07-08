using RentACar.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentACar.Application.Interfaces
{
    public interface IVeiculoService
    {
        Task<IEnumerable<VeiculoDTO>> GetVeiculos();
        Task<VeiculoDTO> GetById(Guid id);
        Task Add(VeiculoDTO veiculoDTO);
        Task Update(VeiculoDTO veiculoDTO);
        Task Remove(Guid id);
    }
}
