using Weeklyapp.DAO;
using Weeklyapp.DataLayer.Entities;
using System.Collections.Generic;

namespace Weeklyapp.Services
{
    public class ServizioAggiuntivoService
    {
        private readonly ServizioAggiuntivoDao _servizioAggiuntivoDao;
        private readonly PrenotazioneDao _prenotazioneDao;

        public ServizioAggiuntivoService(ServizioAggiuntivoDao servizioAggiuntivoDao, PrenotazioneDao prenotazioneDao)
        {
            _servizioAggiuntivoDao = servizioAggiuntivoDao;
            _prenotazioneDao = prenotazioneDao;
        }

        public IEnumerable<ServizioAggiuntivoEntity> GetAll()
        {
            return _servizioAggiuntivoDao.GetAll();
        }

        public ServizioAggiuntivoEntity GetById(int id)
        {
            return _servizioAggiuntivoDao.GetById(id);
        }

        public void Create(ServizioAggiuntivoEntity servizio)
        {
            if (!_prenotazioneDao.PrenotazioneExists(servizio.IDPrenotazione))
            {
                throw new Exception("La prenotazione specificata non esiste.");
            }
            _servizioAggiuntivoDao.Create(servizio);
        }

        public void Update(ServizioAggiuntivoEntity servizio)
        {
            _servizioAggiuntivoDao.Update(servizio);
        }

        public void Delete(int id)
        {
            _servizioAggiuntivoDao.Delete(id);
        }

        public IEnumerable<ServizioAggiuntivoEntity> GetByPrenotazione(int idPrenotazione)
        {
            return _servizioAggiuntivoDao.GetByPrenotazione(idPrenotazione);
        }
    }
}
