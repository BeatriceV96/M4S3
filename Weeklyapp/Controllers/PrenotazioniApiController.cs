using Microsoft.AspNetCore.Mvc;
using Weeklyapp.Services;

namespace Weeklyapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrenotazioniApiController : ControllerBase
    {
        private readonly PrenotazioneService prenotazioneService;

        public PrenotazioniApiController(PrenotazioneService prenotazioneService)
        {
            this.prenotazioneService = prenotazioneService;
        }

        [HttpGet("ByCodiceFiscale/{codiceFiscale}")]
        public IActionResult GetByCodiceFiscale(string codiceFiscale)
        {
            var prenotazioni = prenotazioneService.GetByCodiceFiscale(codiceFiscale);
            return Ok(prenotazioni);
        }

        [HttpGet("TotalPensioneCompleta")]
        public IActionResult GetTotalPrenotazioniPensioneCompleta()
        {
            var total = prenotazioneService.GetTotalPrenotazioniPensioneCompleta();
            return Ok(total);
        }
    }
}
