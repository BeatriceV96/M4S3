using Weeklyapp.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data.SqlClient;
using Weeklyapp.DataLayer.Entities;

namespace Weeklyapp.DAO
{
    public class PrenotazioneDao : DaoBase
    {
        private const string SELECT_ALL_PRENOTAZIONI = "SELECT * FROM Prenotazioni";
        private const string INSERT_PRENOTAZIONE = "INSERT INTO Prenotazioni (CodiceFiscaleCliente, NumeroCamera, DataPrenotazione, NumeroProgressivoAnno, Anno, PeriodoDal, PeriodoAl, CaparraConfirmatoria, Tariffa, Dettagli) VALUES (@CodiceFiscaleCliente, @NumeroCamera, @DataPrenotazione, @NumeroProgressivoAnno, @Anno, @PeriodoDal, @PeriodoAl, @CaparraConfirmatoria, @Tariffa, @Dettagli)";

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
                logger.LogError(ex, "An error occurred while getting the bookings");
                throw;
            }
            return result;
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
                logger.LogError(ex, "An error occurred while creating the booking");
                throw;
            }
        }
    }
}
