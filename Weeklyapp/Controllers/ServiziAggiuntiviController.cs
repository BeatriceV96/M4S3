using Microsoft.AspNetCore.Mvc;
using Weeklyapp.Services;
using Weeklyapp.Models;
using Weeklyapp.DataLayer.Entities;

namespace Weeklyapp.Controllers
{
    public class ServiziAggiuntiviController : Controller
    {
        private readonly ServizioAggiuntivoService servizioAggiuntivoService;

        public ServiziAggiuntiviController(ServizioAggiuntivoService servizioAggiuntivoService)
        {
            this.servizioAggiuntivoService = servizioAggiuntivoService;
        }

        public IActionResult Index()
        {
            var servizi = servizioAggiuntivoService.GetAll();
            return View(servizi);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ServizioAggiuntivoEntity servizio)
        {
            if (ModelState.IsValid)
            {
                servizioAggiuntivoService.Create(servizio);
                return RedirectToAction("Index");
            }
            return View(servizio);
        }
    }
}
