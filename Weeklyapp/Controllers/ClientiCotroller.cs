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
    }
}
