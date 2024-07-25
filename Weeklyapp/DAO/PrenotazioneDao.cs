using Weeklyapp.DataLayer.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Weeklyapp.DAO
{
    public class PrenotazioneDao : DaoBase
    {
        private const string SELECT_ALL_PRENOTAZIONI = "SELECT * FROM Prenotazioni";
        private const string SELECT_PRENOTAZIONE_BY_ID = "SELECT * FROM Prenotazioni WHERE ID = @ID";
        private const string INSERT_PRENOTAZIONE = "INSERT INTO Prenotazioni (CodiceFiscaleCliente, NumeroCamera, DataPrenotazione, NumeroProgressivoAnno, Anno, PeriodoDal, PeriodoAl, CaparraConfirmatoria, Tariffa, Dettagli) VALUES (@CodiceFiscaleCliente, @NumeroCamera, @DataPrenotazione, @NumeroProgressivoAnno, @Anno, @PeriodoDal, @PeriodoAl, @CaparraConfirmatoria, @Tariffa, @Dettagli)";
        private const string UPDATE_PRENOTAZIONE = "UPDATE Prenotazioni SET CodiceFiscaleCliente = @CodiceFiscaleCliente, NumeroCamera = @NumeroCamera, DataPrenotazione = @DataPrenotazione, NumeroProgressivoAnno = @NumeroProgressivoAnno, Anno = @Anno, PeriodoDal = @PeriodoDal, PeriodoAl = @PeriodoAl, CaparraConfirmatoria = @CaparraConfirmatoria, Tariffa = @Tariffa, Dettagli = @Dettagli WHERE ID = @ID";
        private const string DELETE_PRENOTAZIONE = "DELETE FROM Prenotazioni WHERE ID = @ID";
        private const string SELECT_PRENOTAZIONI_BY_CODICE_FISCALE = "SELECT * FROM Prenotazioni WHERE CodiceFiscaleCliente = @CodiceFiscaleCliente";
        private const string SELECT_TOTAL_PRENOTAZIONI_PENSIONE_COMPLETA = "SELECT COUNT(*) FROM Prenotazioni WHERE Dettagli = 'pensione completa'";
        private const string SELECT_LATEST_PRENOTAZIONI = "SELECT TOP (@Count) * FROM Prenotazioni ORDER BY DataPrenotazione DESC";

        public PrenotazioneDao(IConfiguration configuration, ILogger<PrenotazioneDao> logger) : base(configuration, logger) { }

        public IEnumerable<PrenotazioneEntity> GetAll()
        {
            var result = new List<PrenotazioneEntity>();
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using (var cmd = new SqlCommand(SELECT_ALL_PRENOTAZIONI, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var prenotazione = new PrenotazioneEntity
                            {
                                ID = reader.GetInt32(0),
                                CodiceFiscaleCliente = reader.GetString(1),
                                NumeroCamera = reader.GetInt32(2),
                                DataPrenotazione = reader.GetDateTime(3),
                                NumeroProgressivoAnno = reader.GetInt32(4),
                                Anno = reader.GetInt32(5),
                                PeriodoDal = reader.GetDateTime(6),
                                PeriodoAl = reader.GetDateTime(7),
                                CaparraConfirmatoria = reader.GetDecimal(8),
                                Tariffa = reader.GetDecimal(9),
                                Dettagli = reader.GetString(10)
                            };
                            result.Add(prenotazione);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while getting the prenotazioni");
                throw;
            }
            return result;
        }

        public PrenotazioneEntity Get(int id)
        {
            PrenotazioneEntity prenotazione = null;
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using (var cmd = new SqlCommand(SELECT_PRENOTAZIONE_BY_ID, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            prenotazione = new PrenotazioneEntity
                            {
                                ID = reader.GetInt32(0),
                                CodiceFiscaleCliente = reader.GetString(1),
                                NumeroCamera = reader.GetInt32(2),
                                DataPrenotazione = reader.GetDateTime(3),
                                NumeroProgressivoAnno = reader.GetInt32(4),
                                Anno = reader.GetInt32(5),
                                PeriodoDal = reader.GetDateTime(6),
                                PeriodoAl = reader.GetDateTime(7),
                                CaparraConfirmatoria = reader.GetDecimal(8),
                                Tariffa = reader.GetDecimal(9),
                                Dettagli = reader.GetString(10)
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while getting the prenotazione");
                throw;
            }
            return prenotazione;
        }

        public void Create(PrenotazioneEntity prenotazione)
        {
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var cmd = new SqlCommand(INSERT_PRENOTAZIONE, conn);
                cmd.Parameters.AddWithValue("@CodiceFiscaleCliente", prenotazione.CodiceFiscaleCliente);
                cmd.Parameters.AddWithValue("@NumeroCamera", prenotazione.NumeroCamera);
                cmd.Parameters.AddWithValue("@DataPrenotazione", prenotazione.DataPrenotazione);
                cmd.Parameters.AddWithValue("@NumeroProgressivoAnno", prenotazione.NumeroProgressivoAnno);
                cmd.Parameters.AddWithValue("@Anno", prenotazione.Anno);
                cmd.Parameters.AddWithValue("@PeriodoDal", prenotazione.PeriodoDal);
                cmd.Parameters.AddWithValue("@PeriodoAl", prenotazione.PeriodoAl);
                cmd.Parameters.AddWithValue("@CaparraConfirmatoria", prenotazione.CaparraConfirmatoria);
                cmd.Parameters.AddWithValue("@Tariffa", prenotazione.Tariffa);
                cmd.Parameters.AddWithValue("@Dettagli", prenotazione.Dettagli);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while creating the prenotazione");
                throw;
            }
        }

        public void Update(PrenotazioneEntity prenotazione)
        {
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var cmd = new SqlCommand(UPDATE_PRENOTAZIONE, conn);
                cmd.Parameters.AddWithValue("@ID", prenotazione.ID);
                cmd.Parameters.AddWithValue("@CodiceFiscaleCliente", prenotazione.CodiceFiscaleCliente);
                cmd.Parameters.AddWithValue("@NumeroCamera", prenotazione.NumeroCamera);
                cmd.Parameters.AddWithValue("@DataPrenotazione", prenotazione.DataPrenotazione);
                cmd.Parameters.AddWithValue("@NumeroProgressivoAnno", prenotazione.NumeroProgressivoAnno);
                cmd.Parameters.AddWithValue("@Anno", prenotazione.Anno);
                cmd.Parameters.AddWithValue("@PeriodoDal", prenotazione.PeriodoDal);
                cmd.Parameters.AddWithValue("@PeriodoAl", prenotazione.PeriodoAl);
                cmd.Parameters.AddWithValue("@CaparraConfirmatoria", prenotazione.CaparraConfirmatoria);
                cmd.Parameters.AddWithValue("@Tariffa", prenotazione.Tariffa);
                cmd.Parameters.AddWithValue("@Dettagli", prenotazione.Dettagli);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while updating the prenotazione");
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var cmd = new SqlCommand(DELETE_PRENOTAZIONE, conn);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while deleting the prenotazione");
                throw;
            }
        }

        public CheckoutDetails GetCheckoutDetails(int prenotazioneId)
        {
            var checkoutDetails = new CheckoutDetails();

            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();

                // Recupera i dettagli della prenotazione
                using (var cmd = new SqlCommand("SELECT * FROM Prenotazioni WHERE ID = @ID", conn))
                {
                    cmd.Parameters.AddWithValue("@ID", prenotazioneId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            checkoutDetails.Prenotazione = new PrenotazioneEntity
                            {
                                ID = reader.GetInt32(0),
                                CodiceFiscaleCliente = reader.GetString(1),
                                NumeroCamera = reader.GetInt32(2),
                                DataPrenotazione = reader.GetDateTime(3),
                                NumeroProgressivoAnno = reader.GetInt32(4),
                                Anno = reader.GetInt32(5),
                                PeriodoDal = reader.GetDateTime(6),
                                PeriodoAl = reader.GetDateTime(7),
                                CaparraConfirmatoria = reader.GetDecimal(8),
                                Tariffa = reader.GetDecimal(9),
                                Dettagli = reader.GetString(10)
                            };
                        }
                    }
                }

                // Recupera i servizi aggiuntivi
                var serviziAggiuntivi = new List<ServizioAggiuntivoEntity>();
                using (var cmd = new SqlCommand("SELECT * FROM ServiziAggiuntivi WHERE IDPrenotazione = @IDPrenotazione", conn))
                {
                    cmd.Parameters.AddWithValue("@IDPrenotazione", prenotazioneId);
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
                            serviziAggiuntivi.Add(servizio);
                        }
                    }
                }
                checkoutDetails.ServiziAggiuntivi = serviziAggiuntivi;

                // Calcola l'importo da saldare
                var totaleServiziAggiuntivi = serviziAggiuntivi.Sum(s => s.Prezzo * s.Quantita);
                checkoutDetails.ImportoDaSaldare = checkoutDetails.Prenotazione.Tariffa - checkoutDetails.Prenotazione.CaparraConfirmatoria + totaleServiziAggiuntivi;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while getting the checkout details");
                throw;
            }

            return checkoutDetails;
        }

        public IEnumerable<PrenotazioneEntity> GetByCodiceFiscale(string codiceFiscale)
        {
            var result = new List<PrenotazioneEntity>();
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using (var cmd = new SqlCommand(SELECT_PRENOTAZIONI_BY_CODICE_FISCALE, conn))
                {
                    cmd.Parameters.AddWithValue("@CodiceFiscaleCliente", codiceFiscale);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var prenotazione = new PrenotazioneEntity
                            {
                                ID = reader.GetInt32(0),
                                CodiceFiscaleCliente = reader.GetString(1),
                                NumeroCamera = reader.GetInt32(2),
                                DataPrenotazione = reader.GetDateTime(3),
                                NumeroProgressivoAnno = reader.GetInt32(4),
                                Anno = reader.GetInt32(5),
                                PeriodoDal = reader.GetDateTime(6),
                                PeriodoAl = reader.GetDateTime(7),
                                CaparraConfirmatoria = reader.GetDecimal(8),
                                Tariffa = reader.GetDecimal(9),
                                Dettagli = reader.GetString(10)
                            };
                            result.Add(prenotazione);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while getting the prenotazioni by codice fiscale");
                throw;
            }
            return result;
        }

        public int GetTotalPrenotazioniPensioneCompleta()
        {
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using (var cmd = new SqlCommand(SELECT_TOTAL_PRENOTAZIONI_PENSIONE_COMPLETA, conn))
                {
                    return (int)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while getting the total prenotazioni for pensione completa");
                throw;
            }
        }

        public IEnumerable<PrenotazioneEntity> GetLatest(int count)
        {
            var result = new List<PrenotazioneEntity>();
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using (var cmd = new SqlCommand(SELECT_LATEST_PRENOTAZIONI, conn))
                {
                    cmd.Parameters.AddWithValue("@Count", count);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var prenotazione = new PrenotazioneEntity
                            {
                                ID = reader.GetInt32(0),
                                CodiceFiscaleCliente = reader.GetString(1),
                                NumeroCamera = reader.GetInt32(2),
                                DataPrenotazione = reader.GetDateTime(3),
                                NumeroProgressivoAnno = reader.GetInt32(4),
                                Anno = reader.GetInt32(5),
                                PeriodoDal = reader.GetDateTime(6),
                                PeriodoAl = reader.GetDateTime(7),
                                CaparraConfirmatoria = reader.GetDecimal(8),
                                Tariffa = reader.GetDecimal(9),
                                Dettagli = reader.GetString(10)
                            };
                            result.Add(prenotazione);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while getting the latest prenotazioni");
                throw;
            }
            return result;
        }
    }
}
