using AutoMapper;
using RentACar.Application.DTOs;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entities;
using RentACar.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Services
{
    public class ProprietarioService : IProprietarioService
    {
        private IMapper _mapper;
        private IProprietarioRepository _proprietarioRepository;

        public ProprietarioService(IMapper mapper, IProprietarioRepository proprietarioRepository)
        {
            _mapper = mapper;
            _proprietarioRepository = proprietarioRepository;
        }

        public async Task Add(ProprietarioDTO proprietarioDTO)
        {
            var proprietarioEntity = _mapper.Map<Proprietario>(proprietarioDTO);
            await _proprietarioRepository.CreateAsync(proprietarioEntity);
        }

        public async Task<ProprietarioDTO> GetById(Guid id)
        {
            var proprietarioEntity = await _proprietarioRepository.GetByIdAsync(id);
            return _mapper.Map<ProprietarioDTO>(proprietarioEntity);
        }

        public async Task<IEnumerable<ProprietarioDTO>> GetProprietarios()
        {
            var proprietarioEntity = await _proprietarioRepository.GetProprietariosAsync();
            return _mapper.Map<IEnumerable<ProprietarioDTO>>(proprietarioEntity);
        }

        public async Task Remove(Guid id)
        {
            var proprietarioEntity = _proprietarioRepository.GetByIdAsync(id).Result;
            await _proprietarioRepository.RemoveAsync(proprietarioEntity);
        }

        public async Task Update(ProprietarioDTO proprietarioDTO)
        {
            var proprietarioEntity = _mapper.Map<Proprietario>(proprietarioDTO);
            await _proprietarioRepository.UpdateAsync(proprietarioEntity);
        }
    }
}
