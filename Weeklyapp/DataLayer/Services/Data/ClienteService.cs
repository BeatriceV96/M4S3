using Weeklyapp.DAO;
using Weeklyapp.DataLayer.Entities;
using System.Collections.Generic;

namespace Weeklyapp.Services
{
    public class ClienteService
    {
        private readonly ClienteDao clienteDao;

        public ClienteService(ClienteDao clienteDao)
        {
            this.clienteDao = clienteDao;
        }

        public IEnumerable<ClienteEntity> GetAll()
        {
            return clienteDao.GetAll();
        }

        public ClienteEntity Get(string codiceFiscale)
        {
            return clienteDao.Get(codiceFiscale);
        }

        public void Create(ClienteEntity cliente)
        {
            clienteDao.Create(cliente);
        }

        public void Edit(ClienteEntity cliente)
        {
            clienteDao.Edit(cliente);
        }

        public void Delete(string codiceFiscale)
        {
            clienteDao.Delete(codiceFiscale);
        }
    }
}
