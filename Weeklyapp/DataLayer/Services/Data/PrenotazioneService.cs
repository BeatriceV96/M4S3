using Weeklyapp.DAO;
using Weeklyapp.DataLayer.Entities;
using System.Collections.Generic;

namespace Weeklyapp.Services
{
    public class PrenotazioneService
    {
        private readonly PrenotazioneDao _prenotazioneDao;

        public PrenotazioneService(PrenotazioneDao prenotazioneDao)
        {
            _prenotazioneDao = prenotazioneDao;
        }

        public IEnumerable<PrenotazioneEntity> GetAll()
        {
            return _prenotazioneDao.GetAll();
        }

        public PrenotazioneEntity Get(int id)
        {
            return _prenotazioneDao.Get(id);
        }

        public void Create(PrenotazioneEntity prenotazione)
        {
            _prenotazioneDao.Create(prenotazione);
        }

        public void Edit(PrenotazioneEntity prenotazione)
        {
            _prenotazioneDao.Update(prenotazione);
        }

        public void Delete(int id)
        {
            _prenotazioneDao.Delete(id);
        }

        public IEnumerable<PrenotazioneEntity> GetByCodiceFiscale(string codiceFiscale)
        {
            return _prenotazioneDao.GetByCodiceFiscale(codiceFiscale);
        }

        public int GetTotalPrenotazioniPensioneCompleta()
        {
            return _prenotazioneDao.GetTotalPrenotazioniPensioneCompleta();
        }

        public IEnumerable<PrenotazioneEntity> GetLatest(int count)
        {
            return _prenotazioneDao.GetLatest(count);
        }
    }
}
