using Weeklyapp.DataLayer.Entities;

namespace Weeklyapp.DataLayer.Services.Interfaces
{
    public interface IClienteDao
    {
        /// <summary>
        /// Crea un cliente.
        /// </summary>
        /// <param name="cliente">Dettagli del cliente.</param>
        void Create(Cliente cliente);

        /// <summary>
        /// Elimina un cliente.
        /// </summary>
        /// <param name="codiceFiscale">Codice fiscale del cliente.</param>
        void Delete(string codiceFiscale);

        /// <summary>
        /// Recupera i dati di un cliente.
        /// </summary>
        /// <param name="codiceFiscale">Codice fiscale del cliente.</param>
        Cliente Read(string codiceFiscale);

        /// <summary>
        /// Aggiorna i dati di un cliente.
        /// </summary>
        /// <param name="cliente">Dettagli aggiornati del cliente.</param>
        void Update(Cliente cliente);

        /// <summary>
        /// Recupera tutti i clienti.
        /// </summary>
        List<Cliente> ReadAll();
    }
}
