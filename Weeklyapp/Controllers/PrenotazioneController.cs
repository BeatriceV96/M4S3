using Microsoft.AspNetCore.Mvc;
using Weeklyapp.Services;
using Weeklyapp.Models;
using Weeklyapp.DataLayer.Entities;

namespace Weeklyapp.Controllers
{
    public class PrenotazioniController : Controller
    {
        private readonly PrenotazioneService prenotazioneService;

        public PrenotazioniController(PrenotazioneService prenotazioneService)
        {
            this.prenotazioneService = prenotazioneService;
        }

        public IActionResult Index()
        {
            var prenotazioni = prenotazioneService.GetAll();
            return View(prenotazioni);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PrenotazioneEntity prenotazione)
        {
            if (ModelState.IsValid)
            {
                prenotazioneService.Create(prenotazione);
                return RedirectToAction("Index");
            }
            return View(prenotazione);
        }
    }
}
