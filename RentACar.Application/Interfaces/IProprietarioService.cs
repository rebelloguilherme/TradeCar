using RentACar.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentACar.Application.Interfaces
{
    public interface IProprietarioService
    {
        Task<IEnumerable<ProprietarioDTO>> GetProprietarios();
        Task<ProprietarioDTO> GetById(Guid id);
        Task Add(ProprietarioDTO proprietarioDTO);
        Task Update(ProprietarioDTO proprietarioDTO);
        Task Remove(Guid id);
    }
}
