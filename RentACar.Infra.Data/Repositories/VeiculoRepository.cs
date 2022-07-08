using Microsoft.EntityFrameworkCore;
using RentACar.Domain.Entities;
using RentACar.Domain.Interfaces;
using RentACar.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentACar.Infra.Data.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private ApplicationDbContext _veiculoContext;

        public VeiculoRepository(ApplicationDbContext veiculoContext)
        {
            _veiculoContext = veiculoContext;
        }

        public async Task<Veiculo> CreateAsync(Veiculo veiculo)
        {
            try
            {
                _veiculoContext.Add(veiculo);
                await _veiculoContext.SaveChangesAsync();
                return veiculo;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public async Task<Veiculo> GetByIdAsync(Guid id)
        {
            try
            {
                return await _veiculoContext.Veiculos.FindAsync(id);
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public async Task<Veiculo> GetVeiculoMarcaAsync(Guid id)
        {
            try
            {
                return await _veiculoContext.Veiculos.Include(m => m.Marca)
                    .SingleOrDefaultAsync(v => v.Id == id);
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public async Task<Veiculo> GetVeiculoProprietario(Guid id)
        {
            try
            {
                return await _veiculoContext.Veiculos.Include(p => p.Proprietario)
                    .SingleOrDefaultAsync(v => v.Id == id);
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public async Task<IEnumerable<Veiculo>> GetVeiculoAsync()
        {
            try
            {
                return await _veiculoContext.Veiculos.ToListAsync();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public async Task<Veiculo> RemoveAsync(Veiculo veiculo)
        {
            try
            {
                _veiculoContext.Remove(veiculo);
                await _veiculoContext.SaveChangesAsync();
                return veiculo;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public async Task<Veiculo> UpdateAsync(Veiculo veiculo)
        {
            try
            {
                _veiculoContext.Update(veiculo);
                await _veiculoContext.SaveChangesAsync();
                return veiculo;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }
    }
}
