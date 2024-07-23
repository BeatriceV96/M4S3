using Weeklyapp.Controllers;
using Weeklyapp.DataLayer.Services.Interfaces;

namespace Weeklyapp.DataLayer.Services.Data
{
    public class DbContext
    {
        public IClienteDao Clienti { get; set; }

        public DbContext(IClienteDao clienteDao)
        {
            Clienti = clienteDao;
        }
    }
}
