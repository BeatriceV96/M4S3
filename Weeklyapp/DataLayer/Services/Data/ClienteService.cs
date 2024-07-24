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

        public void Create(ClienteEntity cliente)
        {
            clienteDao.Create(cliente);
        }
    }
}
