using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentACar.Domain.Interfaces
{
    public interface IProprietarioRepository
    {
        Task<IEnumerable<Proprietario>> GetProprietariosAsync();
        Task<Proprietario> GetByIdAsync(Guid id);
        Task<Proprietario> CreateAsync(Proprietario proprietario);
        Task<Proprietario> UpdateAsync(Proprietario proprietario);
        Task<Proprietario> RemoveAsync(Proprietario proprietario);
    }
}
