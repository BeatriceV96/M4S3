using Microsoft.AspNetCore.Mvc;
using Weeklyapp.Services;

namespace Weeklyapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrenotazioniApiController : ControllerBase
    {
        private readonly PrenotazioneService _prenotazioneService;

        // Costruttore del controller, inietta il servizio delle prenotazioni
        public PrenotazioniApiController(PrenotazioneService prenotazioneService)
        {
            _prenotazioneService = prenotazioneService;
        }

        // Questo metodo gestisce le richieste GET per ottenere le prenotazioni in base al codice fiscale
        [HttpGet("ByCodiceFiscale/{codiceFiscale}")]
        public IActionResult GetByCodiceFiscale(string codiceFiscale)
        {
            // Utilizza il servizio per ottenere le prenotazioni per il codice fiscale specificato
            var prenotazioni = _prenotazioneService.GetByCodiceFiscale(codiceFiscale);
            // Restituisce le prenotazioni trovate come risposta JSON
            return Ok(prenotazioni);
        }

        // Questo metodo gestisce le richieste GET per ottenere il numero totale di prenotazioni con pensione completa
        [HttpGet("TotalPensioneCompleta")]
        public IActionResult GetTotalPensioneCompleta()
        {
            // Utilizza il servizio per ottenere il totale delle prenotazioni per la pensione completa
            var total = _prenotazioneService.GetTotalPrenotazioniPensioneCompleta();
            // Restituisce il totale come risposta JSON
            return Ok(total);
        }
    }
}

//Usa il servizio delle prenotazioni (PrenotazioneService) per eseguire le operazioni necessarie.