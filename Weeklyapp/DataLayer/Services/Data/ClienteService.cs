using Weeklyapp.DAO;
using Weeklyapp.DataLayer.Entities;
using System.Collections.Generic;

namespace Weeklyapp.Services
{
    public class ClienteService
    {
        private readonly ClienteDao _clienteDao;

        public ClienteService(ClienteDao clienteDao)
        {
            _clienteDao = clienteDao;
        }

        public IEnumerable<ClienteEntity> GetAll()
        {
            return _clienteDao.GetAll();
        }

        public ClienteEntity Get(string id)
        {
            return _clienteDao.Get(id);
        }

        public void Create(ClienteEntity cliente)
        {
            _clienteDao.Create(cliente);
        }

        public void Update(ClienteEntity cliente)
        {
            _clienteDao.Update(cliente);
        }

        public void Delete(string id)
        {
            _clienteDao.Delete(id);
        }
    }
}
