using Weeklyapp.DataLayer.Entities;
using Weeklyapp.DAO;
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

        public PrenotazioneEntity GetById(int id)
        {
            return _prenotazioneDao.GetById(id);
        }

        public void Create(PrenotazioneEntity prenotazione)
        {
            _prenotazioneDao.Create(prenotazione);
        }

        public void Update(PrenotazioneEntity prenotazione)
        {
            _prenotazioneDao.Update(prenotazione);
        }

        public void Delete(int id)
        {
            _prenotazioneDao.Delete(id);
        }
    }
}
