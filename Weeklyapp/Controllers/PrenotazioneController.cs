using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Weeklyapp.DataLayer.Entities;
using Weeklyapp.DataLayer.Services.Interfaces;

namespace Weeklyapp.Controllers
{
    [Authorize]
    public class PrenotazioniController : Controller
    {
        private readonly IPrenotazioneService _prenotazioneService;

        public PrenotazioniController(IPrenotazioneService prenotazioneService)
        {
            _prenotazioneService = prenotazioneService;
        }

        public IActionResult Index()
        {
            var prenotazioni = _prenotazioneService.ReadAll();
            return View(prenotazioni);
        }

        public IActionResult Details(int id)
        {
            var prenotazione = _prenotazioneService.Read(id);
            if (prenotazione == null)
            {
                return NotFound();
            }
            return View(prenotazione);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Prenotazione prenotazione)
        {
            if (ModelState.IsValid)
            {
                _prenotazioneService.Create(prenotazione);
                return RedirectToAction(nameof(Index));
            }
            return View(prenotazione);
        }

        public IActionResult Edit(int id)
        {
            var prenotazione = _prenotazioneService.Read(id);
            if (prenotazione == null)
            {
                return NotFound();
            }
            return View(prenotazione);
        }

        [HttpPost]
        public IActionResult Edit(int id, Prenotazione prenotazione)
        {
            if (id != prenotazione.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _prenotazioneService.Update(prenotazione);
                return RedirectToAction(nameof(Index));
            }
            return View(prenotazione);
        }

        public IActionResult Delete(int id)
        {
            var prenotazione = _prenotazioneService.Read(id);
            if (prenotazione == null)
            {
                return NotFound();
            }

            return View(prenotazione);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _prenotazioneService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
