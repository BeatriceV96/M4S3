using Weeklyapp.Controllers;
using Weeklyapp.DataLayer.Services.Interfaces;

namespace Weeklyapp.DataLayer.Services.Data
{
    public class DbContext 
    {
        public IClienteService Clienti { get; set; }

        public DbContext(IClienteService clienteDao)
        {
            Clienti = clienteDao;
        }
    }
}
