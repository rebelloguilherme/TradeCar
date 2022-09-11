using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.DTOs;
using RentACar.Application.Interfaces;
using System;
using System.Threading.Tasks;

namespace RentACar.WebUI.Controllers
{
    [Authorize]
    public class ProprietarioController : Controller
    {
        private readonly IProprietarioService _proprietarioService;

        public ProprietarioController(IProprietarioService proprietarioService)
        {
            _proprietarioService = proprietarioService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var proprietarios = await _proprietarioService.GetProprietarios();
            return View(proprietarios);
        }

        [HttpGet()]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProprietarioDTO proprietario)
        {
            if (ModelState.IsValid)
            {
                await _proprietarioService.Add(proprietario);
                return RedirectToAction(nameof(Index));
            }
            return View(proprietario);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var proprietario = await _proprietarioService.GetById(id);
            if (proprietario == null)
            {
                return NotFound();
            }
            return View(proprietario);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProprietarioDTO proprietario)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _proprietarioService.Update(proprietario);
                }
                catch (Exception)
                {

                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(proprietario);
        }

    }
}
