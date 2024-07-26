using Weeklyapp.DataLayer.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Weeklyapp.DAO
{
    public class ClienteDao : DaoBase
    {
        private const string SELECT_ALL_CLIENTI = "SELECT * FROM Clienti";
        private const string SELECT_CLIENTE_BY_ID = "SELECT * FROM Clienti WHERE CodiceFiscale = @CodiceFiscale";
        private const string INSERT_CLIENTE = "INSERT INTO Clienti (CodiceFiscale, Cognome, Nome, Citta, Provincia, Email, Telefono, Cellulare) VALUES (@CodiceFiscale, @Cognome, @Nome, @Citta, @Provincia, @Email, @Telefono, @Cellulare)";
        private const string UPDATE_CLIENTE = "UPDATE Clienti SET Cognome = @Cognome, Nome = @Nome, Citta = @Citta, Provincia = @Provincia, Email = @Email, Telefono = @Telefono, Cellulare = @Cellulare WHERE CodiceFiscale = @CodiceFiscale";
        private const string DELETE_CLIENTE = "DELETE FROM Clienti WHERE CodiceFiscale = @CodiceFiscale";

        public ClienteDao(IConfiguration configuration, ILogger<ClienteDao> logger) : base(configuration, logger) { }

        public IEnumerable<ClienteEntity> GetAll()
        {
            var result = new List<ClienteEntity>();
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using (var cmd = new SqlCommand(SELECT_ALL_CLIENTI, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var cliente = new ClienteEntity
                            {
                                CodiceFiscale = reader.GetString(0),
                                Cognome = reader.GetString(1),
                                Nome = reader.GetString(2),
                                Citta = reader.GetString(3),
                                Provincia = reader.GetString(4),
                                Email = reader.GetString(5),
                                Telefono = reader.GetString(6),
                                Cellulare = reader.GetString(7)
                            };
                            result.Add(cliente);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while getting the clients");
                throw;
            }
            return result;
        }

        public ClienteEntity Get(string codiceFiscale)
        {
            ClienteEntity cliente = null;
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using (var cmd = new SqlCommand(SELECT_CLIENTE_BY_ID, conn))
                {
                    cmd.Parameters.AddWithValue("@CodiceFiscale", codiceFiscale);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cliente = new ClienteEntity
                            {
                                CodiceFiscale = reader.GetString(0),
                                Cognome = reader.GetString(1),
                                Nome = reader.GetString(2),
                                Citta = reader.GetString(3),
                                Provincia = reader.GetString(4),
                                Email = reader.GetString(5),
                                Telefono = reader.GetString(6),
                                Cellulare = reader.GetString(7)
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while getting the client by CodiceFiscale");
                throw;
            }
            return cliente;
        }

        public void Create(ClienteEntity cliente)
        {
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var cmd = new SqlCommand(INSERT_CLIENTE, conn);
                cmd.Parameters.AddWithValue("@CodiceFiscale", cliente.CodiceFiscale);
                cmd.Parameters.AddWithValue("@Cognome", cliente.Cognome);
                cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@Citta", cliente.Citta);
                cmd.Parameters.AddWithValue("@Provincia", cliente.Provincia);
                cmd.Parameters.AddWithValue("@Email", cliente.Email);
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                cmd.Parameters.AddWithValue("@Cellulare", cliente.Cellulare);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while creating the client");
                throw;
            }
        }

        public void Update(ClienteEntity cliente)
        {
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var cmd = new SqlCommand(UPDATE_CLIENTE, conn);
                cmd.Parameters.AddWithValue("@CodiceFiscale", cliente.CodiceFiscale);
                cmd.Parameters.AddWithValue("@Cognome", cliente.Cognome);
                cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@Citta", cliente.Citta);
                cmd.Parameters.AddWithValue("@Provincia", cliente.Provincia);
                cmd.Parameters.AddWithValue("@Email", cliente.Email);
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                cmd.Parameters.AddWithValue("@Cellulare", cliente.Cellulare);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while updating the client");
                throw;
            }
        }

        public void Delete(string codiceFiscale)
        {
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var cmd = new SqlCommand(DELETE_CLIENTE, conn);
                cmd.Parameters.AddWithValue("@CodiceFiscale", codiceFiscale);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while deleting the client");
                throw;
            }
        }
    }
}
