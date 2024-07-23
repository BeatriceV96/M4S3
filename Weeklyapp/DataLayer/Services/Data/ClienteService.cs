using Weeklyapp.DataLayer.Entities;
using Weeklyapp.DataLayer.Services.Interfaces;

namespace Weeklyapp.DataLayer.Services.Data
{
    public class ClienteService 
    {
        private readonly List<Cliente> _clienti = new List<Cliente>();

        public void Create(Cliente cliente)
        {
            _clienti.Add(cliente);
        }

        public void Delete(string codiceFiscale)
        {
            var cliente = _clienti.FirstOrDefault(c => c.CodiceFiscale == codiceFiscale);
            if (cliente != null)
            {
                _clienti.Remove(cliente);
            }
        }

        public Cliente Read(string codiceFiscale)
        {
            return _clienti.FirstOrDefault(c => c.CodiceFiscale == codiceFiscale);
        }

        public void Update(Cliente cliente)
        {
            var existingCliente = _clienti.FirstOrDefault(c => c.CodiceFiscale == cliente.CodiceFiscale);
            if (existingCliente != null)
            {
                existingCliente.Cognome = cliente.Cognome;
                existingCliente.Nome = cliente.Nome;
                existingCliente.Citta = cliente.Citta;
                existingCliente.Provincia = cliente.Provincia;
                existingCliente.Email = cliente.Email;
                existingCliente.Telefono = cliente.Telefono;
                existingCliente.Cellulare = cliente.Cellulare;
            }
        }

        public List<Cliente> ReadAll()
        {
            return _clienti;
        }
    }
}