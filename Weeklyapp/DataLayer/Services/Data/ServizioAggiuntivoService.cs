using Weeklyapp.DataLayer.Entities;
using Weeklyapp.DAO;
using System.Collections.Generic;

namespace Weeklyapp.Services
{
    public class ServizioAggiuntivoService
    {
        private readonly ServizioAggiuntivoDao _servizioAggiuntivoDao;

        public ServizioAggiuntivoService(ServizioAggiuntivoDao servizioAggiuntivoDao)
        {
            _servizioAggiuntivoDao = servizioAggiuntivoDao;
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
    }
}
