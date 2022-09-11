using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.DTOs;
using RentACar.Application.Interfaces;
using System;
using System.Threading.Tasks;

namespace RentACar.WebUI.Controllers
{
    [Authorize]
    public class MarcaController: Controller
    {
        private readonly IMarcaService _marcaService;

        public MarcaController(IMarcaService marcaService)
        {
            _marcaService = marcaService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var marcas = await _marcaService.GetMarcas();
            return View(marcas);
        }


        [HttpGet()]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MarcaDTO marca)
        {
            if (ModelState.IsValid)
            {
                var marcasJaCadastradas = await _marcaService.GetMarcas();
                foreach (var marcaCadastrada in marcasJaCadastradas)
                {
                    if(marcaCadastrada.Nome.ToUpper().Trim() == marca.Nome.ToUpper().Trim())
                    {
                        return BadRequest("Marca já existente");
                    }
                }
                await _marcaService.Add(marca);
                return RedirectToAction(nameof(Index));
            }
            return View(marca);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var marca = await _marcaService.GetById(id);
            if(marca == null)
            {
                return NotFound();
            }
            return View(marca);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MarcaDTO marca)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _marcaService.Update(marca);
                }
                catch (Exception)
                {

                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(marca);
        }
    }
}
