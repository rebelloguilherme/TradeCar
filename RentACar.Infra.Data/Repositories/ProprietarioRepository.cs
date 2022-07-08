using Microsoft.EntityFrameworkCore;
using RentACar.Domain.Entities;
using RentACar.Domain.Interfaces;
using RentACar.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentACar.Infra.Data.Repositories
{
    public class ProprietarioRepository : IProprietarioRepository
    {
        private ApplicationDbContext _proprietarioContext;

        public ProprietarioRepository(ApplicationDbContext proprietarioContext)
        {
            _proprietarioContext = proprietarioContext;
        }

        public async Task<Proprietario> CreateAsync(Proprietario proprietario)
        {
            try
            {
                _proprietarioContext.Add(proprietario);
                await _proprietarioContext.SaveChangesAsync();
                return proprietario;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public async Task<Proprietario> GetByIdAsync(Guid id)
        {
            try
            {
                return await _proprietarioContext.Proprietarios.FindAsync(id);
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public async Task<IEnumerable<Proprietario>> GetProprietariosAsync()
        {
            try
            {
                return await _proprietarioContext.Proprietarios.ToListAsync();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public async Task<Proprietario> RemoveAsync(Proprietario proprietario)
        {
            try
            {
                _proprietarioContext.Remove(proprietario);
                await _proprietarioContext.SaveChangesAsync();
                return proprietario;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public async Task<Proprietario> UpdateAsync(Proprietario proprietario)
        {
            try
            {
                _proprietarioContext.Update(proprietario);
                await _proprietarioContext.SaveChangesAsync();
                return proprietario;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }
    }
}
