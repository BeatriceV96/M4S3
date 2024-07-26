using Microsoft.AspNetCore.Mvc;
using Weeklyapp.Services;
using Weeklyapp.DataLayer.Entities;

namespace Weeklyapp.Controllers
{
    public class ClientiController : Controller
    {
        private readonly ClienteService clienteService;

        public ClientiController(ClienteService clienteService)
        {
            this.clienteService = clienteService;
        }

        public IActionResult Index()
        {
            var clienti = clienteService.GetAll();
            return View(clienti);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ClienteEntity cliente)
        {
            if (ModelState.IsValid)
            {
                clienteService.Create(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public IActionResult Edit(string id)
        {
            var cliente = clienteService.Get(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Edit(string id, ClienteEntity cliente)
        {
            if (id != cliente.CodiceFiscale)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                clienteService.Update(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public IActionResult Delete(string id)
        {
            var cliente = clienteService.Get(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(string id)
        {
            clienteService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
