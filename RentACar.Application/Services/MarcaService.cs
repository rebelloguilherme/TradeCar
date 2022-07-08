using AutoMapper;
using RentACar.Application.DTOs;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entities;
using RentACar.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentACar.Application.Services
{
    public class MarcaService : IMarcaService
    {
        private IMapper _mapper;
        private IMarcaRepository _marcaRepository;

        public MarcaService(IMapper mapper, IMarcaRepository marcaRepository)
        {
            _mapper = mapper;
            _marcaRepository = marcaRepository;
        }

        public async Task Add(MarcaDTO marcaDTO)
        {
            var marcaEntity = _mapper.Map<Marca>(marcaDTO);
            await _marcaRepository.CreateAsync(marcaEntity);
        }

        public async Task<MarcaDTO> GetById(Guid id)
        {
            var marcaEntity = await _marcaRepository.GetByIdAsync(id);
            return _mapper.Map<MarcaDTO>(marcaEntity);
        }

        public async Task<IEnumerable<MarcaDTO>> GetMarcas()
        {
            var marcaEntity = await _marcaRepository.GetMarcasAsync();
            return _mapper.Map<IEnumerable<MarcaDTO>>(marcaEntity);
        }

        public async Task Remove(Guid id)
        {
            var marcaEntity = _marcaRepository.GetByIdAsync(id).Result;
            await _marcaRepository.RemoveAsync(marcaEntity);
        }

        public async Task Update(MarcaDTO marcaDTO)
        {
            var marcaEntity = _mapper.Map<Marca>(marcaDTO);
            await _marcaRepository.UpdateAsync(marcaEntity);
        }
    }
}
