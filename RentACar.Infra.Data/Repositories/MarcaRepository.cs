using Microsoft.EntityFrameworkCore;
using RentACar.Domain.Entities;
using RentACar.Domain.Interfaces;
using RentACar.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentACar.Infra.Data.Repositories
{
    public class MarcaRepository : IMarcaRepository
    {
        private ApplicationDbContext _marcaContext;

        public MarcaRepository(ApplicationDbContext marcaContext)
        {
            _marcaContext = marcaContext;
        }

        public async Task<Marca> CreateAsync(Marca marca)
        {
            try
            {
                _marcaContext.Add(marca);
                await _marcaContext.SaveChangesAsync();
                return marca;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public async Task<Marca> GetByIdAsync(Guid id)
        {
            try
            {
                return await _marcaContext.Marcas.FindAsync(id);
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public async Task<IEnumerable<Marca>> GetMarcasAsync()
        {
            try
            {
                return await _marcaContext.Marcas.ToListAsync();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public async Task<Marca> RemoveAsync(Marca marca)
        {
            try
            {
                _marcaContext.Remove(marca);
                await _marcaContext.SaveChangesAsync();
                return marca;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public async Task<Marca> UpdateAsync(Marca marca)
        {
            try
            {
                _marcaContext.Update(marca);
                await _marcaContext.SaveChangesAsync();
                return marca;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }
    }
}
