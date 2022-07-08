using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentACar.Domain.Interfaces
{
    public interface IMarcaRepository
    {
        Task<IEnumerable<Marca>> GetMarcasAsync();
        Task<Marca> GetByIdAsync(Guid id);
        Task<Marca> CreateAsync(Marca marca);
        Task<Marca> UpdateAsync(Marca marca);
        Task<Marca> RemoveAsync(Marca marca);
    }
}
