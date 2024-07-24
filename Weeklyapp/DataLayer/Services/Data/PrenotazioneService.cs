using Weeklyapp.DAO;
using Weeklyapp.DataLayer.Entities;
using System.Collections.Generic;

namespace Weeklyapp.Services
{
    public class PrenotazioneService
    {
        private readonly PrenotazioneDao prenotazioneDao;

        public PrenotazioneService(PrenotazioneDao prenotazioneDao)
        {
            this.prenotazioneDao = prenotazioneDao;
        }

        public IEnumerable<PrenotazioneEntity> GetAll()
        {
            return prenotazioneDao.GetAll();
        }

        public void Create(PrenotazioneEntity prenotazione)
        {
            prenotazioneDao.Create(prenotazione);
        }
    }
}
