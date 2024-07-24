using Weeklyapp.DataLayer.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Weeklyapp.DAO
{
    public class ServizioAggiuntivoDao : DaoBase
    {
        private const string SELECT_ALL_SERVIZI = "SELECT * FROM ServiziAggiuntivi";
        private const string SELECT_SERVIZIO_BY_ID = "SELECT * FROM ServiziAggiuntivi WHERE ID = @ID";
        private const string INSERT_SERVIZIO = "INSERT INTO ServiziAggiuntivi (IDPrenotazione, DataServizio, Descrizione, Quantita, Prezzo) VALUES (@IDPrenotazione, @DataServizio, @Descrizione, @Quantita, @Prezzo)";
        private const string UPDATE_SERVIZIO = "UPDATE ServiziAggiuntivi SET IDPrenotazione = @IDPrenotazione, DataServizio = @DataServizio, Descrizione = @Descrizione, Quantita = @Quantita, Prezzo = @Prezzo WHERE ID = @ID";
        private const string DELETE_SERVIZIO = "DELETE FROM ServiziAggiuntivi WHERE ID = @ID";

        public ServizioAggiuntivoDao(IConfiguration configuration, ILogger<ServizioAggiuntivoDao> logger) : base(configuration, logger) { }

        public IEnumerable<ServizioAggiuntivoEntity> GetAll()
        {
            var result = new List<ServizioAggiuntivoEntity>();
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using (var cmd = new SqlCommand(SELECT_ALL_SERVIZI, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var servizio = new ServizioAggiuntivoEntity
                            {
                                ID = reader.GetInt32(0),
                                IDPrenotazione = reader.GetInt32(1),
                                DataServizio = reader.GetDateTime(2),
                                Descrizione = reader.GetString(3),
                                Quantita = reader.GetInt32(4),
                                Prezzo = reader.GetDecimal(5)
                            };
                            result.Add(servizio);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while getting the additional services");
                throw;
            }
            return result;
        }

        public ServizioAggiuntivoEntity GetById(int id)
        {
            ServizioAggiuntivoEntity servizio = null;
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using (var cmd = new SqlCommand(SELECT_SERVIZIO_BY_ID, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            servizio = new ServizioAggiuntivoEntity
                            {
                                ID = reader.GetInt32(0),
                                IDPrenotazione = reader.GetInt32(1),
                                DataServizio = reader.GetDateTime(2),
                                Descrizione = reader.GetString(3),
                                Quantita = reader.GetInt32(4),
                                Prezzo = reader.GetDecimal(5)
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while getting the additional service by ID");
                throw;
            }
            return servizio;
        }

        public void Create(ServizioAggiuntivoEntity servizio)
        {
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using (var cmd = new SqlCommand(INSERT_SERVIZIO, conn))
                {
                    cmd.Parameters.AddWithValue("@IDPrenotazione", servizio.IDPrenotazione);
                    cmd.Parameters.AddWithValue("@DataServizio", servizio.DataServizio);
                    cmd.Parameters.AddWithValue("@Descrizione", servizio.Descrizione);
                    cmd.Parameters.AddWithValue("@Quantita", servizio.Quantita);
                    cmd.Parameters.AddWithValue("@Prezzo", servizio.Prezzo);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while creating the additional service");
                throw;
            }
        }

        public void Update(ServizioAggiuntivoEntity servizio)
        {
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using (var cmd = new SqlCommand(UPDATE_SERVIZIO, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", servizio.ID);
                    cmd.Parameters.AddWithValue("@IDPrenotazione", servizio.IDPrenotazione);
                    cmd.Parameters.AddWithValue("@DataServizio", servizio.DataServizio);
                    cmd.Parameters.AddWithValue("@Descrizione", servizio.Descrizione);
                    cmd.Parameters.AddWithValue("@Quantita", servizio.Quantita);
                    cmd.Parameters.AddWithValue("@Prezzo", servizio.Prezzo);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while updating the additional service");
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using (var cmd = new SqlCommand(DELETE_SERVIZIO, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while deleting the additional service");
                throw;
            }
        }
    }
}
