using Weeklyapp.DataLayer.Entities;
using Weeklyapp.DataLayer.Services.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Weeklyapp.DataLayer.Services.Data
{
    public class ClienteService : IClienteService
    {
        private readonly string _connectionString;

        public ClienteService(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("AuthDb");
        }

        public void Create(Cliente cliente)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            var query = "INSERT INTO Clienti (CodiceFiscale, Cognome, Nome, Citta, Provincia, Email, Telefono, Cellulare) VALUES (@CodiceFiscale, @Cognome, @Nome, @Citta, @Provincia, @Email, @Telefono, @Cellulare)";
            using var cmd = new SqlCommand(query, conn);
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

        public void Delete(string codiceFiscale)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            var query = "DELETE FROM Clienti WHERE CodiceFiscale = @CodiceFiscale";
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@CodiceFiscale", codiceFiscale);
            cmd.ExecuteNonQuery();
        }

        public Cliente Read(string codiceFiscale)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            var query = "SELECT * FROM Clienti WHERE CodiceFiscale = @CodiceFiscale";
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@CodiceFiscale", codiceFiscale);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Cliente
                {
                    CodiceFiscale = reader["CodiceFiscale"].ToString(),
                    Cognome = reader["Cognome"].ToString(),
                    Nome = reader["Nome"].ToString(),
                    Citta = reader["Citta"].ToString(),
                    Provincia = reader["Provincia"].ToString(),
                    Email = reader["Email"].ToString(),
                    Telefono = reader["Telefono"].ToString(),
                    Cellulare = reader["Cellulare"].ToString()
                };
            }
            return null;
        }

        public void Update(Cliente cliente)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            var query = "UPDATE Clienti SET Cognome = @Cognome, Nome = @Nome, Citta = @Citta, Provincia = @Provincia, Email = @Email, Telefono = @Telefono, Cellulare = @Cellulare WHERE CodiceFiscale = @CodiceFiscale";
            using var cmd = new SqlCommand(query, conn);
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

        public List<Cliente> ReadAll()
        {
            var clienti = new List<Cliente>();
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            var query = "SELECT * FROM Clienti";
            using var cmd = new SqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                clienti.Add(new Cliente
                {
                    CodiceFiscale = reader["CodiceFiscale"].ToString(),
                    Cognome = reader["Cognome"].ToString(),
                    Nome = reader["Nome"].ToString(),
                    Citta = reader["Citta"].ToString(),
                    Provincia = reader["Provincia"].ToString(),
                    Email = reader["Email"].ToString(),
                    Telefono = reader["Telefono"].ToString(),
                    Cellulare = reader["Cellulare"].ToString()
                });
            }
            return clienti;
        }
    }
}
