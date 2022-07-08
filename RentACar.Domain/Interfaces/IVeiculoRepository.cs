using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentACar.Domain.Interfaces
{
    public interface IVeiculoRepository
    {
        Task<IEnumerable<Veiculo>> GetVeiculoAsync();
        Task<Veiculo> GetByIdAsync(Guid id);
        Task<Veiculo> GetVeiculoMarcaAsync(Guid id);
        Task<Veiculo> GetVeiculoProprietario(Guid id);
        Task<Veiculo> CreateAsync(Veiculo veiculo);
        Task<Veiculo> UpdateAsync(Veiculo veiculo);
        Task<Veiculo> RemoveAsync(Veiculo veiculo);
    }
}
