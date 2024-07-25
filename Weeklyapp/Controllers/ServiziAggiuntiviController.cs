using Microsoft.AspNetCore.Mvc;
using Weeklyapp.Services;
using Weeklyapp.DataLayer.Entities;

namespace Weeklyapp.Controllers
{
    public class ServiziAggiuntiviController : Controller
    {
        private readonly ServizioAggiuntivoService _servizioAggiuntivoService;

        public ServiziAggiuntiviController(ServizioAggiuntivoService servizioAggiuntivoService)
        {
            _servizioAggiuntivoService = servizioAggiuntivoService;
        }

        public IActionResult Index()
        {
            var servizi = _servizioAggiuntivoService.GetAll();
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
                try
                {
                    _servizioAggiuntivoService.Create(servizio);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Errore durante la creazione del servizio aggiuntivo: {ex.Message}");
                }
            }
            return View(servizio);
        }

        public IActionResult Edit(int id)
        {
            var servizio = _servizioAggiuntivoService.GetById(id);
            if (servizio == null)
            {
                return NotFound();
            }
            return View(servizio);
        }

        [HttpPost]
        public IActionResult Edit(int id, ServizioAggiuntivoEntity servizio)
        {
            if (id != servizio.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _servizioAggiuntivoService.Update(servizio);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Errore durante l'aggiornamento del servizio aggiuntivo: {ex.Message}");
                }
            }
            return View(servizio);
        }

        public IActionResult Delete(int id)
        {
            var servizio = _servizioAggiuntivoService.GetById(id);
            if (servizio == null)
            {
                return NotFound();
            }
            return View(servizio);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var servizio = _servizioAggiuntivoService.GetById(id);
            if (servizio == null)
            {
                return NotFound();
            }

            try
            {
                _servizioAggiuntivoService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Errore durante l'eliminazione del servizio aggiuntivo: {ex.Message}");
            }
            return View(servizio);
        }
    }
}
