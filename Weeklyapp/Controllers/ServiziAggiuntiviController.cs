using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Weeklyapp.DataLayer.Entities;
using Weeklyapp.DataLayer.Services.Interfaces;

namespace Weeklyapp.Controllers
{
    [Authorize]
    public class ServiziAggiuntiviController : Controller
    {
        private readonly IServizioAggiuntivoService _servizioAggiuntivoService;

        public ServiziAggiuntiviController(IServizioAggiuntivoService servizioAggiuntivoService)
        {
            _servizioAggiuntivoService = servizioAggiuntivoService;
        }

        public IActionResult Index()
        {
            var serviziAggiuntivi = _servizioAggiuntivoService.ReadAll();
            return View(serviziAggiuntivi);
        }

        public IActionResult Details(int id)
        {
            var servizioAggiuntivo = _servizioAggiuntivoService.Read(id);
            if (servizioAggiuntivo == null)
            {
                return NotFound();
            }
            return View(servizioAggiuntivo);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ServizioAggiuntivo servizioAggiuntivo)
        {
            if (ModelState.IsValid)
            {
                _servizioAggiuntivoService.Create(servizioAggiuntivo);
                return RedirectToAction(nameof(Index));
            }
            return View(servizioAggiuntivo);
        }

        public IActionResult Edit(int id)
        {
            var servizioAggiuntivo = _servizioAggiuntivoService.Read(id);
            if (servizioAggiuntivo == null)
            {
                return NotFound();
            }
            return View(servizioAggiuntivo);
        }

        [HttpPost]
        public IActionResult Edit(int id, ServizioAggiuntivo servizioAggiuntivo)
        {
            if (id != servizioAggiuntivo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _servizioAggiuntivoService.Update(servizioAggiuntivo);
                return RedirectToAction(nameof(Index));
            }
            return View(servizioAggiuntivo);
        }

        public IActionResult Delete(int id)
        {
            var servizioAggiuntivo = _servizioAggiuntivoService.Read(id);
            if (servizioAggiuntivo == null)
            {
                return NotFound();
            }

            return View(servizioAggiuntivo);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _servizioAggiuntivoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
