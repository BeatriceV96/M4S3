using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Weeklyapp.DataLayer.Entities;
using Weeklyapp.DataLayer.Services.Interfaces;

namespace Weeklyapp.Controllers
{
    [Authorize]
    public class ClientiController : Controller
    {
        private readonly IClienteDao _clienteService;

        public ClientiController(IClienteDao clienteService)
        {
            _clienteService = clienteService;
        }

        public IActionResult Index()
        {
            var clienti = _clienteService.ReadAll();
            return View(clienti);
        }

        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = _clienteService.Read(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _clienteService.Create(cliente);
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = _clienteService.Read(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Edit(string id, Cliente cliente)
        {
            if (id != cliente.CodiceFiscale)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _clienteService.Update(cliente);
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = _clienteService.Read(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(string id)
        {
            _clienteService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}