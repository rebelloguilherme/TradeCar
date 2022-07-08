using Microsoft.AspNetCore.Mvc;
using RentACar.Application.DTOs;
using RentACar.Application.Interfaces;
using System;
using System.Threading.Tasks;

namespace RentACar.WebUI.Controllers
{
    public class VeiculoController : Controller
    {
        private readonly IVeiculoService _veiculoService;

        public VeiculoController(IVeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var veiculos = await _veiculoService.GetVeiculos();
            return View(veiculos);
        }


        [HttpGet()]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost()]
        public async Task<IActionResult> Create(VeiculoDTO veiculo)
        {
            if (ModelState.IsValid)
            {
                await _veiculoService.Add(veiculo);
                return RedirectToAction(nameof(Index));
            }
            return View(veiculo);
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var veiculo = await _veiculoService.GetById(id);
            if (veiculo == null)
            {
                return NotFound();
            }
            return View(veiculo);
        }

        [HttpPost()]
        public async Task<IActionResult> Edit(VeiculoDTO veiculo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _veiculoService.Update(veiculo);
                }
                catch (Exception)
                {

                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(veiculo);
        }
    }
}
