using Weeklyapp.DataLayer.Entities;
using Weeklyapp.DataLayer.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Weeklyapp.DataLayer.Services.Data
{
    public class PrenotazioneService : IPrenotazioneService
    {
        private readonly List<Prenotazione> _prenotazioni = new List<Prenotazione>();

        public void Create(Prenotazione prenotazione)
        {
            _prenotazioni.Add(prenotazione);
        }

        public void Delete(int id)
        {
            var prenotazione = _prenotazioni.FirstOrDefault(p => p.Id == id);
            if (prenotazione != null)
            {
                _prenotazioni.Remove(prenotazione);
            }
        }

        public Prenotazione Read(int id)
        {
            return _prenotazioni.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Prenotazione prenotazione)
        {
            var existingPrenotazione = _prenotazioni.FirstOrDefault(p => p.Id == prenotazione.Id);
            if (existingPrenotazione != null)
            {
                existingPrenotazione.CodiceFiscaleCliente = prenotazione.CodiceFiscaleCliente;
                existingPrenotazione.NumeroCamera = prenotazione.NumeroCamera;
                existingPrenotazione.DataPrenotazione = prenotazione.DataPrenotazione;
                existingPrenotazione.NumeroProgressivoAnno = prenotazione.NumeroProgressivoAnno;
                existingPrenotazione.Anno = prenotazione.Anno;
                existingPrenotazione.PeriodoDal = prenotazione.PeriodoDal;
                existingPrenotazione.PeriodoAl = prenotazione.PeriodoAl;
                existingPrenotazione.CaparraConfirmatoria = prenotazione.CaparraConfirmatoria;
                existingPrenotazione.Tariffa = prenotazione.Tariffa;
                existingPrenotazione.Dettagli = prenotazione.Dettagli;
            }
        }

        public List<Prenotazione> ReadAll()
        {
            return _prenotazioni;
        }
    }
}
