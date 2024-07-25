using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Weeklyapp.Models;
using Weeklyapp.Services;

namespace Weeklyapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PrenotazioneService _prenotazioneService;

        public HomeController(ILogger<HomeController> logger, PrenotazioneService prenotazioneService)
        {
            _logger = logger;
            _prenotazioneService = prenotazioneService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetLatestPrenotazioni()
        {
            var prenotazioni = _prenotazioneService.GetLatest(5); // Mostra le ultime 5 prenotazioni
            return Json(prenotazioni);
        }
    }
}
