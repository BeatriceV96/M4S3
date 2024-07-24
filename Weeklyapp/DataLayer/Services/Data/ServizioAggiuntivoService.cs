using Weeklyapp.DataLayer.Entities;
using Weeklyapp.DataLayer.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Weeklyapp.DataLayer.Services.Data
{
    public class ServizioAggiuntivoService : IServizioAggiuntivoService
    {
        private readonly List<ServizioAggiuntivo> _serviziAggiuntivi = new List<ServizioAggiuntivo>();

        public void Create(ServizioAggiuntivo servizioAggiuntivo)
        {
            _serviziAggiuntivi.Add(servizioAggiuntivo);
        }

        public void Delete(int id)
        {
            var servizioAggiuntivo = _serviziAggiuntivi.FirstOrDefault(s => s.Id == id);
            if (servizioAggiuntivo != null)
            {
                _serviziAggiuntivi.Remove(servizioAggiuntivo);
            }
        }

        public ServizioAggiuntivo Read(int id)
        {
            return _serviziAggiuntivi.FirstOrDefault(s => s.Id == id);
        }

        public void Update(ServizioAggiuntivo servizioAggiuntivo)
        {
            var existingServizioAggiuntivo = _serviziAggiuntivi.FirstOrDefault(s => s.Id == servizioAggiuntivo.Id);
            if (existingServizioAggiuntivo != null)
            {
                existingServizioAggiuntivo.IdPrenotazione = servizioAggiuntivo.IdPrenotazione;
                existingServizioAggiuntivo.DataServizio = servizioAggiuntivo.DataServizio;
                existingServizioAggiuntivo.Descrizione = servizioAggiuntivo.Descrizione;
                existingServizioAggiuntivo.Quantita = servizioAggiuntivo.Quantita;
                existingServizioAggiuntivo.Prezzo = servizioAggiuntivo.Prezzo;
            }
        }

        public List<ServizioAggiuntivo> ReadAll()
        {
            return _serviziAggiuntivi;
        }
    }
}
