using Weeklyapp.DataLayer.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Weeklyapp.DAO
{
    public class CameraDao : DaoBase
    {
        private const string SELECT_ALL_CAMERE = "SELECT Numero, Descrizione, Tipologia FROM Camere";
        private const string INSERT_CAMERA = "INSERT INTO Camere (Numero, Descrizione, Tipologia) VALUES (@Numero, @Descrizione, @Tipologia)";
        private const string UPDATE_CAMERA = "UPDATE Camere SET Descrizione = @Descrizione, Tipologia = @Tipologia WHERE Numero = @Numero";
        private const string DELETE_CAMERA = "DELETE FROM Camere WHERE Numero = @Numero";

        public CameraDao(IConfiguration configuration, ILogger<CameraDao> logger) : base(configuration, logger) { }

        public IEnumerable<CameraEntity> GetAll()
        {
            var result = new List<CameraEntity>();
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using (var cmd = new SqlCommand(SELECT_ALL_CAMERE, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var camera = new CameraEntity
                            {
                                Numero = reader.GetInt32(0),
                                Descrizione = reader.GetString(1),
                                Tipologia = reader.GetString(2)
                            };
                            result.Add(camera);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while getting the cameras");
                throw;
            }
            return result;
        }

        public void Create(CameraEntity camera)
        {
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using (var cmd = new SqlCommand(INSERT_CAMERA, conn))
                {
                    cmd.Parameters.AddWithValue("@Numero", camera.Numero);
                    cmd.Parameters.AddWithValue("@Descrizione", camera.Descrizione);
                    cmd.Parameters.AddWithValue("@Tipologia", camera.Tipologia);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while creating the camera");
                throw;
            }
        }

        public void Update(CameraEntity camera)
        {
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using (var cmd = new SqlCommand(UPDATE_CAMERA, conn))
                {
                    cmd.Parameters.AddWithValue("@Numero", camera.Numero);
                    cmd.Parameters.AddWithValue("@Descrizione", camera.Descrizione);
                    cmd.Parameters.AddWithValue("@Tipologia", camera.Tipologia);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while updating the camera");
                throw;
            }
        }

        public void Delete(int numero)
        {
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using (var cmd = new SqlCommand(DELETE_CAMERA, conn))
                {
                    cmd.Parameters.AddWithValue("@Numero", numero);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while deleting the camera");
                throw;
            }
        }
    }
}
