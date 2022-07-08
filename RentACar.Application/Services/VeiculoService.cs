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
    public class VeiculoService : IVeiculoService
    {
        private IMapper _mapper;
        private IVeiculoRepository _veiculoRepository;

        public VeiculoService(IMapper mapper, IVeiculoRepository veiculoRepository)
        {
            _mapper = mapper;
            _veiculoRepository = veiculoRepository;
        }

        public async Task Add(VeiculoDTO veiculoDTO)
        {
            var veiculoEntity = _mapper.Map<Veiculo>(veiculoDTO);
            await _veiculoRepository.CreateAsync(veiculoEntity);
        }

        public async Task<VeiculoDTO> GetById(Guid id)
        {
            var veiculoEntity = await _veiculoRepository.GetByIdAsync(id);
            return _mapper.Map<VeiculoDTO>(veiculoEntity);
        }

        public async Task<IEnumerable<VeiculoDTO>> GetVeiculos()
        {
            var veiculoEntity = await _veiculoRepository.GetVeiculoAsync();
            return _mapper.Map<IEnumerable<VeiculoDTO>>(veiculoEntity);
        }

        public async Task Remove(Guid id)
        {
            var veiculoEntity = _veiculoRepository.GetByIdAsync(id).Result;
            await _veiculoRepository.RemoveAsync(veiculoEntity);
        }

        public async Task Update(VeiculoDTO veiculoDTO)
        {
            var veiculoEntity = _mapper.Map<Veiculo>(veiculoDTO);
            await _veiculoRepository.UpdateAsync(veiculoEntity);
        }
    }
}
