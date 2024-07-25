using Microsoft.AspNetCore.Mvc;
using Weeklyapp.Services;
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

        public IActionResult Edit(int id)
        {
            var prenotazione = prenotazioneService.Get(id);
            if (prenotazione == null)
            {
                return NotFound();
            }
            return View(prenotazione);
        }

        [HttpPost]
        public IActionResult Edit(int id, PrenotazioneEntity prenotazione)
        {
            if (id != prenotazione.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                prenotazioneService.Edit(prenotazione);
                return RedirectToAction("Index");
            }
            return View(prenotazione);
        }

        public IActionResult Delete(int id)
        {
            var prenotazione = prenotazioneService.Get(id);
            if (prenotazione == null)
            {
                return NotFound();
            }
            return View(prenotazione);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            prenotazioneService.Delete(id);
            return RedirectToAction("Index");
        }

        /*[HttpGet]
        public JsonResult SearchByCodiceFiscale(string codiceFiscale)
        {
            var prenotazioni = prenotazioneService.GetByCodiceFiscale(codiceFiscale);
            return Json(prenotazioni);
        }

        [HttpGet]
        public JsonResult GetTotalPensioneCompleta()
        {
            var total = prenotazioneService.GetTotalPrenotazioniPensioneCompleta();
            return Json(total);
        }*/    // Questi metodi sono stati spostati in PrenotazioniApiController me li gestisco lì ora dall'API controller

        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchResults(string codiceFiscale)
        {
            var prenotazioni = prenotazioneService.GetByCodiceFiscale(codiceFiscale);
            return Json(prenotazioni);
        }
    }
}
