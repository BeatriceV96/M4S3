using Weeklyapp.DataLayer.Entities;
using System.Collections.Generic;

namespace Weeklyapp.DataLayer.Services.Interfaces
{
    public interface IClienteService
    {
        void Create(Cliente cliente);
        void Delete(string codiceFiscale);
        Cliente Read(string codiceFiscale);
        void Update(Cliente cliente);
        List<Cliente> ReadAll();
    }
}

