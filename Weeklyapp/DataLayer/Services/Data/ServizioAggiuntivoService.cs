using Weeklyapp.DAO;
using Weeklyapp.DataLayer.Entities;
using System.Collections.Generic;

namespace Weeklyapp.Services
{
    public class ServizioAggiuntivoService
    {
        private readonly ServizioAggiuntivoDao servizioAggiuntivoDao;

        public ServizioAggiuntivoService(ServizioAggiuntivoDao servizioAggiuntivoDao)
        {
            this.servizioAggiuntivoDao = servizioAggiuntivoDao;
        }

        public IEnumerable<ServizioAggiuntivoEntity> GetAll()
        {
            return servizioAggiuntivoDao.GetAll();
        }

        public void Create(ServizioAggiuntivoEntity servizio)
        {
            servizioAggiuntivoDao.Create(servizio);
        }
    }
}
